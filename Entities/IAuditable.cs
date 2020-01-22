using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public interface IAuditable
    {
        DateTime CreationDate { get; set; }
        DateTime UpdateDate { get; set; }
    }
}
