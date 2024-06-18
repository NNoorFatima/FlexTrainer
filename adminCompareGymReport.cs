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
    public partial class adminCompareGymReport : Form
    {
        public adminCompareGymReport()
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
            query = "SELECT GymId,COUNT(DISTINCT MemberID) AS TotalMembers FROM Members WHERE  (SELECT DATEDIFF(MONTH, Reg_date, GETDATE()) AS MonthsAgo) >= 6 Group by GymId";

            DataTable dt = new DataTable();
            adpt = new SqlDataAdapter(query, conn);
            //   adpt.SelectCommand.Parameters.AddWithValue("@gymid", adminCompareGym.gymid);
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;



        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            showDataPlan();
        }
    }
}
