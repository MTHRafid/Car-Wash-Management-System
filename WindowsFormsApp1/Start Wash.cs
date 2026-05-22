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
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Start_Wash : Form
    {
        public Start_Wash()
        {
            InitializeComponent();
            FillCustomers();
            FillServices();
            ENameLbl.Text = "Employee: " + Login.Username + "";

           
            ServiceDGV.Columns.Clear();

            
            DataGridViewTextBoxColumn idCol = new DataGridViewTextBoxColumn();
            idCol.HeaderText = "ID";
            idCol.Name = "IDCol";
            idCol.Width = 40;
            ServiceDGV.Columns.Add(idCol);

            
            DataGridViewTextBoxColumn customerCol = new DataGridViewTextBoxColumn();
            customerCol.HeaderText = "Customer";
            customerCol.Name = "CustomerCol";
            customerCol.Width = 100;
            ServiceDGV.Columns.Add(customerCol);

           
            DataGridViewTextBoxColumn serviceCol = new DataGridViewTextBoxColumn();
            serviceCol.HeaderText = "Service";
            serviceCol.Name = "ServiceCol";
            serviceCol.Width = 120;
            ServiceDGV.Columns.Add(serviceCol);

            
            DataGridViewTextBoxColumn priceCol = new DataGridViewTextBoxColumn();
            priceCol.HeaderText = "Price";
            priceCol.Name = "PriceCol";
            priceCol.Width = 80;
            ServiceDGV.Columns.Add(priceCol);

            ServiceDGV.AllowUserToAddRows = false;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
           
        }
        SqlConnection Con = new SqlConnection("data Source=MTHRAFID\\SQLEXPRESS;database=Car Wash;integrated Security=True;");
        private void FillCustomers()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select CName from CustomersTable",Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Cname", typeof(string));
            dt.Load(rdr);
            SWCustomerNameCb.ValueMember = "CName";
            SWCustomerNameCb.DataSource = dt;
            Con.Close();
        }
        private void FillServices()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select SName from ServiceTable", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Sname", typeof(string));
            dt.Load(rdr);
            SWServiceCb.ValueMember = "SName";
            SWServiceCb.DataSource = dt;
            Con.Close();
        }
        private void GetCustomerData()
        {
            Con.Open();
            string query = "select * from CustomersTable where CName='" + SWCustomerNameCb.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query,Con); ;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                SWPhoneTb.Text = dr["CPhone"].ToString();
            }
            Con.Close() ;
        }
        private void GetServiceData()
        {
            Con.Open();
            string query = "select * from ServiceTable where SName='" + SWServiceCb.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, Con); ;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                SWPriceTb.Text = dr["SPrice"].ToString();
            }
            Con.Close();
        }

        private void SWCustomerNameCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCustomerData();
        }

        private void SWServiceCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetServiceData();
        }

        private void StartWashDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        int n = 0, Grdtotal = 0;

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void TotalLbl_Click(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Reset()
        {
            SWCustomerNameCb.SelectedIndex = -1;
            SWPhoneTb.Text = "";
            SWServiceCb.SelectedIndex = -1;
            SWPriceTb.Text = "";
        }
        private void AddBillBtn_Click(object sender, EventArgs e)
        {
            if (SWPhoneTb.Text == "" || SWCustomerNameCb.SelectedIndex == -1 || ServiceDGV.Rows.Count == 0)
            {
                MessageBox.Show("Please select a customer and add at least one service");
                return;
            }

            try
            {
                Con.Open();

                
                string employeeName = Login.Username; 

                
                string insertQuery = "INSERT INTO InvoiceTable (SWCustomerName, SWPhone, EName, Amt, IDate) VALUES (@Cn, @Cp, @En, @Am, @Id)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, Con);
                insertCmd.Parameters.AddWithValue("@Cn", SWCustomerNameCb.SelectedValue.ToString());
                insertCmd.Parameters.AddWithValue("@Cp", SWPhoneTb.Text);
                insertCmd.Parameters.AddWithValue("@En", employeeName); 
                insertCmd.Parameters.AddWithValue("@Am", Grdtotal);
                insertCmd.Parameters.AddWithValue("@Id", TodayDate.Value.Date);
                insertCmd.ExecuteNonQuery();

                MessageBox.Show("Invoice saved successfully!");
                Con.Close();
                Reset();

                
                ServiceDGV.Rows.Clear();
                Grdtotal = 0;
                TotalLbl.Text = "BDT 0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving invoice: " + ex.Message);
                Con.Close();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Services Obj = new Services();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Services Obj = new Services();
            Obj.Show();
            this.Hide();
        }

        private void ENameLbl_Click(object sender, EventArgs e)
        {

        }

        private void DeleteServiceBtn_Click(object sender, EventArgs e)
        {
            if (ServiceDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a service to delete");
                return;
            }

            DataGridViewRow row = ServiceDGV.SelectedRows[0];
            int price = Convert.ToInt32(row.Cells["PriceCol"].Value);

            ServiceDGV.Rows.Remove(row);
            Grdtotal -= price;
            TotalLbl.Text = "BDT " + Grdtotal;

           
            for (int i = 0; i < ServiceDGV.Rows.Count; i++)
            {
                ServiceDGV.Rows[i].Cells["IDCol"].Value = i + 1;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Invoice Obj = new Invoice();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Invoice Obj = new Invoice();
            Obj.Show();
            this.Hide();
        }

        private void Start_Wash_Load(object sender, EventArgs e)
        {

        }

        private void AddServiceBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SWPriceTb.Text) || SWServiceCb.SelectedIndex == -1 || SWCustomerNameCb.SelectedIndex == -1)
            {
                MessageBox.Show("Select Customer and Service");
                return;
            }

            string customerName = SWCustomerNameCb.SelectedValue.ToString();
            string serviceName = SWServiceCb.SelectedValue.ToString();

            
            foreach (DataGridViewRow row in ServiceDGV.Rows)
            {
                if (row.Cells["CustomerCol"].Value != null &&
                    row.Cells["ServiceCol"].Value != null &&
                    row.Cells["CustomerCol"].Value.ToString() == customerName &&
                    row.Cells["ServiceCol"].Value.ToString() == serviceName)
                {
                    MessageBox.Show("This service is already added for this customer");
                    return;
                }
            }

            
            int newId = ServiceDGV.Rows.Count + 1;
            ServiceDGV.Rows.Add(newId, customerName, serviceName, SWPriceTb.Text);

            
            Grdtotal += Convert.ToInt32(SWPriceTb.Text);
            TotalLbl.Text = "BDT " + Grdtotal;
        }
    }
}
