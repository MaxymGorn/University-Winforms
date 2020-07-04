using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Maxs_Gorn;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public DataManager dm;
        public Form1()
        {
            dm = new DataManager();
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex < 0)
                {
                    throw new Exception("Eror!");
                }
                dm.MyUniver.Faculties[comboBox1.SelectedIndex].Groups.RemoveAt(listBox1.SelectedIndex);
                Save();
                Update();
            }
            catch (Exception eror)
            {
                MessageBox.Show(eror.Message, "Eror index!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Update()
        {
            comboBox1.Items.Clear();
            listBox1.Items.Clear();
            listView1.Items.Clear();
            foreach (var el in dm.MyUniver.Faculties)
            {
                comboBox1.Items.Add(el.Name);

            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Update();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listView1.Items.Clear();

            foreach (var el in dm.MyUniver.Faculties[comboBox1.SelectedIndex].Groups)
            {
                listBox1.Items.Add(el.Name);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            try
            {
                if (listBox1.SelectedIndex < 0)
                {
                    throw new Exception("Eror!");
                }
                foreach (var elem in dm.MyUniver.Faculties[comboBox1.SelectedIndex].Groups[listBox1.SelectedIndex].Students)
                {
                   var item= listView1.Items.Add(elem.Name);
                    item.SubItems.Add(Convert.ToString(elem.Age));
                    item.SubItems.Add(Convert.ToString(elem.Rate));

                }
            }

            catch (Exception eror)
            {
                MessageBox.Show(eror.Message, "Eror index!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Universal_Forms at_form = new Universal_Forms(new Faculty());
        
            if (at_form.ShowDialog() == DialogResult.OK)
            {
                dm.MyUniver.Faculties.Add((Faculty)at_form.universal_obj);
                Save();
                Update();
                MessageBox.Show($"Сохранение изменений ...");
              

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Universal_Forms at_form = new Universal_Forms(new Student());
        
            at_form.AddFacultity(this);
        
            if (at_form.ShowDialog() == DialogResult.OK)
            {
                dm.MyUniver.Faculties[at_form.comboBox1.SelectedIndex].Groups[at_form.listBox1.SelectedIndex].Students.Add((Student)at_form.universal_obj);
               
                Save();
                Update();
                MessageBox.Show($"Сохранение изменений ...");

            }
        }

        private void button6_Click(object sender, EventArgs e)

        {
            Universal_Forms at_form = new Universal_Forms(new Group());
            at_form.AddFacultity(this);
            if (at_form.ShowDialog() == DialogResult.OK)
            {
                dm.MyUniver.Faculties[at_form.comboBox1.SelectedIndex].Groups.Add((Group)at_form.universal_obj);
                Save();
                Update();
                MessageBox.Show($"Сохранение изменений ...");

            }
        }
        private void Save()
        {
            dm.SaveData();
            dm.LoadData();
        }
        private void button2_Click(object sender, EventArgs e)
        {
        
                try
                {
                    if (comboBox1.SelectedIndex < 0)
                    {
                        throw new Exception("Eror!");
                    }
                    dm.MyUniver.Faculties.RemoveAt(comboBox1.SelectedIndex);
                    Save();
                    Update();
                }
                catch (Exception eror)
                {
                    MessageBox.Show(eror.Message, "Eror index!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems ==null)
                {
                    throw new Exception("Eror!");
                }
                dm.MyUniver.Faculties[comboBox1.SelectedIndex].Groups[listBox1.SelectedIndex].Students.RemoveAt(listView1.SelectedItems.Count);
                Save();
                Update();
            }
            catch (Exception eror)
            {
                MessageBox.Show(eror.Message, "Eror index!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {

                if(comboBox1.SelectedIndex<0)
                {
                    throw new Exception("Eror!");
                }
                Universal_Forms at_form = new Universal_Forms(new Faculty());

                if (at_form.ShowDialog() == DialogResult.OK)
                {
                    dm.MyUniver.Faculties[comboBox1.SelectedIndex].Name = ((Faculty)at_form.universal_obj).Name;
                    Save();
                    Update();
                    MessageBox.Show($"Сохранение изменений ...");


                }
            
            }
            catch (Exception eror)
            {
                MessageBox.Show(eror.Message, "Eror index!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                if (listBox1.SelectedIndex < 0)
                {
                    throw new Exception("Eror!");
                }
                Universal_Forms at_form = new Universal_Forms(new Group());
                at_form.comboBox1.Visible = false;
                at_form.AddFacultity(this);
                if (at_form.ShowDialog() == DialogResult.OK)
                {

                    dm.MyUniver.Faculties[comboBox1.SelectedIndex].Groups[listBox1.SelectedIndex] = ((Group)at_form.universal_obj);
                    Save();
                    Update();
                    MessageBox.Show($"Сохранение изменений ...");

                }
            }
            catch (Exception eror)
            {
                MessageBox.Show(eror.Message, "Eror index!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {

                if (listView1.SelectedItems.Count<=0)
                {
                    throw new Exception("Eror!");
                }
                Universal_Forms at_form = new Universal_Forms(new Student());
          

                at_form.AddFacultity(this);
                at_form.comboBox1.Visible = false;
                at_form.listBox1.Visible = false;
                at_form.comboBox1.SelectedIndex = 0;
                at_form.listBox1.SelectedIndex = 0;

                if (at_form.ShowDialog() == DialogResult.OK)
                {
                    dm.MyUniver.Faculties[comboBox1.SelectedIndex].Groups[listBox1.SelectedIndex].Students[listView1.SelectedItems.Count+1] = ((Student)at_form.universal_obj);
                    Save();
                    Update();
                    MessageBox.Show($"Сохранение изменений ...");


                }
            }
            catch (Exception eror)
            {
                MessageBox.Show(eror.Message, "Eror index!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
