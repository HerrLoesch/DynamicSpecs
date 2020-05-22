namespace DynamicSpecs.Core
{
    public interface ICreateTypeStores
    {
        IRegisterTypes GetTypeRegistry();

        IResolveTypes GetTypeResolver();
    }
}