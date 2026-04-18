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
    public partial class Newpassword : Form
    {
        public Newpassword()
        {
            InitializeComponent();
        }

        private void Newpassword_Load(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar = true;      //for password hide
            textBox2.UseSystemPasswordChar = true;      //for password hide
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
                button2_Click_1(this, new EventArgs());
            }
        }

        private void button2_Click_1(object sender, EventArgs e) // set
        {
            OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\Musa\Documents\IntroSE.accdb");
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;

            label2.Hide();
            label3.Hide();
            label9.Hide();
            label5.Hide();
            label6.Hide();
            label8.Hide();


            string UN = Forgotpassword.user;

            bool correct = true;

            if (textBox1.Text.Length < 3 || textBox1.Text.Length > 8)
            {
                if (textBox1.Text == "")
                {
                    label3.Show();
                    correct = false;
                }
                else
                {
                    label9.Show();
                    correct = false;
                }
            }
            else
            {
                int length = textBox1.Text.Length;
                string str = textBox1.Text;

                if (str[0] == ' ' || str[length - 1] == ' ')
                {
                    label2.Show();
                    correct = false;
                }
            }


            if (textBox2.Text != textBox1.Text)
            {
                if (textBox2.Text == "")
                {
                    label5.Show();
                    correct = false;
                }
                else if (textBox2.Text.Length < 3 || textBox2.Text.Length > 8)
                {
                    label6.Show();
                    correct = false;
                }
                else
                {
                    label8.Show();
                    correct = false;
                }
            }

            if (correct == true)
            {
                //MessageBox.Show($"{UN}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                
                cmd.CommandText = $"UPDATE USERS SET Pass = '{textBox1.Text}' WHERE UserName = '{UN}'";
                //"UPDATE USERS SET Pass = @p WHERE UserName = @u";
                //cmd.Parameters.AddWithValue("p", textBox1.Text);
                //cmd.Parameters.AddWithValue("u", UN);

                OleDbDataReader read = cmd.ExecuteReader();

                this.Hide();
                Login login = new Login();
                login.Show();
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Forgotpassword fp = new Forgotpassword();
            fp.Show();
        }
    }
}
