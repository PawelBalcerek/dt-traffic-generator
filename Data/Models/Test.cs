using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("Tests")]
    public class Test
    {
        public int TestId { get; set; }
        public int TestParametersId { get; set; }
        public int UserId { get; set; }
        public int EndpointId { get; set; }
        public DateTime DatabaseTestTime { get; set; }
        public DateTime ApplicationTestTime { get; set; }
        public DateTime ApiTestTime { get; set; }

        public virtual TestParameters TestParameters { get; set; }
        public virtual Endpoint Endpoint { get; set; }
    }
}
