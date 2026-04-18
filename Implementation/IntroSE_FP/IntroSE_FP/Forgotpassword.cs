using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace IntroSE_FP
{
    public partial class Forgotpassword : Form
    {
        public Forgotpassword()
        {
            InitializeComponent();
        }

        private void Forgotpassword_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e) //username
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//email
        {

        }

        public static string user;
        
        void SetUser()
        {
            user = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e) //Next button
        {
            OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\Musa\Documents\IntroSE.accdb");
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT UserName, Email FROM USERS";
            cmd.Connection = conn;
            OleDbDataReader read = cmd.ExecuteReader();

            label4.Hide();
            label7.Hide();
            label5.Hide();
            label2.Hide();
            label8.Hide();

            bool correct = true;
            bool found = false;

            while (read.Read())
            {
                if (textBox1.Text.Length < 3 || textBox1.Text.Length > 12)//username len
                {
                    if (textBox1.Text == "")
                    {
                        label4.Show();
                        correct = false;
                    }
                    else
                    {
                        label7.Show();
                        correct = false;
                    }
                }

                if (textBox2.Text.Length < 7)//email len
                {
                    if (textBox2.Text == "")
                    {
                        label5.Show();
                        correct = false;
                    }
                    else
                    {
                        label2.Show();
                        correct = false;
                    }
                }

                //if (textBox2.Text.Length >= 7)//email valid
                //{
                //    int length = textBox2.Text.Length;
                //    string str = textBox2.Text;

                //    if (str[length - 4] != '.' || str[length - 3] != 'c' || str[length - 2] != 'o' || str[length - 1] != 'm' || str[0] == '@' || str[length - 5] == '@')
                //    {
                //        label8.Show();
                //        correct = false;
                //    }
                //    else
                //    {
                //        for (int i = 0; i < length - 4; i++)
                //        {
                //            if (str[i] == ' ')
                //            {
                //                label8.Show();
                //                correct = false;
                //            }
                //        }
                //    }
                //}

                if (correct == true)
                {
                    if (read[0].ToString() == textBox1.Text && read[1].ToString() == textBox2.Text)
                    {
                        found = true;
                        break;
                    }
                }
            }

            if(found == true && correct == true)
            {
                SetUser();

                this.Hide();
                Newpassword np = new Newpassword();
                np.Show();
            }
            else if (found == false)
            {
                MessageBox.Show("No Match Found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e) //Back button
        {
            this.Hide();
            Login log = new Login();
            log.Show();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return)) // next txtbox
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(this, new EventArgs());
            }
        }
    }
}
