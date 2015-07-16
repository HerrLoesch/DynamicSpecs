namespace DynamicSpecs.Core
{
    public interface ISpecify<T> : ISpecify
    {
        T SUT { get; }
    }

    public interface ISpecify
    {
        void Given();

        void When();

        ISupport Given(ISupport supporter);

        TMock GetInstance<TMock>();
    }
}