using System;
namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç
    public interface IResult
    {
        public bool Success { get;}
        public string Message { get;}

    }
}
