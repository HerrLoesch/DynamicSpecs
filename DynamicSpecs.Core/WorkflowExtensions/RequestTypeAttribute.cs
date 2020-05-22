namespace DynamicSpecs.Core.WorkflowExtensions
{
    using System;

    public class RequestTypeAttribute : Attribute
    {
        public Type RequestedType { get; }

        public RequestTypeAttribute(Type requestedType)
        {
            this.RequestedType = requestedType;
        }
    }
}