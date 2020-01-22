using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public static class DateTimeProvider
    {
        public static Func<DateTime> Now = () => DateTime.Now;
    }
}
