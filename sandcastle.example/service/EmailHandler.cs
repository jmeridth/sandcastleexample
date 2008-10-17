using System.Net.Mail;
using sandcastle.example.domain;

namespace sandcastle.example.service
{
    /// <summary>
    /// 
    /// </summary>
    public class EmailHandler
    {
        private readonly Operation operation;

        /// <summary>
        /// This is a constructor. Duh
        /// </summary>
        /// <param name="operation">Object representation of command-line arguments</param>
        public EmailHandler(Operation operation)
        {
            this.operation = operation;
        }

        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <returns>True if the </returns>
        public bool Send()
        {
            
//            try
//            {
//                SmtpClient smtpClient = new SmtpClient("localhost");
//                MailMessage mailMessage = new MailMessage("sandcastle@googlecode.com", operation.EmailAddress);
//                mailMessage.Body = operation.Message;
//                smtpClient.Send(mailMessage);
//            } catch (SmtpException smtpException)
//            {
//                return false;
//            }
            return true;
        }
    }
}