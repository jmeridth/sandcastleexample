using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using sandcastle.example.domain;
using sandcastle.example.service;

namespace sandcastle.example.tests.service.EmailHandler_Specs
{
    [TestFixture]
    public class EmailHandlerTests
    {
        private Operation operation;
        private EmailHandler emailHandler;

        [SetUp]
        public void Setup()
        {
            operation = new Operation(OperationAction.SendEmail);
            operation.EmailAddress = "jason.meridth@rackspace.com";
            operation.Message = "test message";

            emailHandler = new EmailHandler(operation);
        }

        [Test]
        public void should_send_email_when_correct_information_is_provided()
        {
            bool success = emailHandler.Send();

            Assert.That(success, Is.True);
        }

    }
}