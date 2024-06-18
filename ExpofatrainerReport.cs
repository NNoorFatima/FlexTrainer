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
    public partial class ExpofatrainerReport : Form
    {
        public ExpofatrainerReport()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ExpofatrainerReport_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

           // string adid;
            SqlCommand cm;
            string query;

            query = "SELECT w.TrainerId FROM WorksIn w JOIN Gym g ON w.GymId = g.GymID WHERE g.AdminId =@adid";

            cm = new SqlCommand(query, conn);
            cm.Parameters.AddWithValue("@adid", adminlogin.AdminID);


            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    comboBox1.Items.Add(da["trainerId"].ToString());
                }
            }

            conn.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void DisplayDataInLabel()
        {

            // Define your connection string
            string connectionString = "Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True";

            // Define the selected admin ID from the combo box
            string trainerid = comboBox1.Text;

            string query = "SELECT experience from trainer where trainerid=@trainerid";

            // Create a SqlConnection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a SqlCommand object with your query and the connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the AdminID parameter to the SqlCommand
                    command.Parameters.AddWithValue("@trainerid", comboBox1.Text);

                    // Open the connection
                    connection.Open();

                    // Execute the query and retrieve the data
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if data is retrieved
                        if (reader.Read())
                        {
                            // Retrieve the value from the reader and set it to the label
                            label4.Text = reader["Experience"].ToString();
                        }
                        else
                        {
                            // If no data is retrieved, display a message
                            label4.Text = "No experience found";
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            using (AdminOptions form2 = new AdminOptions())
                form2.ShowDialog();
            Show();
        }
    }
}
