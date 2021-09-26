using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raymon.Common.Dtos
{
    public class LoginReturnDto
    {
        public bool IsSucceeded { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}
