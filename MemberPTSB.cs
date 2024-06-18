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
    public partial class MemberPTSB : Form
    {

        public static string gymID;
        public static string MemberID;
        public static string TrainerID;



        public MemberPTSB()
        {
            InitializeComponent();
 



        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

             TrainerID = comboBox1.Text; 

            SqlCommand cm;
            string query;
            

            query = "select UserName from Trainer where TrainerId = @id";
            cm = new SqlCommand(query, conn);

            cm.Parameters.AddWithValue("@id", TrainerID );
            SqlDataReader da2 = cm.ExecuteReader();

            while (da2.Read())
            {
                // MessageBox.Show(da2.GetValue(0).ToString() );
                label5.Text = da2.GetValue(0).ToString(); 
                break;
            }

            conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void MemberPTSB_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;"))
            {
                conn.Open();
                 gymID = MembernewLogin.GymID;
               // MessageBox.Show(gymID); 
                 MemberID = MembernewLogin.MemberID;

                // Create SqlCommand
                using (SqlCommand cm = new SqlCommand("SELECT TrainerID FROM Worksin WHERE GymId = @id", conn))
                {
                    // Add parameter for GymID
                    cm.Parameters.AddWithValue("@id", gymID);

                    // Execute the query and retrieve TrainerID
                    using (SqlDataReader da = cm.ExecuteReader())
                    {
                        // Loop through the SqlDataReader to populate the comboBox
                        while (da.Read())
                        {
                            // Add TrainerID to the comboBox
                            comboBox1.Items.Add(da["TrainerID"].ToString());
                        }
                    }
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            // insert data in the appointment table . 
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

             TrainerID = comboBox1.Text;
            int maxAppointmentID = -1; // Initialize with a default value

            // SQL query to select the maximum AppointmentID
            string query = "SELECT MAX(AppointmentID) FROM Appointments";
          

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Execute the query and retrieve the maximum AppointmentID
                object result = cmd.ExecuteScalar();

                // Check if the result is not null and convert it to an integer
                if (result != null && result != DBNull.Value)
                {
                    maxAppointmentID = Convert.ToInt32(result);
                }
            }

            // now insert the data. 
            maxAppointmentID += 1;
            query = "INSERT INTO Appointments (AppointmentID, MemberID, TrainerID, Duration, Status, AppointmentDate) VALUES(@AppointmentID, @MemberID, @TrainerID, @Duration, @Status, @AppointmentDate)";

          //  MessageBox.Show(maxAppointmentID.ToString());
          //  MessageBox.Show(MemberID.ToString()); 

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {

                cmd.Parameters.AddWithValue ("@AppointmentID",maxAppointmentID );
                cmd.Parameters.AddWithValue("@MemberID", MemberID );
                cmd.Parameters.AddWithValue("@TrainerID" , TrainerID );
                cmd.Parameters.AddWithValue("@Duration" , textBox3.Text);
                cmd.Parameters.AddWithValue("@Status", "Hold" );

                cmd.Parameters.AddWithValue("@AppointmentDate" , textBox4.Text );
                cmd.ExecuteNonQuery(); 


            }

            MessageBox.Show("Appointment Booked");


            conn.Close();
            Hide();
            using ( MemberOptions form2 = new MemberOptions())
                form2.ShowDialog();
            Show();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
