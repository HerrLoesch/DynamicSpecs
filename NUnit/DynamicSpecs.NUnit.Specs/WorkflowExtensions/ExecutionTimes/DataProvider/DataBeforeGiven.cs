namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.DataProvider
{
    using DynamicSpecs.Core.WorkflowExtensions;
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using DataProvider = DynamicSpecs.NUnit.Specs.WorkflowExtensions.DataProvider;

    /// <summary>
    /// </summary>
    public class DataBeforeGiven : IExtend<IRequestDataBeforeGiven>
    {
        /// <summary>
        /// </summary>
        /// <param name="target">
        /// </param>
        public void Extend(IRequestDataBeforeGiven target)
        {
            target.Data = DataProvider.Data;
        }
    }
}