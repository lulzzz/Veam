﻿/*
 * Copyright (c) 2016 Billy Wolfington
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * https://github.com/Bwolfing/Bootstrap.AspNetCore.Mvc.TagHelpers
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootstrap.AspNetCore.Mvc.TagHelpers
{
    internal static class Global
    {
        internal const string PREFIX = "bs-";

        internal const int MIN_COLUMN_WIDTH = 1;
        internal const int MAX_COLUMN_WIDTH = 12;

        internal static string CloseButton(string data_dismiss)
        {
            return string.Format(@"<button type='button' class='close' data-dismiss='{0}' aria-label='Close'>
    <span aria-hidden='true'>&times;</span>
</button>", data_dismiss);
        }
    }
}
