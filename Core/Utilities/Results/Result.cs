using System;
namespace Core.Utilities.Results
{
    public class Result:IResult
    {
        bool _success;
        string _message;
        public Result(bool success,string message):this(success)
        {
            _message = message;
            Message = _message;
        }
        public Result(bool success)
        {
            _success = success;
            Success = _success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
