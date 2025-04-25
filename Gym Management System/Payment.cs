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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yaray\OneDrive\Documents\GymDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void FillName()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select MName from MemberTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("MName", typeof(string));
            dt.Load(rdr);
            Namecb.ValueMember = "MName";
            Namecb.DataSource = dt;
            Con.Close();
        }

        private void populate()
        {
            try
            {
                Con.Open();
                string query = "select * from PaymentTbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder();
                var ds = new DataSet();
                sda.Fill(ds);
                PaymentDGV.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            //back button
            MainForm main = new MainForm();
            main.Show();
            this.Hide();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            FillName();
            populate();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Namecb.Text) || string.IsNullOrEmpty(amountb.Text))
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                string payperiod = Period.Value.Month.ToString() + Period.Value.Year.ToString();
                // Assuming Con is defined and handled outside this method
                if (Con.State == ConnectionState.Closed)
                    Con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter("select count(*) from PaymentTbl where PMember='" + Namecb.SelectedValue.ToString() + "' and PMonth='" + payperiod + "'", Con))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show("Already paid for this month.");
                    }
                    else
                    {
                        string query = "insert into PaymentTbl values('" + payperiod + "','" + Namecb.SelectedValue.ToString() + "','" + amountb.Text + "')";
                        using (SqlCommand cmd = new SqlCommand(query, Con))
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Amount Paid Successfully!");
                        }
                    }
                }
                populate();
                Con.Close();
            }

        }
    }
}
