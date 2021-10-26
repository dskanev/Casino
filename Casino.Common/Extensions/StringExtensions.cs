﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string text)
            => text == null || text.Trim().Length == 0;
    }
}
