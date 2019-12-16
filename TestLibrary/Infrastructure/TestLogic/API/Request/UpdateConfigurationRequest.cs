using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestLibrary.Infrastructure.TestLogic.API.Request
{

    public class UpdateConfigurationAPIRequest
    {
        [Required]
        public string name { get; set; }
        [Required]
        public int value { get; set; }
    }
}
