using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class ReactModel
    {
        public int Id { get; set; }
        public Nullable<int> FK_Users_Id { get; set; }
        public Nullable<int> FK_News_Id { get; set; }
    }
}
