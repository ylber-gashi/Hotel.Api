using System;
using System.Collections.Generic;

namespace Hotel.Api.Application.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string key, string message)
        {
            Errors = new Dictionary<string, string[]> { { key, new string[] { message } } };
        }
        public IDictionary<string, string[]> Errors { get; }
    }
}
