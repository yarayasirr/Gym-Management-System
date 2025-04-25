using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gym_Management_System
{
    public partial class AddMember : Form
    {
        private TextBox member;
        private TextBox age;
        private TextBox phone;
        private TextBox amount;

        private string memberValue;
        private string ageValue;
        private string phoneValue;
        private string amountValue;
        public AddMember()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yaray\OneDrive\Documents\GymDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void AddMember_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox member = sender as TextBox;
            if (member != null)
            {
                memberValue = member.Text;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            TextBox age = sender as TextBox;
            if (age != null)
            {
                ageValue = age.Text;
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox phone = sender as TextBox;
            if (phone != null)
            {
                phoneValue = phone.Text;
            }
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            TextBox amount = sender as TextBox;
            if (amount != null)
            {
                amountValue = amount.Text;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Nametb.Text == "" || phonetb.Text == "" || amounttb.Text == "" || agetb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into MemberTbl values (@Name, @Phone, @Age, @Amount, @Timing)";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@Name", Nametb.Text);
                    cmd.Parameters.AddWithValue("@Phone", phonetb.Text);
                    cmd.Parameters.AddWithValue("@Age", agetb.Text);
                    cmd.Parameters.AddWithValue("@Amount", amounttb.Text);
                    cmd.Parameters.AddWithValue("@Timing", Timingcb.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Successfully Added");
                    Con.Close();
                    amounttb.Text = "";
                    agetb.Text = "";
                    Nametb.Text = "";
                    phonetb.Text = "";
                    Timingcb.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    // Ensure the connection is always closed, even if an error occurs
                    if (Con.State == ConnectionState.Open)
                    {
                        Con.Close();
                    }
                }

            }
        }
        private void Timingcb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //back button
            amounttb.Text = "";
            agetb.Text = "";
            Nametb.Text = "";
            phonetb.Text = "";
            Timingcb.Text = "";
            MainForm main = new MainForm();
            main.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}