namespace sandcastle.example.domain
{
    public class Operation
    {
        public string EmailAddress { get; set; }
        public string Message { get; set; }
        public OperationAction Action { get; set; }

		public Operation() : this(OperationAction.ShowUsages)
		{
		}

		public Operation(OperationAction action)
		{
			this.Action = action;
		}

		public bool ShouldShowUsages
		{
			get { return Action == OperationAction.ShowUsages; }
		}

    }

    public enum OperationAction
    {
        ShowUsages,
        SendEmail
    }
}