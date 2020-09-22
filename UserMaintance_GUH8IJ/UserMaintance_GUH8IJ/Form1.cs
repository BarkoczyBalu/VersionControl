using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintance_GUH8IJ.Entities;

namespace UserMaintance_GUH8IJ
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.FullName;
            button1.Text = Resource1.Add;
            button2.Text = Resource1.Write;
            button3.Text = Resource1.Delete;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
               FullName = textBox1.Text,
            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            if (sfd.FileName !="")
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    foreach (var item in users)
                    {
                        sw.Write(item.ID + " " + item.FullName);
                        sw.WriteLine();
                    }
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var x = new User()
            {
                FullName = textBox1.Text,
            };
            x = (User)listBox1.SelectedItem;
            users.Remove(x);
        }
    }
}
