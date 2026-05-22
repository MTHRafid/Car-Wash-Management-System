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
    public partial class Customers : Form
    {
        private string connectionString = "data Source=MTHRAFID\\SQLEXPRESS;database=Car Wash;integrated Security=True;";
        private string originalName = "";
        private string originalPhone = "";
        private string originalModel = "";

        public Customers()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    
                    string query = @"SELECT 
                            ROW_NUMBER() OVER (ORDER BY CId) as ID,
                            CName as Name, 
                            CPhone as Contact,
                            CCar as [Car Model],
                            CAdd as Address,
                            CStatus as Status
                            FROM CustomersTable 
                            ORDER BY CId";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    CustomerDGV.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            CNameTb.Text = "";
            CPhoneTb.Text = "";
            CAddTb.Text = "";
            CStatusCb.SelectedIndex = -1;
            CCarTb.Text = "";
            originalName = "";
            originalPhone = "";
            originalModel = "";
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CNameTb.Text) || string.IsNullOrEmpty(CPhoneTb.Text) ||
                string.IsNullOrEmpty(CAddTb.Text) || string.IsNullOrEmpty(CCarTb.Text) || CStatusCb.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    
                    string insertQuery = "INSERT INTO CustomersTable (CName, CPhone, CCar, CAdd, CStatus) VALUES (@Name, @Phone, @Model, @Address, @Status)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                    insertCmd.Parameters.AddWithValue("@Name", CNameTb.Text);
                    insertCmd.Parameters.AddWithValue("@Phone", CPhoneTb.Text);
                    insertCmd.Parameters.AddWithValue("@Model", CCarTb.Text);
                    insertCmd.Parameters.AddWithValue("@Address", CAddTb.Text);
                    insertCmd.Parameters.AddWithValue("@Status", CStatusCb.SelectedItem.ToString());

                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show("Customer saved successfully!");
                    LoadCustomers();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving Customer: " + ex.Message);
            }
        }

        private void CustomerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < CustomerDGV.Rows.Count)
            {
                DataGridViewRow row = CustomerDGV.Rows[e.RowIndex];

                if (row.Cells["Name"].Value != null && row.Cells["Contact"].Value != null)
                {
                    originalName = row.Cells["Name"].Value.ToString();
                    originalPhone = row.Cells["Contact"].Value.ToString();
                    originalModel = row.Cells["Car Model"].Value.ToString();

                    CNameTb.Text = originalName;
                    CPhoneTb.Text = originalPhone;
                    CCarTb.Text = originalModel;
                    CAddTb.Text = row.Cells["Address"].Value?.ToString() ?? "";

                    string Status = row.Cells["Status"].Value?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(Status))
                    {
                        CStatusCb.SelectedItem = Status;
                    }

                    row.Selected = true;
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(originalName) || string.IsNullOrEmpty(originalPhone))
            {
                MessageBox.Show("Please select a customer first");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete {originalName}?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM CustomersTable WHERE CName=@Name AND CPhone=@Phone";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@Name", originalName);
                        cmd.Parameters.AddWithValue("@Phone", originalPhone);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer deleted successfully!");
                            LoadCustomers();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Customer not found");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting Customer: " + ex.Message);
                }
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(originalName) || string.IsNullOrEmpty(originalPhone))
            {
                MessageBox.Show("Please select a customer to edit");
                return;
            }

            if (string.IsNullOrEmpty(CNameTb.Text) || string.IsNullOrEmpty(CPhoneTb.Text) || string.IsNullOrEmpty(CCarTb.Text) || string.IsNullOrEmpty(CAddTb.Text) || CStatusCb.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string updateQuery = @"UPDATE CustomersTable 
                                SET CName=@NewName, CPhone=@NewPhone, CCar=@NewCar, CStatus=@NewStatus, CAdd=@NewAddress 
                                WHERE CName=@OriginalName AND CPhone=@OriginalPhone";

                    SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                    updateCmd.Parameters.AddWithValue("@NewName", CNameTb.Text);
                    updateCmd.Parameters.AddWithValue("@NewPhone", CPhoneTb.Text);
                    updateCmd.Parameters.AddWithValue("@NewCar", CCarTb.Text);
                    updateCmd.Parameters.AddWithValue("@NewStatus", CStatusCb.SelectedItem.ToString());
                    updateCmd.Parameters.AddWithValue("@NewAddress", CAddTb.Text);
                    updateCmd.Parameters.AddWithValue("@OriginalName", originalName);
                    updateCmd.Parameters.AddWithValue("@OriginalPhone", originalPhone);

                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Customer updated successfully!");
                        LoadCustomers();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Customer not found or no changes made");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Customer: " + ex.Message);
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Start_Wash Obj = new Start_Wash();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Start_Wash Obj = new Start_Wash();
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Invoice Obj = new Invoice();
            Obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Invoice Obj = new Invoice();
            Obj.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
