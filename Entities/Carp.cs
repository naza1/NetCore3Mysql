using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Carp
    {
        public int Id { get; set; }
        public int NroCarp { get; set; }
        public Hall Hall { get; set; }
        public int Capacity { get; set; }
        public string Active { get; set; }
    }
}
