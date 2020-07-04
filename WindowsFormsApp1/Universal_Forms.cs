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
    public partial class Universal_Forms : Form
    {
        public object universal_obj { get; set; }
        Form1 form;
     
        public Universal_Forms()
        {
            InitializeComponent();
        }

        public void AddFacultity(Form1 form1)
            
        {
            this.form = form1;
            foreach (var el in form1.comboBox1.Items)
            {
                comboBox1.Items.Add(el);
            }
            comboBox1.SelectedIndex = 0;
        }
        public Universal_Forms(object type):this()
        {
         
            if (type.GetType() == typeof(Student))
            {
                AgeField.Visible = true;
                RatingField.Visible = true;
                universal_obj = new Student();
                label1.Text = "Введите имя студента: ";
                label2.Text = "Введите возраст студента: ";
                label3.Text = "Введите рейтинг студента: ";
                label2.Visible = true;
                label3.Visible = true; comboBox1.Visible = true; listBox1.Visible = true;
            }
            else if(type.GetType() == typeof(Group))
            {
                universal_obj = new Group();
                comboBox1.Visible = true;
                
                label1.Text = "Введите имя групи: ";
            }
            else
            {
                universal_obj = new Faculty();
              
              
                label1.Text = "Введите имя факультета: ";
            }

        }
        private void Universal_Forms_Load(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (NameField.Text.Length == 0)
                {
                    throw new Exception("Длина имени должна быть больше 0!");
                }

                if (universal_obj.GetType() == typeof(Student))
                {
               
                    if (AgeField.Text.Length == 0 || int.Parse(AgeField.Text) <= 0)
                    {
                        throw new Exception("Длина возраста должна быть больше 0!");
                    }
                    if (RatingField.Text.Length == 0 || int.Parse(RatingField.Text) <= 0  || int.Parse(RatingField.Text)>12)
                    {
                        throw new Exception("Длина рейтинга должна быть больше 0!");
                    }
                    if(listBox1.SelectedIndex<0)
                    {
                        throw new Exception("Selected Index<0!");
                    }
                    ((Student)universal_obj).Age = int.Parse(AgeField.Text);
                    ((Student)universal_obj).Rate = int.Parse(RatingField.Text);
                    ((Student)universal_obj).Name = NameField.Text;


                }
                else if (universal_obj.GetType() == typeof(Group))
                {
                    if (comboBox1.SelectedIndex < 0)
                    {
                        throw new Exception("Selected Index<0!");
                    }
                    ((Group)universal_obj).Name = NameField.Text;
                }
                else
                {
                    ((Faculty)universal_obj).Name = NameField.Text;
                }




                    this.DialogResult = DialogResult.OK;
            }
            catch (Exception eror)
            {
                MessageBox.Show(eror.Message,
                 "Сообщение: Eror!", MessageBoxButtons.RetryCancel,
                 MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (var el in form.dm.MyUniver.Faculties[comboBox1.SelectedIndex].Groups)
            {
                listBox1.Items.Add(el.Name);
            }
        }
    }
}
