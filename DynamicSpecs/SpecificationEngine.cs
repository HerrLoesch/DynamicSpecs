using System;
using System.Collections.Generic;
using System.Linq;
using DynamicSpecs.Core.WorkflowExtensions;

namespace DynamicSpecs.Core
{
    using System.Reflection;

    public class SpecificationEngine
    {
        private readonly WorkflowSpecification specification;

        public SpecificationEngine(WorkflowSpecification specification)
        {
            this.specification = specification;
        }

        /// <summary>
        /// Contains code which hase to be executed after a spec.
        /// </summary>
        public void OnSpecExecutionCompleted()
        {
            this.ExecuteExtensions(WorkflowPosition.SpecExecutionCompleted);
        }

        /// <summary>
        /// Contains code which has to be executed after each then phase.
        /// </summary>
        public void OnThenIsCompleted()
        {
            this.ExecuteExtensions(WorkflowPosition.Then);
        }

        /// <summary>
        /// Executes all needed code necessary for a test run of this instance in a particular order. 
        /// </summary>
        public void Run()
        {
            this.specification.Initialize();

            this.DetermineTypesOfThisSpec();
            
            this.ExecuteExtensions(WorkflowPosition.TypeRegistration);

            this.specification.RegisterTypes();
            
            this.ExecuteExtensions(WorkflowPosition.SUTCreation);

            if (this.specification.WorkflowExtension != null)
            {
                this.specification.WorkflowExtension();
            }

            this.ExecuteExtensions(WorkflowPosition.Default, WorkflowPosition.Given);

            this.specification.Given();

            this.ExecuteExtensions(WorkflowPosition.When);

            this.specification.When();
        }

        /// <summary>
        /// Executes all extensions for <c>this</c> instance based on a workflow step. 
        /// </summary>
        /// <param name="targetSteps">The steps for which an extension must be registered to be executed.</param>
        private void ExecuteExtensions(params WorkflowPosition[] targetSteps)
        {
            foreach (var baseType in this.specificationsBaseTypes)
            {
                List<IExtend> extensions;
                if (Extensions.TryGetExtension(baseType, out extensions))
                {
                    var extensionsForStep = extensions.Where(x => targetSteps.Any(y => x.WorkflowPosition.HasFlag(y))).ToList();
                    foreach (var extension in extensionsForStep)
                    {
                        foreach (var targetStep in targetSteps)
                        {
                            if (targetStep != WorkflowPosition.Default)
                            {
                                extension.Extend(this.specification, targetStep);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Determines the types and base types of <c>this</c> spec.
        /// </summary>
        private void DetermineTypesOfThisSpec()
        {
            this.specificationsBaseTypes = this.specification.GetType().GetTypeInfo().ImplementedInterfaces.ToArray();
        }

        private Type[] specificationsBaseTypes;

    }
}