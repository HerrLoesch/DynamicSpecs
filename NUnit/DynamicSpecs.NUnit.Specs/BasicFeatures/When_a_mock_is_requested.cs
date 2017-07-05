// When_a_mock_is_requested.cs
// 
// Comments : 
// Date     : 2017/07/05
// Author   : Lösch, Hendrik
// <copyright file="When_a_mock_is_requested.cs" company="Carl Zeiss Microscopy GmbH">
//      Copyright (c) Carl Zeiss Microscopy GmbH. All rights reserved.
// </copyright>
namespace DynamicSpecs.NUnit.Specs.BasicFeatures
{
    using System.Runtime.Remoting.Activation;

    using global::NUnit.Framework;

    public class When_a_mock_is_requested : Specifies<TestDummyWithDependencyInjection>
    {
        private IActivator initialReference;

        public override void Given()
        {
            this.initialReference = this.GetInstance<IActivator>();
        }

        [Test]
        public void then_we_get_the_same_istance_for_each_request()
        {
            var secondReference = this.GetInstance<IActivator>();

            Assert.AreSame(this.initialReference, secondReference);
        }

        [Test]
        public void then_we_get_the_same_instances_as_injected_to_SUT()
        {
            Assert.AreSame(this.initialReference, this.SUT.Reference);
        }
    }

    public class TestDummyWithDependencyInjection
    {
        public IActivator Reference;

        public TestDummyWithDependencyInjection(IActivator activator)
        {
            this.Reference = activator;
        }
    }
}