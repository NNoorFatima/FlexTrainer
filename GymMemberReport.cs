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
    public partial class GymMemberReport : Form
    {

        public static string MemId = "";
        public GymMemberReport()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            MemId = comboBox2.Text;
            Hide();
            using (GymOwnerMemberReports form2 = new GymOwnerMemberReports())
                form2.ShowDialog();
            Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void GymMemberReport_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True");
            conn.Open();
            SqlCommand cm;
            string query;
            string ownid;
            query = "select Gymid from gym where ownerid =@owid";

            //   query = "select GymID from Gym";
            cm = new SqlCommand(query, conn);
            cm.Parameters.AddWithValue("@owid", GymLogin.OwnerId);


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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gymID = comboBox1.Text;  //yeh gym id hai 

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True");
            conn.Open();


            SqlCommand cm;
            string query;

            /*            string gymid = comboBox2.Text;*/
            query = "select MemberID from Members where GymId=@gymid";

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
                    comboBox2.Items.Add(da["MemberID"].ToString());

                }
            }
        }
    }
}
