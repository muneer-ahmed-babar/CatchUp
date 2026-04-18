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
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //create account
        {
            OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\Musa\Documents\IntroSE.accdb");
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;

            label7.Hide();//missing
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();//3-8
            label12.Hide();//>7
            label13.Hide();//3-8
            label14.Hide();
            label15.Hide();//invalid email
            label16.Hide();//no sp chr
            label17.Hide();//strt w alp
            label18.Hide();//Invalid

            bool correct = true;

            if (textBox1.Text.Length < 3 || textBox1.Text.Length > 12)// username length
            {
                if (textBox1.Text == "")
                {
                    label7.Show();
                    correct = false;
                }
                else
                {
                    label11.Show();
                    correct = false;
                }
            }

            if (textBox1.Text.Length >= 3 && textBox1.Text.Length <= 12)// username char check
            {
                int length = textBox1.Text.Length;
                string str = textBox1.Text;

                if (!(str[0] >= 97 && str[0] <= 122 || str[0] >= 65 && str[0] <= 90))
                {
                    label17.Show();
                    correct = false;
                }

                for (int i = 1; i < length; i++)
                {
                    if (!(str[i] >= 97 && str[i] <= 122 || str[i] >= 65 && str[i] <= 90 || str[i] >= 48 && str[i] <= 57 || str[i] == '_'))
                    {
                        label16.Show();
                        correct = false;
                        break;
                    }
                }
            }

            if (textBox2.Text.Length < 7 || textBox2.Text.Length > 256)// Email length
            {
                if (textBox2.Text == "")
                {
                    label8.Show();
                    correct = false;
                }
                else 
                {
                    label12.Show();
                    correct = false;
                }
            }

            if (textBox2.Text.Length >= 7 && textBox2.Text.Length <= 256)//email validity
            {
                int length = textBox2.Text.Length;
                string str = textBox2.Text;

                if (str[length - 4] != '.' || str[length - 3] != 'c' || str[length - 2] != 'o' || str[length - 1] != 'm' ||
                    str[length - 5] == '@' || str[0] == '@' || str[0] == '.')    // check for .com and abc@.com and @abc.com and .abc@example.com
                {
                    label15.Show();
                    correct = false;
                }

                bool Afound = false;    //@found
                int count = 0;

                for (int i = 0; i < length; i++)
                {
                    if(str[i] == '@')
                    {
                        count++;
                        //Afound = true;
                    }
                }

                if (count != 1) //check for only 1 '@' in email
                {
                    label15.Show();
                    correct = false;
                }
                else
                {
                    Afound = true;
                }

                int IndexA = 0;   // loop will find which index @ is at and length of string before '@'

                if (Afound == true)
                {
                    for (IndexA = 0; IndexA < length; IndexA++)
                    {
                        if (str[IndexA] == '@')
                            break;
                    }

                    for (int i = IndexA + 1; i < length - 4; i++) // check for only alphabets @ and before .com
                    {
                        if (!(str[i] >= 97 && str[i] <= 122 || str[i] >= 65 && str[i] <= 90))
                        {
                            label15.Show();
                            correct = false;
                            break;
                        }
                    }

                    bool NumDot = true;    // numbers and .

                    for (int i = 0; i < IndexA; i++) // check on string BEFORE @
                    {
                        if (str[i] >= 97 && str[i] <= 122 || str[i] >= 65 && str[i] <= 90 || str[i] >= 48 && str[i] <= 57 || str[i] == '.')// valid input
                        {
                            if (i == 0 || i == IndexA - 1)// . at start or end of string
                            {
                                if (str[i] == '.')
                                {
                                    label15.Show();
                                    correct = false;
                                    break;
                                }
                            }
                            else if (str[i] == '.')// check on ".."
                            {
                                if (str[i - 1] == '.' || str[i + 1] == '.')
                                {
                                    label15.Show();
                                    correct = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            label15.Show();
                            correct = false;
                            break;
                        }

                        if (!(str[i] >= 48 && str[i] <= 57 || str[i] == '.'))// check if string is all num and .
                        {
                            NumDot = false;
                        }
                    }

                    if(NumDot == true && IndexA > 7) // if all num and dot and length > 7, 8th shud be char
                    {
                        label15.Show();
                        correct = false;
                    }
                }
                else
                {
                    label15.Show();
                    correct = false;
                }
                
                
            }  

            if (textBox3.Text.Length < 3 || textBox3.Text.Length > 8)
            {
                if (textBox3.Text == "")
                {
                    label9.Show();
                    correct = false;
                }
                else
                {
                    label13.Show();
                    correct = false;
                }
            }
            else
            {
                int length = textBox3.Text.Length;
                string str = textBox3.Text;

                if (str[0] == ' ' || str[length - 1] == ' ')
                {
                    label18.Show();
                    correct = false;
                }
            }
            
            
            if (textBox4.Text != textBox3.Text)
            {
                if (textBox4.Text == "")
                {
                    label10.Show();
                    correct = false;
                }
                else
                {
                    label14.Show();
                    correct = false;
                }
            }

            if (correct == true)
            {
                cmd.CommandText = "SELECT UserName, Email FROM USERS";
                OleDbDataReader read = cmd.ExecuteReader();

                bool userAvail = true;
                bool emailAvail = true;

                while (read.Read())
                {
                    if (read[0].ToString() == textBox1.Text)
                    {
                        userAvail = false;
                    }
                }

                read.Close();

                OleDbDataReader read1 = cmd.ExecuteReader();
                while (read1.Read())
                { 
                    if (read1[1].ToString() == textBox2.Text)
                    {
                        emailAvail = false;
                        break;
                    }
                }

                read1.Close();

                if (userAvail == true && emailAvail == true)
                {
                    cmd.CommandText = $"INSERT INTO USERS (UserName, Email, Pass) VALUES ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}')";
                    cmd.ExecuteNonQuery();

                    this.Hide();
                    Form1 dash = new Form1();
                    dash.Show();
                }
                else
                {
                    if (userAvail == false)
                    {
                        MessageBox.Show("Username Unavailable", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (emailAvail == false)
                    {
                        MessageBox.Show("Email Already In Use", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) //username
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) //email
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) //password
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e) //confirm password
        {

        }

        private void button1_Click(object sender, EventArgs e) //login button
        {
            this.Hide();
            Login log = new Login();
            log.Show();
        }

        private void Signup_Load(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = true;      //for password hide
            textBox4.UseSystemPasswordChar = true;      //for password hide
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return)) // next textbox
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return)) // next textbox
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return)) // next textbox
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // presses enter
            {
                button2_Click(this, new EventArgs());
            }
        }
    }
}
