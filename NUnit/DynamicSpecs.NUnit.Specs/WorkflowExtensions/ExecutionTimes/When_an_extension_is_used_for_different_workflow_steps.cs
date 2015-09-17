using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes
{
    using FluentAssertions;

    using global::NUnit.Framework;

    public class When_an_extension_is_used_for_different_workflow_steps : Specifies<object>, IRequestStatefullData
    {
        public override void Given()
        {
            this.Data.ShouldBeEquivalentTo(1);
        }

        [Test]
        public void Then_the_extension_is_executed_for_all_steps()
        {
            this.Data.ShouldBeEquivalentTo(2);
        }

        public int Data { get; set; }
    }
}
