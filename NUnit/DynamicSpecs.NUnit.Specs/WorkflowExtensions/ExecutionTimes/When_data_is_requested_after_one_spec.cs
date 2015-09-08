namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes
{
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using FluentAssertions;

    using global::NUnit.Framework;

    public class When_data_is_requested_after_one_spec : Specifies<object>, IRequestDataBeforeSpecExecutionCompleted
    {
        public int Data { get; set; }

        private static bool finishedOneSpec = false;

        private static object lockObject = new object();

        [Test]
        public void ThenDataMustBeAvailableAfterASpecWasFinished()
        {
            lock (lockObject)
            {
                if (finishedOneSpec)
                {
                    Data.ShouldBeEquivalentTo(WorkflowExtensions.DataProvider.Data);
                }

                finishedOneSpec = true;
            }
        }

        [Test]
        public void ThenDataMustBeAvailableAfterOneSpecWasFinished()
        {
            lock (lockObject)
            {
                if (finishedOneSpec)
                {
                    Data.ShouldBeEquivalentTo(WorkflowExtensions.DataProvider.Data);
                }

                finishedOneSpec = true;
            }
        }
    }
}