using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotels.Api.Data.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Number { get; set; }
    }
}
