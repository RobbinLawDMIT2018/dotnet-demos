using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace back_end
{
    public class NamedColor
    {
        public NamedColor()
        {
            RgbCode = "";
            HexCode = "";
            Name = "";
        }
        public NamedColor (string rgbcode, string hexcode, string name)
        {
            RgbCode = rgbcode;
            HexCode = hexcode;
            Name = name;
        }

        public string RgbCode { get; set; }
        public string HexCode { get; set; }
        public string Name { get; set; }
    }
}
