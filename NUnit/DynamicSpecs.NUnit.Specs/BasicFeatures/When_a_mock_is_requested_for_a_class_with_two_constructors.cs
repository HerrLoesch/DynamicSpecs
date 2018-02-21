namespace DynamicSpecs.NUnit.Specs.BasicFeatures
{
    using System.Runtime.Remoting.Activation;

    using global::NUnit.Framework;

    public class When_a_mock_is_requested_for_a_class_with_two_constructors : Specifies<TestDummyWithDependencyInjection>
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

        public TestDummyWithDependencyInjection()
        {
            
        }
    }
}