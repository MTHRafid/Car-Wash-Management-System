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
    public partial class Services : Form
    {
        private string connectionString = "data Source=MTHRAFID\\SQLEXPRESS;database=Car Wash;integrated Security=True;";
        private string originalName = "";
        private string originalPrice = "";

        public Services()
        {
            InitializeComponent();
            LoadServices();
        }

        private void LoadServices()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    
                    string query = @"SELECT 
                            ROW_NUMBER() OVER (ORDER BY SId) as ID,
                            SName as Name, 
                            SPrice as Price 
                            FROM ServiceTable 
                            ORDER BY SId";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ServiceDGV.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Services: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            SNameTb.Text = "";
            SPriceTb.Text = "";
            originalName = "";
            originalPrice = "";
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SNameTb.Text) || string.IsNullOrEmpty(SPriceTb.Text))
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                   
                    string insertQuery = "INSERT INTO ServiceTable (SName, SPrice) VALUES (@Name, @Price)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                    insertCmd.Parameters.AddWithValue("@Name", SNameTb.Text);
                    insertCmd.Parameters.AddWithValue("@Price", SPriceTb.Text);
                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show("Service saved successfully!");
                    LoadServices();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving Service: " + ex.Message);
            }
        }

        private void ServiceDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < ServiceDGV.Rows.Count)
            {
                DataGridViewRow row = ServiceDGV.Rows[e.RowIndex];

                if (row.Cells["Name"].Value != null && row.Cells["Price"].Value != null)
                {
                    originalName = row.Cells["Name"].Value.ToString();
                    originalPrice = row.Cells["Price"].Value.ToString();

                    SNameTb.Text = originalName;
                    SPriceTb.Text = originalPrice;

                    row.Selected = true;
                }
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(originalName) || string.IsNullOrEmpty(originalPrice))
            {
                MessageBox.Show("Please select a service to edit");
                return;
            }

            if (string.IsNullOrEmpty(SNameTb.Text) || string.IsNullOrEmpty(SPriceTb.Text))
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string updateQuery = @"UPDATE ServiceTable 
                                SET SName=@NewName, SPrice=@NewPrice 
                                WHERE SName=@OriginalName AND SPrice=@OriginalPrice";

                    SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                    updateCmd.Parameters.AddWithValue("@NewName", SNameTb.Text);
                    updateCmd.Parameters.AddWithValue("@NewPrice", SPriceTb.Text);
                    updateCmd.Parameters.AddWithValue("@OriginalName", originalName);
                    updateCmd.Parameters.AddWithValue("@OriginalPrice", originalPrice);

                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Service updated successfully!");
                        LoadServices();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Service not found or no changes made");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Service: " + ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(originalName) || string.IsNullOrEmpty(originalPrice))
            {
                MessageBox.Show("Please select a service first");
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
                        string query = "DELETE FROM ServiceTable WHERE SName=@Name AND SPrice=@Price";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@Name", originalName);
                        cmd.Parameters.AddWithValue("@Price", originalPrice);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Service deleted successfully!");
                            LoadServices();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Service not found");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting Service: " + ex.Message);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
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













