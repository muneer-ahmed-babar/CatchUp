using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntroSE_FP
{
    //public partial class Dashboard : Form
    //{
    //    public Dashboard()
    //    {
    //        InitializeComponent();
    //    }

    //    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    //    {

    //    }

    //    private void Dashboard_Load(object sender, EventArgs e)
    //    {

    //    }

    //    private void button1_Click(object sender, EventArgs e)
    //    {
    //        this.Hide();
    //        Login log = new Login();
    //        log.Show();
    //    }

    //    private void label3_Click(object sender, EventArgs e)
    //    {

    //    }
    //}

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_click(object sender, EventArgs e)
        {
            //Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btColorChange(homeButton, urgentButton, graphButton, profileButton, performanceButton);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            btColorChange(graphButton, homeButton, urgentButton, profileButton, performanceButton);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btColorChange(urgentButton, homeButton, graphButton, profileButton, performanceButton);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btColorChange(performanceButton, homeButton, urgentButton, graphButton, profileButton);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            btColorChange(profileButton, homeButton, urgentButton, graphButton, performanceButton);
        }

        private void panel4_MarginChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btColorChange(Button btn1, Button btn2, Button btn3, Button btn4, Button btn5)
        {
            btn1.BackColor = Color.FromArgb(0, 122, 204);
            btn2.BackColor = Color.FromArgb(28, 28, 28);
            btn3.BackColor = Color.FromArgb(28, 28, 28);
            btn4.BackColor = Color.FromArgb(28, 28, 28);
            btn5.BackColor = Color.FromArgb(28, 28, 28);
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
