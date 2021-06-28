using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationRazor
{
    public class ColorOptions
    {
        public const string Color = "Color";

        public string RGB { get; set; }
        public string Name { get; set; }
    }
}
