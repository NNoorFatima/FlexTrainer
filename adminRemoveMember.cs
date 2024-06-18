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
    public partial class adminRemoveMember : Form
    {
        public static string gymid;
        public static string memid;
        public adminRemoveMember()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void adminRemoveMember_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            SqlCommand cm;
            string query;

             string gymid = comboBox2.Text;
             // query = "select GymID from Gym where ownerId=@ownid";
             query = "select Distinct(Remove_Member.GymId) from Remove_Member join gym on Remove_Member.GymId=Gym.GymId where Gym.AdminID=@adid";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gymID = comboBox1.Text;  //yeh gym id hai 

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            SqlCommand cm;
            string query;

            /*            string gymid = comboBox2.Text;*/
            query = "select MemberID from Remove_Member where GymId=@gymid";

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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();
            
            
            SqlCommand cm, cm1;
            string query;
            string query1;
            memid = comboBox2.Text;
            gymid = comboBox1.Text;

            query = "Delete from Members where MemberId=@memid";
            query1 = "Delete from Remove_Member where MemberId=@memid and GymId=@gymid";
            cm = new SqlCommand(query, conn);
            cm1 = new SqlCommand(query1, conn);
            cm.Parameters.AddWithValue("@memid", memid);
            cm1.Parameters.AddWithValue("@memid", memid);
            cm1.Parameters.AddWithValue("@gymid", gymid);
            cm.ExecuteNonQuery();
            cm.Dispose();
            cm1.ExecuteNonQuery();
            cm1.Dispose();
            conn.Close();


            MessageBox.Show("Member revoked.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
