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
    public partial class GymRemoveMember : Form
    {
        public static string memid;
        public static string gymid;
        public GymRemoveMember()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True");
            conn.Open();

            SqlCommand cm;
            string query;
            memid = comboBox1.Text;
            gymid = comboBox2.Text;
            /*memid = textBox3.Text;
            gymid = textBox1.Text;*/
            query = "Insert into Remove_Member(MemberID,OwnerID,GymID) values ('" + memid + "','" + GymLogin.OwnerId + "','" + gymid + "') ";
            cm = new SqlCommand(query, conn);
            cm.ExecuteNonQuery();
            cm.Dispose();
            conn.Close();


            MessageBox.Show("Member added to removal table.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gymID = comboBox2.Text;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            SqlCommand cm;
            string query;

            /*            string gymid = comboBox2.Text;*/
            query = "select MemberID from Members where GymId=@ownid";

            cm = new SqlCommand(query, conn);
            cm.Parameters.AddWithValue("@ownid", gymID );


            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox

                comboBox1.Items.Clear(); 
                while (da.Read())
                {

                    // Add GymID to the comboBox
                    comboBox1.Items.Add(da["MemberID"].ToString());
                }
            }

            conn.Close();


        }

        private void GymRemoveMember_Load_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            SqlCommand cm;
            string query;

            /*            string gymid = comboBox2.Text;*/
            query = "select GymID from Gym where ownerId=@ownid";

            cm = new SqlCommand(query, conn);
            cm.Parameters.AddWithValue("@ownid", GymLogin.OwnerId);
            //MessageBox.Show(GymLogin.OwnerId);


            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    comboBox2.Items.Add(da["GymID"].ToString());
                }
            }

            conn.Close();
        }
    }
}
