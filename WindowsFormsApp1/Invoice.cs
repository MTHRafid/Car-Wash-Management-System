using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Invoice : Form
    {
        private string connectionString = @"Data Source=MTHRafid;Initial Catalog=""Car Wash"";Persist Security Info=True;User ID=Rafid;Password=rafid2003;Encrypt=False";

        public Invoice()
        {
            InitializeComponent();
            LoadInvoices();
        }

        private void LoadInvoices()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    
                    string query = @"SELECT 
                            ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) as [Invoice Number],
                            SWCustomerName as [Customer Name], 
                            SWPhone as [Customer Phone],
                            EName as Employee,
                            Amt as [Total Amount],
                            IDate as Date
                            FROM InvoiceTable 
                            ORDER BY IDate DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    InvoiceDGV.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading invoices: " + ex.Message);
            }
        }

        private void InvoiceDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void DeleteInvoiceBtn_Click(object sender, EventArgs e)
        {
            if (InvoiceDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an invoice to delete");
                return;
            }

            try
            {
               
                DataGridViewRow selectedRow = InvoiceDGV.SelectedRows[0];
                string customerName = selectedRow.Cells["Customer Name"].Value?.ToString();
                string customerPhone = selectedRow.Cells["Customer Phone"].Value?.ToString();
                string employeeName = selectedRow.Cells["Employee"].Value?.ToString();
                string totalAmount = selectedRow.Cells["Total Amount"].Value?.ToString();
                string invoiceDate = selectedRow.Cells["Date"].Value?.ToString();

               
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete invoice for {customerName}?\n" +
                    $"Date: {invoiceDate}\nAmount: {totalAmount}",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        
                        string query = @"DELETE FROM InvoiceTable 
                               WHERE SWCustomerName=@CustomerName 
                               AND SWPhone=@CustomerPhone 
                               AND EName=@EmployeeName 
                               AND Amt=@Amount 
                               AND IDate=@InvoiceDate";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@CustomerName", customerName);
                        cmd.Parameters.AddWithValue("@CustomerPhone", customerPhone);
                        cmd.Parameters.AddWithValue("@EmployeeName", employeeName);
                        cmd.Parameters.AddWithValue("@Amount", Convert.ToInt32(totalAmount));
                        cmd.Parameters.AddWithValue("@InvoiceDate", Convert.ToDateTime(invoiceDate));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Invoice deleted successfully!");
                            LoadInvoices(); 
                        }
                        else
                        {
                            MessageBox.Show("Invoice not found");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting invoice: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
