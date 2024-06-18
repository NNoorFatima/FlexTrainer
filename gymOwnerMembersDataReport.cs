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
    public partial class gymOwnerMembersDataReport : Form
    {
        public gymOwnerMembersDataReport()
        {
            InitializeComponent();
            showDataPlan();
            this.Size = new Size(300, 300);
        }
        private void showDataPlan()
        {

            SqlDataAdapter adpt;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True");
            conn.Open();

            //SqlCommand cm;
            string query;
            string gymid;
            // planID = 0;
            query = "SELECT COUNT(DISTINCT MemberID) AS TotalMembers FROM Members WHERE GymID = @gymid AND (SELECT DATEDIFF(MONTH, Reg_Date, GETDATE()) AS MonthsAgo) <=3;";

            //cm = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            adpt = new SqlDataAdapter(query, conn);
            adpt.SelectCommand.Parameters.AddWithValue("@gymid", gymOwnerMembersData.gymid);
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;



        }
        private void gymOwnerMembersDataReport_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            showDataPlan();
        }
    }
}
