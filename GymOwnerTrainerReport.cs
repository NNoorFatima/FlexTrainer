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
    public partial class GymOwnerTrainerReport : Form
    {
        public GymOwnerTrainerReport()
        {
            InitializeComponent();
            showDataPlan();
            this.Size = new Size(900, 300);
        }
        private void showDataPlan()
        {

            SqlDataAdapter adpt;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True");
            conn.Open();

            //SqlCommand cm;
            string query;
            // planID = 0;

            query = "SELECT * from Trainer  WHERE TrainerID = @id";

            DataTable dt = new DataTable();
            adpt = new SqlDataAdapter(query, conn);
            adpt.SelectCommand.Parameters.AddWithValue("@id", GymTrainerReport.TranId);
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;



        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            showDataPlan();
        }

        private void GymOwnerTrainerReport_Load(object sender, EventArgs e)
        {
            showDataPlan();
        }
    }
}
