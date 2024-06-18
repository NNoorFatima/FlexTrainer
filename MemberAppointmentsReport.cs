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



    public partial class MemberAppointmentsReport : Form
    {
        public static string MemberID = "";


        public MemberAppointmentsReport()
        {
            InitializeComponent();
            showData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            showData(); 

        }

        public void showData() {
            
            SqlDataAdapter adpt;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

            //SqlCommand cm;
            string query;

            query = "select TrainerID , AppointmentDate , Duration , Status from appointments where memberId = @id";
            

            //cm = new SqlCommand(query, conn);
            DataTable dt = new DataTable () ;
            adpt = new SqlDataAdapter(query , conn);
            adpt.SelectCommand.Parameters.AddWithValue("@id", MemberOptions.MemberID);
            adpt.Fill(dt);
            dataGridView1.DataSource = dt; 



        }

    }
}
