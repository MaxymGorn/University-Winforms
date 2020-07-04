using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxs_Gorn
{
    [Serializable]
    public class Faculty
    {
        public string Name { get; set; }
        public List<Group> Groups { get; set; }

        public Faculty()
        {
            Groups = new List<Group>();
        }
    }
}
