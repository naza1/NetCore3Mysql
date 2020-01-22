using System;
using System.Collections.Generic;

namespace Entities
{
    public class Rental : IAuditable
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public List<Garage> Garages { get; set; }
        public List<Carp> Carps { get; set; }
        public Spa Spa { get; set; }
        public bool Active { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
