using System;
using System.Text.RegularExpressions;
using sandcastle.example.domain;

namespace sandcastle.example.service
{
    /// <summary>
    /// Processes the command line arguments
    /// </summary>
    public class ArgumentHandler
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="args">the command line arguments</param>
        /// <returns></returns>
        public Operation ProcessArguments(string[] args)
        {
            if (args.Length == 0 || args[0] == "") return new Operation(OperationAction.ShowUsages);
            string pattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}\s{1}.+$";
            if (!new Regex(pattern).IsMatch(string.Join(" ", args))) return new Operation();

            Operation serviceOperation = new Operation(OperationAction.SendEmail);

            return serviceOperation;
        }
    }
}