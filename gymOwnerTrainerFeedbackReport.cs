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
    public partial class gymOwnerTrainerFeedbackReport : Form
    {
        public gymOwnerTrainerFeedbackReport()
        {
            InitializeComponent();
            showDataPlan();
            this.Size = new Size(800, 500);
        }

        private void gymOwnerTrainerFeedbackReport_Load(object sender, EventArgs e)
        {

        }
        private void showDataPlan()
        {

            SqlDataAdapter adpt;
          //  string tranid;
           // string gymid;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True");
            conn.Open();

            //SqlCommand cm;
            string query;
            //  string gymid;
            // planID = 0;
            string owid;
            query = "select trainer.Username,Trainer.trainerid,feedback.Comments,feedback.Rating from WorksIn join trainer on worksin.trainerid = Trainer.TrainerID join feedback on Trainer.TrainerID = feedback.TrainerID where WorksIn.OwnerID = @owid group by trainer.Username,trainer.TrainerID, feedback.Comments,feedback.Rating"; ;
            DataTable dt = new DataTable();
            adpt = new SqlDataAdapter(query, conn);
            adpt.SelectCommand.Parameters.AddWithValue("@owid", GymLogin.OwnerId);
            // adpt.SelectCommand.Parameters.AddWithValue("@tranid", AdminFollowDiet.trainerid);
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;




        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            showDataPlan();
        }
    }
}
