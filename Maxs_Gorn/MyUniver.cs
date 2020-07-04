using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxs_Gorn
{
    [Serializable]
    public class MyUniver
    {
        public string Name { get; set; }
        public List<Faculty> Faculties { get; set; }

        public MyUniver()
        {
            Faculties = new List<Faculty>();
        }
    }
}
