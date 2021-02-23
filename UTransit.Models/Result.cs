using System;
using System.Collections.Generic;
using System.Text;

namespace UTransit.Models
{
    public interface IResult
    {
        public bool IsSucessful { get; set; }
        public string Message { get; set; }
    }

    public class Result : IResult
    {
        public bool IsSucessful { get; set; }
        public string Message { get; set; }

        public Result(bool isSucessful, string message)
        {
            IsSucessful = isSucessful;
            Message = message;
        }
    }
    public class Result<T> : IResult
    {
        public bool IsSucessful { get; set; }
        public T Value { get; set; }
        public string Message { get; set; }

        public Result(bool isSucessful, T value, string message)
        {
            IsSucessful = isSucessful;
            Value = value;
            Message = message;
        }
    }
}
