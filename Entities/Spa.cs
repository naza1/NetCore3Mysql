using System;
using System.Collections.Generic;

namespace Entities
{
    public class Spa : IAuditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Carp> Carps { get; set; }
        public List<Hall> Halls { get; set; }
        public bool Active { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
