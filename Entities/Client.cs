using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Client : IAuditable
    {
        public int Id { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool Active { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
