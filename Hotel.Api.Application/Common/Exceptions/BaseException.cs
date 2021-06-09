using Hotel.Api.Application.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Api.Application.Common.Exceptions
{
    public class BaseException
    {
        public ExceptionType Type { get; set; } = ExceptionType.ServerError;
        public HttpStatusCode Code { get; set; } = HttpStatusCode.InternalServerError;

        public IList<string> Messages { get; set; }

        protected BaseException(string message) : base(message)
        {
        }

        public BaseException(string message, ExceptionType type, HttpStatusCode statusCode) : base(message)
        {
            Type = type;
            Code = statusCode;
        }

        public BaseException(string message, ExceptionType type, HttpStatusCode statusCode, IList<string> messages) : base(message)
        {
            Type = type;
            Code = statusCode;
            Messages = messages;
        }
    }
}