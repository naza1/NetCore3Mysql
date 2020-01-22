using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Entities
{
    public class Hall
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<Carp> Carps { get; set; }
        public bool Active { get; set; }
    }
}
