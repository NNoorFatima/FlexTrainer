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
    public partial class GymOwnerMemberReports : Form
    {
        public GymOwnerMemberReports()
        {
            InitializeComponent();
            showDataPlan();
            this.Size = new Size(1400, 300);
        }
        private void showDataPlan()
        {

            SqlDataAdapter adpt;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True");
            conn.Open();

            //SqlCommand cm;
            string query;
            // planID = 0;

            query = "SELECT * from Members  WHERE MemberID = @id";
            /*    using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MemberID", GymMemberReport.MemId );

                    // Execute the query and retrieve MemberFollowsPlanID and PlanID
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {


                           // planID = reader.GetInt32(0); // Assuming PlanID is stored as int
                        }
                    }
                }



                query = "select * from DietPlan where DietPlanId = @id";
*/

            //cm = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            adpt = new SqlDataAdapter(query, conn);
            adpt.SelectCommand.Parameters.AddWithValue("@id", GymMemberReport.MemId);
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;



        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            showDataPlan();
        }

        private void GymOwnerMemberReports_Load(object sender, EventArgs e)
        {
            showDataPlan();
        }
    }
}
