using System.Collections.Generic;

namespace Entities
{
    public class Zone
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public List<Beach> Beaches { get; set; }
    }
}
