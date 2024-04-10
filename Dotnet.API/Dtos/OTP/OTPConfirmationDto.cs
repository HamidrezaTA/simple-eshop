using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet.API.Dtos.OTP
{
    public class OTPConfirmationDto
    {
        public string Code { get; set; }
        public string MobileNumber { get; set; }
    }
}