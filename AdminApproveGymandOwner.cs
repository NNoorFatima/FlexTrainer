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
    public partial class AdminApproveGymandOwner : Form
    {
        public static string ownerid;
        public AdminApproveGymandOwner()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void AdminApproveGymandOwner_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True");
            conn.Open();


            SqlCommand cm;
            string query;
            query = "select Owner_email from Registration where Admin_ID=@adid";
            cm = new SqlCommand(query, conn);
            cm.Parameters.AddWithValue("@adid", adminlogin.AdminID);


            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    comboBox1.Items.Add(da["Owner_email"].ToString());
                }
            }

            conn.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayDataInLabel();
        }

        private void DisplayDataInLabel()
        {
            // Define your connection string
            string connectionString = "Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True";

            // Define the email selected in the comboBox
            string email = comboBox1.Text;

            // Define your SQL query
            string query = "SELECT Location,Facilities FROM Registration WHERE Owner_email = @Email";

            // Create a SqlConnection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a SqlCommand object with your query and the connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the email parameter to the SqlCommand
                    command.Parameters.AddWithValue("@Email", email);

                    // Open the connection
                    connection.Open();

                    // Execute the query and retrieve the data
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if data is retrieved
                        if (reader.Read())
                        {
                            // Retrieve the values from the reader and set them to the respective labels
                            label4.Text = reader["Location"].ToString();
                            label6.Text = reader["Facilities"].ToString();
                        }
                        else
                        {
                            // If no data is retrieved, display a message
                            label4.Text = "No data found";
                            label6.Text = "No data found";
                        }
                    }

                    // Close the connection
                    connection.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InsertIntoOwnerTable()
        {
            // Define your connection string
            string connectionString = "Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True";

            // Define the email selected in the comboBox
            string email = comboBox1.Text;

            // Define your SQL query to retrieve the Username and Owner_password from the Registration table based on the selected email
            string userInfoQuery = "SELECT Username, Owner_password FROM Registration WHERE Owner_email = @Email";

            // Define your SQL query to retrieve the maximum value of OwnerID
            string maxQuery = "SELECT MAX(CAST(RIGHT(OwnerID, LEN(OwnerID) - 4) AS INT)) FROM Owners";

            // Define your SQL query to insert data into Owner table
            string insertQuery = "INSERT INTO Owners (OwnerID, Username, Owner_password, Email,Status) VALUES (@OwnerID, @Username, @Owner_password, @Email, @Status)";

            // Create a SqlConnection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a SqlCommand object with the userInfoQuery and the connection
                using (SqlCommand userInfoCommand = new SqlCommand(userInfoQuery, connection))
                {
                    // Add the email parameter to the SqlCommand
                    userInfoCommand.Parameters.AddWithValue("@Email", email);

                    // Open the connection
                    connection.Open();

                    // Execute the userInfoQuery and retrieve the Username and Owner_password
                    using (SqlDataReader reader = userInfoCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string username = reader["Username"].ToString();
                            string ownerPassword = reader["Owner_password"].ToString();

                            // Close the connection
                            connection.Close();

                            // Create a SqlCommand object with the maxQuery and the connection
                            using (SqlCommand maxCommand = new SqlCommand(maxQuery, connection))
                            {
                                // Open the connection
                                connection.Open();

                                // Execute the maxQuery and retrieve the maximum value of OwnerID
                                object maxResult = maxCommand.ExecuteScalar();

                                // Close the connection
                                connection.Close();

                                // Calculate the new OwnerID
                                int nextID = 0;
                                if (maxResult != DBNull.Value)
                                {
                                    nextID = Convert.ToInt32(maxResult) + 1;
                                }
                                string newOwnerID = "22o-" + nextID.ToString();
                                ownerid = newOwnerID;
                                // Create a SqlCommand object with the insertQuery and the connection
                                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                                {
                                    // Add parameters to the insert command
                                    insertCommand.Parameters.AddWithValue("@OwnerID", newOwnerID);
                                    insertCommand.Parameters.AddWithValue("@Username", username);
                                    insertCommand.Parameters.AddWithValue("@Owner_password", ownerPassword);
                                    insertCommand.Parameters.AddWithValue("@Email", email);
                                    insertCommand.Parameters.AddWithValue("@Status", "Approved");
                                    //  insertCommand.Parameters.AddWithValue("@OtherValues", "Other values here");

                                    // Open the connection
                                    connection.Open();

                                    // Execute the insert command
                                    insertCommand.ExecuteNonQuery();
                                    MessageBox.Show("Owner inserted successfully.");
                                    // Close the connection
                                    connection.Close();
                                }
                            }
                        }
                        else
                        {
                            // If no data is retrieved, display a message or handle the case accordingly
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertIntoOwnerTable();

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True");
            conn.Open();
            //  MessageBox.Show("Connection Open");

            SqlCommand cmd;
            string ownerID = ownerid; // Assuming OwnerIDVariable holds the OwnerID
            string adminID = adminlogin.AdminID; // Assuming AdminIDVariable holds the AdminID
            string email = comboBox1.Text; // Assuming comboBox1 holds the selected email

            // Query to retrieve location and facilities based on the selected email
            string registrationInfoQuery = "SELECT Location, Facilities FROM Registration WHERE Owner_email = @Email";

            cmd = new SqlCommand(registrationInfoQuery, conn);
            cmd.Parameters.AddWithValue("@Email", email);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string location = reader["Location"].ToString();
                string facilities = reader["Facilities"].ToString();

                // Close the reader before executing the next command
                reader.Close();

                // Query to retrieve the maximum GymID
                string maxGymIDQuery = "SELECT ISNULL(MAX(CAST(SUBSTRING(GymID, 5, LEN(GymID) - 4) AS INT)), 0) FROM Gym";

                cmd = new SqlCommand(maxGymIDQuery, conn);
                int nextGymID = (int)cmd.ExecuteScalar() + 1;

                string gymID = "22g-" + nextGymID.ToString("D3");

                // Query to insert data into the Gym table
                string insertGymQuery = "INSERT INTO Gym (GymID, Location, Facilities, OwnerID, AdminID, ActiveStatus) " +
                                        "VALUES (@GymID, @Location, @Facilities, @OwnerID, @AdminID, @ActiveStatus)";

                cmd = new SqlCommand(insertGymQuery, conn);
                cmd.Parameters.AddWithValue("@GymID", gymID);
                cmd.Parameters.AddWithValue("@Location", location);
                cmd.Parameters.AddWithValue("@Facilities", facilities);
                cmd.Parameters.AddWithValue("@OwnerID", ownerID);
                cmd.Parameters.AddWithValue("@AdminID", adminID);
                cmd.Parameters.AddWithValue("@ActiveStatus", "Approved");

                // Execute the insertion query
                cmd.ExecuteNonQuery();

                MessageBox.Show("Gym inserted successfully. GymID: " + gymID);
            }
            else
            {
                MessageBox.Show("No data found for the selected email.");
            }

            cmd.Dispose();
            conn.Close();
            string emailToDelete = comboBox1.Text; // Assuming comboBox1 holds the selected email
            DeleteRecordFromRegistration(emailToDelete);

        }

        private void DeleteRecordFromRegistration(string emailToDelete)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True");
            conn.Open();
            // MessageBox.Show("Connection Open");

            SqlCommand cmd;

            // Query to delete record from Registration table based on email
            string deleteQuery = "DELETE FROM Registration WHERE Owner_email = @Email";

            cmd = new SqlCommand(deleteQuery, conn);
            cmd.Parameters.AddWithValue("@Email", emailToDelete);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Record deleted successfully for email: " + emailToDelete);
            }
            else
            {
                MessageBox.Show("No record found for the selected email.");
            }

            cmd.Dispose();
            conn.Close();
            this.Close();
        }
    }
}
