using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Maxs_Gorn
{
    public class DataManager
    {
        string path;
        BinaryFormatter bf;

        public MyUniver MyUniver { get; set; }

        public DataManager()
        {
            path = @"..\..\Data\univer.dat";
            MyUniver = new MyUniver();
            bf = new BinaryFormatter();
            //InitData();
            //SaveData();

            LoadData();
        }

        public void LoadData()
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            MyUniver = (MyUniver)bf.Deserialize(fs);
            fs.Close();
        }

        public void SaveData()
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            
                bf.Serialize(fs, MyUniver);
                fs.Close();
            

        }

        void InitData()
        {
            Student s1 = new Student()
            {
                Name = "st1",
                Age = 25,
                Rate = 10.3,
            };

            Student s2 = new Student()
            {
                Name = "st2",
                Age = 22,
                Rate = 8.8,
            };

            Student s3 = new Student()
            {
                Name = "st3",
                Age = 16,
                Rate = 9.9,
            };
            Student s4 = new Student()
            {
                Name = "st4",
                Age = 30,
                Rate = 10.1,
            };
            Student s5 = new Student()
            {
                Name = "st5",
                Age = 26,
                Rate = 11.7,
            };

            Group g = new Group()
            {
                Name = "Group-1"
            };
            g.Students.AddRange(new Student[] { s1, s2 });
            Group g3 = new Group()
            {
                Name = "Group-3"
            };
            g3.Students.AddRange(new Student[] { new Student() { Age = 17, Name = "Andrey", Rate = 11 }, new Student() { Age = 18, Name = "Anton", Rate = 8.5 } });

            Group g2 = new Group()
            {
                Name = "Group-2"
            };
            g2.Students.AddRange(new Student[] { s3, s4, s5 });

            Faculty f = new Faculty()
            {
                Name = "Faculty-1"
            };
            Faculty f2 = new Faculty()
            {
                Name = "Faculty-2"
            };
            f.Groups.Add(g);
            f.Groups.Add(g3);
            f2.Groups.Add(g2);

            MyUniver.Name = "KPI";
            MyUniver.Faculties.Add(f);
            MyUniver.Faculties.Add(f2);

        }
    }
}
