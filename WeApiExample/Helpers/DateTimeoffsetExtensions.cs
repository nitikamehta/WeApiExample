﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeApiExample.Helpers
{
    public static  class DateTimeoffsetExtensions
    {
        public static int GetCurrentAge(this DateTimeOffset dateTimeOffset)
        {
            var CurrentDate = DateTime.UtcNow;
            int age = CurrentDate.Year - dateTimeOffset.Year;
            if (CurrentDate < dateTimeOffset.AddYears(age))
            {
                age--;
            }
            return age;
        }
    }

}
