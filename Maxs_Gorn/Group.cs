using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxs_Gorn
{
    [Serializable]
    public class Group
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }

        public Group()
        {
            Students = new List<Student>();
        }
    }
}
