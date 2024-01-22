using System.Diagnostics;

namespace CatchDotNet.Core.Exceptions
{
    public sealed record Error
    {
        public Error(string code, string? message = null)
        {
            Code = code;
            Message = message;
        }

        public static Error None = new(String.Empty);
        public static Error NullValue = new("Error.NullValue", "Null value was provided");

        public string Code { get; }

        public string? Message { get; }

        public static implicit operator string(Error error) => error.Code;
    }

}
