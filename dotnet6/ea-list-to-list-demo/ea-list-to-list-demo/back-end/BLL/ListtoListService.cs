using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace back_end
{
    public class ListtoListService
    {
        private readonly Context Context;
        public  ListtoListService(Context context) 
        {
            if (context == null)
                throw new ArgumentNullException();
            Context = context;
        }

        #region Named HTML Colors
        public List<NamedColor> ListHTMLColors()
        {
            List<NamedColor> colors = new List<NamedColor> {
                new NamedColor("rgb(255, 0, 0)", "#FF0000", "RED"),
                new NamedColor("rgb(255, 192, 203)", "#FFC0CB", "PINK"),
                new NamedColor("rgb(255, 165, 0)", "#FFA500", "ORANGE"),
                new NamedColor("rgb(255, 255, 0)", "#FFFF00", "YELLOW"),
                new NamedColor("rgb(128, 0, 128)", "#800080", "PURPLE"),
                new NamedColor("rgb(0, 128, 0)", "#008000", "GREEN"),
                new NamedColor("rgb(0, 0, 255)", "#0000FF", "BLUE"),
                new NamedColor("rgb(165, 42, 42)", "#A52A2A", "BROWN"),
                new NamedColor("rgb(255, 255, 255)", "#FFFFFF", "WHITE"),
                new NamedColor("rgb(128, 128, 128)", "#808080", "GRAY")
                };
            return colors;
        }
        #endregion
    }
}
