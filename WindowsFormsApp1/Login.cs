using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AdminLogin Obj = new AdminLogin();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection Con = new SqlConnection("data Source=MTHRAFID\\SQLEXPRESS;database=Car Wash;integrated Security=True;");
        public static string Username = "";
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from EmployeeTable where EName= '"+ LNameTb.Text + "' and EPass='"+ LPassTb.Text + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Username= LNameTb.Text;
                Start_Wash Obj = new Start_Wash();
                Obj.Show();
                this.Hide();
                Con.Close();
            }
            else
            {
                MessageBox.Show("Wrong UserName or Password");
            }
                Con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MainWash Obj = new MainWash();
            Obj.Show();
            this.Hide();
        }

        private void LNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
