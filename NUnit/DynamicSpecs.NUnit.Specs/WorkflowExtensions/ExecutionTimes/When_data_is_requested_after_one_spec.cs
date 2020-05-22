namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes
{
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using FluentAssertions;

    using global::NUnit.Framework;

    public class When_data_is_requested_after_one_spec : Specifies<object>, IRequestDataBeforeThenIsCompleted
    {
        public int Data { get; set; }

        // we need to have to test methods which are synchronized because we are unable to predict the execution order of them.
        private static bool finishedOneSpec = false;

        private static object lockObject = new object();

        [Test]
        public void Then_data_must_be_available_after_a_spec_was_finished()
        {
            lock (lockObject)
            {
                if (finishedOneSpec)
                {
                    Data.Should().Be(WorkflowExtensions.DataProvider.Data);
                }

                finishedOneSpec = true;
            }
        }

        [Test]
        public void Then_data_must_be_available_after_one_spec_was_finished()
        {
            lock (lockObject)
            {
                if (finishedOneSpec)
                {
                    Data.Should().Be(WorkflowExtensions.DataProvider.Data);
                }

                finishedOneSpec = true;
            }
        }
    }
}