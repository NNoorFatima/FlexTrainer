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
    public partial class GymRemoveTrainer : Form
    {
        public static string trainerid;
        public static string gymid;
        public GymRemoveTrainer()
        {
            InitializeComponent();
        }

        private void GymRemoveTrainer_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            SqlCommand cm,cm1;
            string query,query1;
            //string ownid;
            query = "select TrainerId from WorksIn where OwnerID=@ownid";
            query1 = "select GymId from Gym where OwnerID=@ownid";
            cm = new SqlCommand(query, conn);
            cm1 = new SqlCommand(query1, conn);
            cm.Parameters.AddWithValue("@ownid", GymLogin.OwnerId);
            cm1.Parameters.AddWithValue("@ownid", GymLogin.OwnerId);

            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    comboBox1.Items.Add(da["TrainerId"].ToString());
                }
            }
            using (SqlDataReader da1 = cm1.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da1.Read())
                {
                    // Add GymID to the comboBox
                    comboBox2.Items.Add(da1["GymID"].ToString());
                }
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True");
            conn.Open();
            SqlCommand cm;
            trainerid = comboBox1.Text;
            gymid = comboBox2.Text;
            string query = "Insert into Remove_Trainer(TrainerID,OwnerID,GymID) values ('" + trainerid + "','" + GymLogin.OwnerId + "','" + gymid + "') ";
            cm = new SqlCommand(query, conn);
            cm.ExecuteNonQuery();
            cm.Dispose();
            conn.Close();

            MessageBox.Show("Trainer added to removal table.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
