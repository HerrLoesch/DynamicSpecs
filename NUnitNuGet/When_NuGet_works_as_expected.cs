namespace NUnitNuGet
{
    using DynamicSpecs.NUnit;
    using NUnit.Framework;
    public class When_NuGet_works_as_expected : Specifies<object>
    {
        [Test]
        public void Then_this_test_should_be_green()
        {
            // TODO: Check for the library version
            Assert.IsNotNull(this.SUT);
        }
    }
}
