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
    public partial class AdminRevokeGym : Form
    {
        public static string gymid;
        public AdminRevokeGym()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True");
            conn.Open();

            gymid = comboBox1.Text;
            SqlCommand cm;
            string query;
            // query = "select Goal from Workoutplan";
            query = "Delete from Gym where Gymid=@gymid ";
            cm = new SqlCommand(query, conn);
            cm.Parameters.AddWithValue("@gymid", gymid);
            // cm.Parameters.AddWithValue("@AdminID", adminlogin.AdminID);

            int rowsAffected = cm.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("done");
            }
            else
            {
                MessageBox.Show("No record found for the selected GymID.");
            }



            conn.Close();
        }

        private void AdminRevokeGym_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True");
            conn.Open();


            SqlCommand cm;
            string query;

             //string gymid = comboBox2.Text;/
             // query = "select GymID from Gym where ownerId=@ownid";
             query = "select GymID from Gym where Gym.AdminID=@adid";
            cm = new SqlCommand(query, conn);
            cm.Parameters.AddWithValue("@adid", adminlogin.AdminID);
            //MessageBox.Show(GymLogin.OwnerId);


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
    }
}
