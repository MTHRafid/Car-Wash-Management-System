using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Employees : Form
    {
        private string connectionString = "data Source=MTHRAFID\\SQLEXPRESS;database=Car Wash;integrated Security=True;";
        private string originalName = "";
        private string originalPhone = "";

        public Employees()
        {
            InitializeComponent();
            LoadEmployees();
            RenumberEmployeeIds();
           
        }

        private void LoadEmployees()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    
                    string query = @"SELECT 
                            ROW_NUMBER() OVER (ORDER BY EId) as ID,
                            EName as Name, 
                            EPhone as Phone,
                            EGen as Gender,
                            EAdd as Address 
                            FROM EmployeeTable 
                            ORDER BY EId";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    EmployeeDGV.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employees: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            ENameTb.Text = "";
            EPhoneTb.Text = "";
            EAddTb.Text = "";
            EGenCb.SelectedIndex = -1;
            originalName = "";
            originalPhone = "";
        }


        private void RenumberEmployeeIds()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    
                    string selectQuery = "SELECT EName, EPhone, EGen, EAdd, EPass FROM EmployeeTable ORDER BY EId";
                    SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    
                    string deleteQuery = "DELETE FROM EmployeeTable";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, con);
                    deleteCmd.ExecuteNonQuery();

                    
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string insertQuery = "INSERT INTO EmployeeTable (EName, EPhone, EGen, EAdd, EPass) VALUES (@Name, @Phone, @Gender, @Address, @Password)";
                        SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                        insertCmd.Parameters.AddWithValue("@Name", dt.Rows[i]["EName"]);
                        insertCmd.Parameters.AddWithValue("@Phone", dt.Rows[i]["EPhone"]);
                        insertCmd.Parameters.AddWithValue("@Gender", dt.Rows[i]["EGen"]);
                        insertCmd.Parameters.AddWithValue("@Address", dt.Rows[i]["EAdd"]);
                        insertCmd.Parameters.AddWithValue("@Password", dt.Rows[i]["EPass"]);
                        insertCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error renumbering employee IDs: " + ex.Message);
            }
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ENameTb.Text) || string.IsNullOrEmpty(EPhoneTb.Text) ||
                string.IsNullOrEmpty(EAddTb.Text) || EGenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    
                    string insertQuery = "INSERT INTO EmployeeTable (EName, EPhone, EGen, EAdd, EPass) VALUES (@Name, @Phone, @Gender, @Address, @New_Password)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                    insertCmd.Parameters.AddWithValue("@Name", ENameTb.Text);
                    insertCmd.Parameters.AddWithValue("@Phone", EPhoneTb.Text);
                    insertCmd.Parameters.AddWithValue("@Gender", EGenCb.SelectedItem.ToString());
                    insertCmd.Parameters.AddWithValue("@Address", EAddTb.Text);
                    insertCmd.Parameters.AddWithValue("@New_Password", EPassTb.Text);
                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show("Employee saved successfully!");
                    LoadEmployees();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving employee: " + ex.Message);
            }
        }

        private void EmployeeDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < EmployeeDGV.Rows.Count)
            {
                DataGridViewRow row = EmployeeDGV.Rows[e.RowIndex];

                if (row.Cells["Name"].Value != null && row.Cells["Phone"].Value != null)
                {
                    originalName = row.Cells["Name"].Value.ToString();
                    originalPhone = row.Cells["Phone"].Value.ToString();

                    ENameTb.Text = originalName;
                    EPhoneTb.Text = originalPhone;
                    EAddTb.Text = row.Cells["Address"].Value?.ToString() ?? "";

                    string gender = row.Cells["Gender"].Value?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(gender))
                    {
                        EGenCb.SelectedItem = gender;
                    }

                    row.Selected = true;
                }
            }
        }

        private void EditBtn_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(originalName) || string.IsNullOrEmpty(originalPhone))
            {
                MessageBox.Show("Please select an employee to edit");
                return;
            }

            if (string.IsNullOrEmpty(ENameTb.Text) || string.IsNullOrEmpty(EPhoneTb.Text) ||
                string.IsNullOrEmpty(EAddTb.Text) || EGenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string updateQuery = @"UPDATE EmployeeTable 
                                        SET EName=@NewName, EPhone=@NewPhone, EGen=@NewGender, EAdd=@NewAddress, EPass=@New_Password
                                        WHERE EName=@OriginalName AND EPhone=@OriginalPhone";

                    SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                    updateCmd.Parameters.AddWithValue("@NewName", ENameTb.Text);
                    updateCmd.Parameters.AddWithValue("@NewPhone", EPhoneTb.Text);
                    updateCmd.Parameters.AddWithValue("@NewGender", EGenCb.SelectedItem.ToString());
                    updateCmd.Parameters.AddWithValue("@NewAddress", EAddTb.Text);
                    updateCmd.Parameters.AddWithValue("@New_Password", EPassTb.Text);
                    updateCmd.Parameters.AddWithValue("@OriginalName", originalName);
                    updateCmd.Parameters.AddWithValue("@OriginalPhone", originalPhone);

                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Employee updated successfully!");
                        LoadEmployees();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Employee not found or no changes made");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating employee: " + ex.Message);
            }
        }

        private void DeleteBtn_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(originalName) || string.IsNullOrEmpty(originalPhone))
            {
                MessageBox.Show("Please select an employee first");
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
                        string query = "DELETE FROM EmployeeTable WHERE EName=@Name AND EPhone=@Phone";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@Name", originalName);
                        cmd.Parameters.AddWithValue("@Phone", originalPhone);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Employee deleted successfully!");
                            
                            RenumberEmployeeIds();
                            LoadEmployees();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Employee not found");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting employee: " + ex.Message);
                }
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void panel4_Paint(object sender, PaintEventArgs e) { }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
           
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

        private void label1_Click(object sender, EventArgs e)
        {
            Invoice Obj = new Invoice();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Invoice Obj = new Invoice();
            Obj.Show();
            this.Hide();
        }
    }
}
