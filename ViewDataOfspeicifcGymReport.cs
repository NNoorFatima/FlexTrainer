using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace DB_forms
{
    public partial class ViewDataOfspeicifcGymReport : Form
    {
        public ViewDataOfspeicifcGymReport()
        {
            InitializeComponent();
        }
        private void DisplayDataInLabel()
        {

            // Define your connection string
            string connectionString = "Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;";

            // Define the selected admin ID from the combo box
            string gymid = comboBox1.Text;

            string query = "SELECT G.GymID,G.Location,G.Facilities,G.AdminId,G.ActiveStatus,O.Username,O.Email FROM Gym G JOIN admins O ON G.adminId = O.adminid WHERE G.GymID = @gymid; ";


            // Create a SqlConnection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a SqlCommand object with your query and the connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the AdminID parameter to the SqlCommand
                    command.Parameters.AddWithValue("@gymid", comboBox1.Text);

                    // Open the connection
                    connection.Open();

                    // Execute the query and retrieve the data
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if data is retrieved
                        if (reader.Read())
                        {
                            label1.Text = $"Gym ID: {reader["GymID"]}, " +
                            $"Location: {reader["Location"]}, " +
                            $"Facilities: {reader["Facilities"]}, " +
                            $"Admin ID: {reader["AdminId"]}, " +
                            $"Active Status: {reader["ActiveStatus"]}, " +
                            $"Owner Username: {reader["Username"]}";
                        }
                        else
                        {
                            // If no data is retrieved, display a message
                            label1.Text = "No information found";
                        }
                    }

                    // Close the connection
                    connection.Close();
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayDataInLabel();
        }

        private void ViewDataOfspeicifcGymReport_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();
            string adid = "";
            string query;
            SqlCommand cm;

            query = "SELECT distinct(gymid) FROM gym where AdminId =@adid";

            cm = new SqlCommand(query, conn);
            cm.Parameters.AddWithValue("@adid", adminlogin.AdminID);


            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    comboBox1.Items.Add(da["gymid"].ToString());
                }
            }

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
