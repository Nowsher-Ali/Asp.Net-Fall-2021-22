using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class NewsModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    }
}
