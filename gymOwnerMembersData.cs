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
    public partial class gymOwnerMembersData : Form
    {
        public static string gymid;
        public gymOwnerMembersData()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gymOwnerMemberData_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True");
            conn.Open();


            SqlCommand cm;
            string query;
            string owid;
            query = "select GymID from Gym where OwnerID=@owid";
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

        private void button1_Click(object sender, EventArgs e)
        {
            gymid = comboBox1.Text;
            Hide();
            using (gymOwnerMembersDataReport form2 = new gymOwnerMembersDataReport())
            {
                form2.ShowDialog();
            }
            Show();
            this.Close();
        }
    }
}
