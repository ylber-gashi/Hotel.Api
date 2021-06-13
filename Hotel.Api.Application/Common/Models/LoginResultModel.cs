using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Api.Application.Common.Models
{
    public class LoginResultModel
    {
        public bool Success { get; set; }
        public UserModel User { get; set; }
    }
}
