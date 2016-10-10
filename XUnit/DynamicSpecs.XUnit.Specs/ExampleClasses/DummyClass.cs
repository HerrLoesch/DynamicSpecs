namespace DynamicSpecs.XUnit.Specs.ExampleClasses
{
    /// <summary>
    /// This class is a dummy of some real implementation to test. Specification.
    /// </summary>
    public class DummyClass
    {
        private IAmAServiceDummy dummyService;

        public DummyClass(IAmAServiceDummy serviceDummyService)
        {
            this.dummyService = serviceDummyService;
        }

        public int CallDoSomething(int givenNumber)
        {
            return this.dummyService.DoSomething(givenNumber);
        }
    }
}