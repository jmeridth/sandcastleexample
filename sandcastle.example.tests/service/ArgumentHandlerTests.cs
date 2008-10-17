using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using sandcastle.example.domain;
using sandcastle.example.service;

namespace sandcastle.example.tests.service.ArgumentHandler_Specs
{
    public abstract class When_parsing_the_arguments_passed_to_example_console
    {
        protected ArgumentHandler serviceArgumentHandler;

        [SetUp]
        public void Setup()
        {
            serviceArgumentHandler = new ArgumentHandler();
        }

        [TestFixture]
        public class and_there_is_no_argument : When_parsing_the_arguments_passed_to_example_console
        {
            [Test]
            public void Should_show_usages()
            {
                var operation = serviceArgumentHandler.ProcessArguments(new[] { "" });
                Assert.That(operation.ShouldShowUsages, Is.True);
                Assert.That(operation.Action, Is.EqualTo(OperationAction.ShowUsages));
            }

            [Test]
            public void Should_show_usages_also()
            {
                var operation = serviceArgumentHandler.ProcessArguments(new string[] { });
                Assert.That(operation.ShouldShowUsages, Is.True);
                Assert.That(operation.Action, Is.EqualTo(OperationAction.ShowUsages));
            }
        }

        [TestFixture]
        public class and_the_first_argument_is_not_expected : When_parsing_the_arguments_passed_to_example_console
        {
            [Test]
            public void Should_show_usages()
            {
                var operation = serviceArgumentHandler.ProcessArguments(new[] { "?" });
                Assert.That(operation.ShouldShowUsages, Is.True);

                operation = serviceArgumentHandler.ProcessArguments(new[] { "f" });
                Assert.That(operation.ShouldShowUsages, Is.True);

                operation = serviceArgumentHandler.ProcessArguments(new[] { "3" });
                Assert.That(operation.ShouldShowUsages, Is.True);
            }
        }

        [TestFixture]
        public class and_more_than_required_arguments_are_passed : When_parsing_the_arguments_passed_to_example_console
        {
            [Test]
            public void Should_show_usages()
            {
                var operation = serviceArgumentHandler.ProcessArguments(new[] { "1", "2", "3" });
                Assert.That(operation.ShouldShowUsages, Is.True);
            }
        }

        [TestFixture]
        public class and_improper_email_format : When_parsing_the_arguments_passed_to_example_console
        {
            [Test]
            public void Should_show_usages()
            {
                var operation = serviceArgumentHandler.ProcessArguments(new[] { "j@j.come2", "message" });
                Assert.That(operation.ShouldShowUsages, Is.True);
                Assert.That(operation.Action, Is.EqualTo(OperationAction.ShowUsages));
            }

            [Test]
            public void Should_show_usages_also()
            {
                var operation = serviceArgumentHandler.ProcessArguments(new[] { "jATjDOTCOM", "message" });
                Assert.That(operation.ShouldShowUsages, Is.True);
                Assert.That(operation.Action, Is.EqualTo(OperationAction.ShowUsages));
            }
        }

        [TestFixture]
        public class and_proper_email_format_and_message : When_parsing_the_arguments_passed_to_example_console
        {
            [Test]
            public void Should_send_email()
            {
                var operation = serviceArgumentHandler.ProcessArguments(new[] { "test@test.com", "message" });
                Assert.That(operation.ShouldShowUsages, Is.False);
                Assert.That(operation.Action, Is.EqualTo(OperationAction.SendEmail));
            }
        }
    }
}