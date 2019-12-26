using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestLibrary.Infrastructure.TestLogic.Models
{
    [Table("Configurations")]
    public partial class Configuration
    {
        [Key]
        public string Name { get; set; }
        public int Number { get; set; }
    }
}
