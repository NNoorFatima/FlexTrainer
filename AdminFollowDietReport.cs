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
    public partial class AdminFollowDietReport : Form
    {
        public AdminFollowDietReport()
        {
            InitializeComponent();
            showDataPlan();
            this.Size = new Size(600, 500);
        }
        private void showDataPlan()
        {

            SqlDataAdapter adpt;
            string tranid;
            string gymid;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True");
            conn.Open();

            //SqlCommand cm;
            string query;
            //  string gymid;
            // planID = 0;
            query = "select dietPlan.PlanName,memberfollowplan.DietPlanID,memberfollowplan.MemberID from memberfollowplan join dietplan on memberfollowplan.dietplanid=dietplan.dietplanid where  MemberID in (select MemberID from members  join gym on Members.GymID=Gym.GymID join WorksIn on gym.GymID= WorksIn.GymID where Worksin.GymID=@gymid and worksin.TrainerID=@tranid)";

            DataTable dt = new DataTable();
            adpt = new SqlDataAdapter(query, conn);
            adpt.SelectCommand.Parameters.AddWithValue("@gymid", AdminFollowDiet.gymid);
            adpt.SelectCommand.Parameters.AddWithValue("@tranid", AdminFollowDiet.trainerid);
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;




        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            showDataPlan();
        }
    }
}
