using System;
using sandcastle.example.domain;
using sandcastle.example.service;

namespace sandcastle.example
{
    /// <summary>
    /// Main program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// entry point for console application
        /// </summary>
        /// <param name="args">command line arguments</param>
        private static void Main(string[] args)
        {
            ArgumentHandler handler = new ArgumentHandler();
            Operation serviceOperation = handler.ProcessArguments(args);

            if (serviceOperation.ShouldShowUsages)
            {
                GetInstructions();
                return;
            }

            try
            {
                new EmailHandler(serviceOperation).Send();
                Console.WriteLine("Email sent to " + serviceOperation.EmailAddress + " successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        private static void GetInstructions()
        {
            Console.WriteLine("USAGE:");
            Console.WriteLine("    sandcastle.example.exe	[email address] [message]");
            Console.WriteLine("where");
            Console.WriteLine("    email address	a valid email address");
            Console.WriteLine("    message	        message to put in email address");
        }
    }
}