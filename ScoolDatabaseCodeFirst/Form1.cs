using SchoolDatabaseCodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ScoolDatabaseCodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Populate();

        }




        private void lnameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void fnameBox_TextChanged(object sender, EventArgs e)
        {

        }



            private void listBox1_Format_1(object sender, ListControlConvertEventArgs e)
            {
                string Fname = ((Student)e.ListItem).FirstName.ToString().Trim();
                string Lname = ((Student)e.ListItem).LastName.ToString().Trim();
                string School = ((Student)e.ListItem).School.SchoolName.ToString().Trim();
                e.Value = Fname + " " + Lname + "\t" + School;
               //  listBox1.Sorted = true;
            }



        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                string Fname = fnameBox.Text.ToString();


                string Lname = lnameBox.Text.ToString();
                var Schools = schoolBox.SelectedItem as School;
                int Schoolid = Schools.ID;
                using (Connection conn = new Connection())
                {
                    try
                    {

                        var s = new Student()
                        {
                            FirstName = Fname,
                            LastName = Lname,
                            SchoolID = Schoolid,
                        };

                        conn.Student.Add(s);
                    }

                    catch
                    {
                        MessageBox.Show("Error Adding");
                    }

                    conn.SaveChanges();

                }

                Populate();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
        
    

            private void editButton_Click(object sender, System.EventArgs e)
            {
                try
                {
                    string Fname = fnameBox.Text.ToString();
                    string Lname = lnameBox.Text.ToString();
                    var Schools = schoolBox.SelectedItem as School;

                    int Schoolid = Schools.ID;
                    var Stu = listBox1.SelectedItem as Student;
                    int ID = Stu.ID;
        
            Student student = new Student();

                try
                {
                    using (Connection conn = new Connection())
                    {
                        int StuID = Stu.ID;
                        var studenbttoremove = conn.Student.Find(StuID);
                        conn.Student.Remove(studenbttoremove);
                        conn.SaveChanges();
                    }
                }
                catch { MessageBox.Show("Error Removing"); }



                using (Connection conn = new Connection())
                {
                    try
                    {

                        var s = new Student()
                        {
                            FirstName = Fname,
                            LastName = Lname,
                            SchoolID = Schoolid,
                            ID = ID,
                        };

                        conn.Student.Add(s);
                    }

                    catch { MessageBox.Show("Error Adding"); }

                    conn.SaveChanges();

                }
                Populate();
                }
                catch { MessageBox.Show("Error"); }

        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
            {
                var name = listBox1.SelectedItem as Student;

                fnameBox.Text = name.FirstName.Trim();
                lnameBox.Text = name.LastName.Trim();
            }

            private void delButton_Click(object sender, System.EventArgs e)
            {
                var stu = listBox1.SelectedItem as Student;
                Student student = new Student();
                try
                {
                    using (Connection conn = new Connection())
                    {
                        int StuID = stu.ID;
                        var studenbttoremove = conn.Student.Find(StuID);
                        conn.Student.Remove(studenbttoremove);
                        conn.SaveChanges();
                    }
                }
                catch { MessageBox.Show("Error Removing"); }
                Populate();
            }

            private void Xbutton_Click(object sender, System.EventArgs e)
            {
                System.Windows.Forms.Application.Exit();
            }


            void Populate()
            {
                listBox1.ResetText();
                School S = new School();
                using (Connection conn = new Connection())
                {
                    listBox1.DataSource = conn.Student.ToList();
                    listBox1.DisplayMember = "FirstName";
                    schoolBox.DataSource = conn.School.ToList();
                    schoolBox.DisplayMember = "SchoolName";
                }


            }

            private void schoolBox_SelectedIndexChanged(object sender, System.EventArgs e)
            {

            }

    }
    }

