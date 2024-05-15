using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace ACT1E_CRUD
{
    public partial class Admin : Form
    {
        private MySqlConnection connection;
        public Admin()
        {
            InitializeComponent();
            connection = new MySqlConnection("server=localhost;database;=solivendb;username=root;password=;");
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            loaddata();
        }
        private void loaddata()
        {
            try
            {
                connection.Open();
                string showallrecords = "SELECT ID, name, username, role FROM users ORDER BY ID ASC";
                MySqlCommand command = new MySqlCommand(showallrecords, connection);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                //display error
                MessageBox.Show("Error:" + ex.Message);
            }
            finally
            {
                //Close Connection
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtID.Text = row.Cells["ID"].Value.ToString();
                txtName.Text = row.Cells["name"].Value.ToString();
                txtUsername.Text = row.Cells["username"].Value.ToString();
                cbRole.Text = row.Cells["role"].Value.ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string search = txtSearch.Text;
                connection.Open();
                string showallrecords = "SELECT ID, name, username, role FROM users WEHRE ID LIKE CONCAT('%', @search, '%') OR name LIKE CONCAT('%', @search, '%') OR username LIKE CONCAT('%', @search, '%') 
                MySqlCommand command = new MySqlCommand(showallrecords, connection0);
            }
        }
    }
}
