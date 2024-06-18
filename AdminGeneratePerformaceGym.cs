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
    public partial class AdminGeneratePerformaceGym : Form
    {
        public AdminGeneratePerformaceGym()
        {
            InitializeComponent();
        }

        private void GeneratePerformaceGym_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True");
            conn.Open();


            SqlCommand cm;
            string adid;
            string query;
            query = "select GymID from Gym where AdminId=@adid";
            cm = new SqlCommand(query, conn);

            cm.Parameters.AddWithValue("@adid", adminlogin.AdminID);
            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    comboBox1.Items.Add(da["GymID"].ToString());
                }
            }

            conn.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True");
            conn.Open();


            SqlCommand cm;
            SqlCommand cm1;

            string gymid = comboBox1.Text;
            string query1, query2;
            query1 = "SELECT  COUNT(*) AS total_members FROM members where gymid =@gymid; ";
            query2 = "SELECT COUNT(DISTINCT Members.MemberID) AS members_dissatisfied_comments FROM Members JOIN feedback ON Members.MemberID = feedback.MemberID WHERE (feedback.Comments LIKE '%Bad%' OR feedback.Comments LIKE '%Strongly Dissatisfied%') and Members.GymID=@gymid;";

            cm = new SqlCommand(query1, conn);
            cm1 = new SqlCommand(query2, conn);
            cm1.Parameters.AddWithValue("@gymid", gymid);
            cm.Parameters.AddWithValue("@gymid", gymid);
            int total_members = (int)cm.ExecuteScalar();
            int diss_customer = (int)cm1.ExecuteScalar();


            if (total_members < 5)
            {
                MessageBox.Show("Very few members in the gym");

            }
            else
            {
                MessageBox.Show("Member count is Just Right :)");

            }
            if (diss_customer > 4)
            {
                MessageBox.Show("Members are not Happy ;(");

            }
            else
            {
                MessageBox.Show("Yay!! Members like the Gym");
            }


            conn.Close();



            // Hide();
            //using (GymReport form2 = new GymReport())
            //  form2.ShowDialog();
            //Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
