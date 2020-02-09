namespace Domain.Commands.Outputs
{
    public class CommandResult
    {
        public CommandResult(int statusCode, object value)
        {
            StatusCode = statusCode;
            Value = value;
        }

        public int StatusCode { get; set; }
        public object Value { get; set; }
    }
}
