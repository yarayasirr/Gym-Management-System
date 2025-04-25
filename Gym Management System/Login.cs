using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Management_System
{
    public partial class Login : Form
    {

        private TextBox userName;
        private TextBox password;

        private string userNameValue;
        private string passwordValue;

        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //title
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //username input
            TextBox userName = sender as TextBox;
            if (userName != null)
            {
                userNameValue = userName.Text;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // pass input
            TextBox password = sender as TextBox;   
            if(password!= null)
            {
                passwordValue = password.Text;  
            }

            

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // login button
            if (userNameValue == "yaramalak" && passwordValue=="1234")
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                DialogResult result = MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Retry)
                {
                    textBox1.Clear();
                    textBox2.Clear();
                }
                
            }
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
