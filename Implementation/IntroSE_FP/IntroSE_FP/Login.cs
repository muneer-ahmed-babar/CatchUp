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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //forgotpassword
        {
            this.Hide();
            Forgotpassword fp = new Forgotpassword();
            fp.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;      //for password hide
        }

        private void textBox1_TextChanged(object sender, EventArgs e) //username
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) //password
        {

        }

        private void button1_Click(object sender, EventArgs e) //signup button
        {
            this.Hide();
            Signup signup = new Signup();
            signup.Show();
        }

        private void button2_Click(object sender, EventArgs e) //Next button
        {
            OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\Musa\Documents\IntroSE.accdb");
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT UserName, Pass FROM USERS";
            cmd.Connection = conn;
            OleDbDataReader read = cmd.ExecuteReader();

            label6.Hide();
            label4.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();

            bool found = false;
            bool correct = true;

            while (read.Read())
            {
                if (textBox1.Text.Length < 3 || textBox1.Text.Length > 12)
                {
                    if (textBox1.Text == "")
                    {
                        label6.Show();
                        correct = false;
                    }
                    else
                    {
                        label7.Show();
                        correct = false;
                    }
                }

                if (textBox1.Text.Length >= 3 && textBox1.Text.Length <= 12)// username char check
                {
                    int length = textBox1.Text.Length;
                    string str = textBox1.Text;

                    if (!(str[0] >= 97 && str[0] <= 122 || str[0] >= 65 && str[0] <= 90))
                    {
                        label10.Show();
                        correct = false;
                    }

                    for (int i = 1; i < length; i++)
                    {
                        if (!(str[i] >= 97 && str[i] <= 122 || str[i] >= 65 && str[i] <= 90 || str[i] >= 48 && str[i] <= 57 || str[i] == '_'))
                        {
                            label9.Show();
                            correct = false;
                            break;
                        }
                    }
                }

                if (textBox2.Text.Length < 3 || textBox2.Text.Length > 8)
                {
                    if (textBox2.Text == "")
                    {
                        label4.Show();
                        correct = false;
                    }
                    else
                    {
                        label8.Show();
                        correct = false;
                    }
                }
                else
                {
                    int length = textBox2.Text.Length;
                    string str = textBox2.Text;

                    if (str[0] == ' ' || str[length - 1] == ' ')
                    {
                        label11.Show();
                        correct = false;
                    }
                }

                if (read[0].ToString() == textBox1.Text && read[1].ToString() == textBox2.Text)
                {
                    found = true;
                    break;
                }
            }

            if (found == true)
            {
                this.Hide();
                Form1 dash = new Form1();
                dash.Show();
            }
            else if (found == false && correct == true)
            {
                MessageBox.Show("Invalid Username or Password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e) //pressing enter usern
        {
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e) //pressing enter pass
        {
            
        }

        private void button2_BackgroundImageChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)//pressing enter usern
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return)) // next txtbox
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            //textBox2.PasswordChar = '*';
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(this, new EventArgs());
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            //textBox2.PasswordChar = '*';
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)//show password checkbox
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
                //textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                //textBox2.PasswordChar = '*';
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
