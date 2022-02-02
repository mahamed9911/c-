using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.mainDataDataSet);

        }

        private void usersBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.mainDataDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mainDataDataSet.Screening' table. You can move, or remove it, as needed.
            this.screeningTableAdapter.Fill(this.mainDataDataSet.Screening);
            // TODO: This line of code loads data into the 'mainDataDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.mainDataDataSet.Users);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(text1.Text);
                string name = text2.Text;
                string type = text3.Text;
                usersTableAdapter.Insert(id,name,type,false);
                this.usersTableAdapter.Fill(this.mainDataDataSet.Users);
                text1.Text = string.Empty;
                text2.Text = string.Empty;
                text3.Text = string.Empty;
            }
            catch
            {
                MessageBox.Show("wasnt able to add information to the table");
                
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool travel = false;
                bool contact = false;
                bool sym = false;
                bool state = true;
                bool state2 = false;
                if (checkBox1.CheckState == CheckState.Checked)
                {
                    contact = true;

                }
                if (checkBox2.CheckState == CheckState.Checked)
                {
                    travel = true;

                }
                if (checkBox3.CheckState == CheckState.Checked)
                {
                    sym = true;

                }
                string ids = userIDComboBox.Text;
                int id = int.Parse(ids);
                int screenid = int.Parse(text4.Text);
                screeningTableAdapter.Insert(screenid, id, contact, travel, sym);
                this.screeningTableAdapter.Fill(this.mainDataDataSet.Screening);
                text4.Text = string.Empty;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                if (travel == true ||contact == true ||sym == true)
                {
                    usersTableAdapter.UpdateQuery2(id);
                    this.usersTableAdapter.Fill(this.mainDataDataSet.Users);
                }
               


            }
            catch
            {
                MessageBox.Show("wasnt able to add information to the table");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string i = userIDComboBox1.Text;
                int id = int.Parse(i);
                usersTableAdapter.DeleteQuery1(id);
                screeningTableAdapter.DeleteQuery11(id);
                this.usersTableAdapter.Fill(this.mainDataDataSet.Users);
                this.screeningTableAdapter.Fill(this.mainDataDataSet.Screening);
            }
            catch
            {
                MessageBox.Show("wasnt able to delete information from the table");

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string i = userIDComboBox1.Text;
                int id = int.Parse(i);
                string newName = textBox12.Text;
                string newType = textBox14.Text;
                usersTableAdapter.UpdateQuery5(newName,newType,id);
                this.usersTableAdapter.Fill(this.mainDataDataSet.Users);
                textBox12.Text = string.Empty;
                textBox14.Text = string.Empty;
            }
            catch
            {
                MessageBox.Show("wasnt able to update information from the table");

            }
        }
    }
}
