using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Umbrella
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public Hall Hall { get; set; }
    }
}
