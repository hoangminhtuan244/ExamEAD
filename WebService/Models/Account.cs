using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebService.Models
{
    public class Acount
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public string Name { get; set; }
        [DataMember]
        [Required]
        public double Money { get; set; }
        [DataMember]
        [Required]
        public string CustomerCode { get; set; }
        [DataMember]
        [Required]
        public string SercurityCode { get; set; }
    }
}