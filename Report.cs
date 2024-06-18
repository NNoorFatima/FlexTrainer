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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DB_forms
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        private void DisplayDataInLabel()
        {
            // Define your connection string
            string connectionString = "Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;";

            // Define the selected admin ID from the combo box
            string trainerid = comboBox2.Text;

            string query = "SELECT memberid from appointments where trainerid=@trainerid";

            // Create a SqlConnection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a SqlCommand object with your query and the connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the AdminID parameter to the SqlCommand
                    command.Parameters.AddWithValue("@trainerid", comboBox2.Text);

                    // Open the connection
                    connection.Open();

                    // Execute the query and retrieve the data
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if data is retrieved
                        if (reader.Read())
                        {
                            // Retrieve the value from the reader and set it to the label
                            label1.Text = reader["memberID"].ToString();
                        }
                        else
                        {
                            // If no data is retrieved, display a message
                            label1.Text = "No member found";
                        }
                    }

                    // Close the connection
                    connection.Close();
                }
            }
        }

        private void Report_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

            string adid;
            SqlCommand cm;
            string query;


            query = "select distinct(gymid) from gym where adminid=@adid;";

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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayDataInLabel();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string gymID = comboBox1.Text;  //yeh gym id hai 

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");

            conn.Open(); 
            SqlCommand cm;
            string query;

            /*            string gymid = comboBox2.Text;*/
            query = "SELECT DISTINCT(TrainerID) FROM worksin WHERE gymid=@gymID";

            cm = new SqlCommand(query, conn);
            cm.Parameters.AddWithValue("@gymid", gymID);


            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox

                comboBox2.Items.Clear();
                while (da.Read())
                {

                    // Add GymID to the comboBox
                    comboBox2.Items.Add(da["TrainerID"].ToString());
                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            using (AdminOptions form2 = new AdminOptions())
            {
                form2.ShowDialog();
            }
            Show();
        }
    }
}
