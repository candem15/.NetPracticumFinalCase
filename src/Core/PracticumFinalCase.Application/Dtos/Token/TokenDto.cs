using PracticumFinalCase.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Dtos.Token
{
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
    }
}
