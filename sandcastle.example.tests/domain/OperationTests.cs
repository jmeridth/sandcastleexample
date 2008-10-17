using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using sandcastle.example.domain;

namespace sandcastle.example.tests.domain.Operation_Specs
{
    [TestFixture]
    public class When_using_the_operation_domain_object_and_action_is_show_usages
    {
        private Operation operation;

        [SetUp]
        public void should_return_true_for_show_usages_method()
        {
            operation = new Operation(OperationAction.ShowUsages);

            Assert.That(operation.ShouldShowUsages, Is.True);
        }
    }
}