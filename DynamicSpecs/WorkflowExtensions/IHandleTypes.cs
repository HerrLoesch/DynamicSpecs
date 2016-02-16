namespace DynamicSpecs.Core.WorkflowExtensions
{
    using System;

    public interface IHandleTypes

    {
        void Register(IRegisterTypes typeRegistry);

        void For<T>();

        bool IsApplicableFor(Type type);
    }
}