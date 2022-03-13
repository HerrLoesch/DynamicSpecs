using DynamicSpecs.Core;

namespace DynamicSpecs.AutoFacItEasy
{
    public class TypeStoreFactory : ICreateTypeStores
    {
        private TypeRegistry typeRegistry;

        public TypeStoreFactory()
        {
            this.typeRegistry = new TypeRegistry();
        }

        public IRegisterTypes GetTypeRegistry()
        {
            return this.typeRegistry;
        }

        public IResolveTypes GetTypeResolver()
        {
            return this.typeRegistry;
        }
    }
}