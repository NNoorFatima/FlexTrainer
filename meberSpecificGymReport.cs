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
    public partial class meberSpecificGymReport : Form
    {
        public meberSpecificGymReport()
        {
            InitializeComponent();
        }
        private void DisplayDataInLabel()
        {
            string connectionString = "Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;";
            string gymID = comboBox1.Text;
            string dietPlanName = comboBox2.Text;
            string query = "SELECT m.MemberID, m.Username " +
                           "FROM Members m " +
                           "JOIN MemberFollowPlan mf ON m.MemberID = mf.MemberID " +
                           "JOIN DietPlan d ON mf.DietPlanId = d.DietPlanId " +
                           "JOIN Gym g ON m.GymId = g.GymId " +
                           "WHERE d.PlanName = @dietPlanName AND g.GymId = @GymID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DietPlanName", comboBox2.Text);
                    command.Parameters.AddWithValue("@GymID", comboBox1.Text);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            label1.Text = $"Member ID: {reader["MemberID"]}, " +
                                $"Username: {reader["Username"]}";
                        }
                        else
                        {
                            label1.Text = "No member found";
                        }
                    }

                    connection.Close();
                }
            }
        }
        private void meberSpecificGymReport_Load(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gymID = comboBox1.Text;  //yeh gym id hai 
            string Planname = "";
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            SqlCommand cm;
            string query;

            /*            string gymid = comboBox2.Text;*/
            query = "SELECT DISTINCT(PlanName) FROM Dietplan ";

            cm = new SqlCommand(query, conn);
            cm.Parameters.AddWithValue("@Planname", Planname);



            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox

                comboBox2.Items.Clear();
                while (da.Read())
                {

                    // Add GymID to the comboBox
                    comboBox2.Items.Add(da["PlanName"].ToString());
                }

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayDataInLabel();
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
