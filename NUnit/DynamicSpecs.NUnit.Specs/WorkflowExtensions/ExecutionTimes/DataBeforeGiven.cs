namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes
{
    using DynamicSpecs.Core.WorkflowExtensions;
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExtensionsForTypeRegistration;

    /// <summary>
    /// </summary>
    public class DataBeforeGiven : IExtend<IRequestDataBeforeGiven>
    {
        public static int ProvidedData = 42;

        /// <summary>
        /// </summary>
        /// <param name="target">
        /// </param>
        public void Extend(IRequestDataBeforeGiven target)
        {
            target.Data = ProvidedData;
        }
    }
}