using System;
using System.Collections.Generic;

namespace Hotel.Api.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string key, string message) : base($"Entity was not found.")
        {
            Errors = new Dictionary<string, string[]> { { key, new string[] { message } } };
        }
        public IDictionary<string, string[]> Errors { get; }
    }
}
