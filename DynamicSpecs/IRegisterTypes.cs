namespace DynamicSpecs.Core
{
    public interface IRegisterTypes
    {
        void Register<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class;
    }
}