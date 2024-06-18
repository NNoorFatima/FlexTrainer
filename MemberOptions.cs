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
    public partial class MemberOptions : Form
    {
        public static string MemberID = "";
        

        public MemberOptions()
        {
            InitializeComponent();
            /// MessageBox.Show(MembernewLogin.MemberID); 
            MemberID = MembernewLogin.MemberID; 
        }

        private void button4_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            SqlCommand cm;
            string query;


            query = "select count(*) from MemberFollowplan where MemberID = @id";
            cm = new SqlCommand(query, conn);
            cm.Parameters.AddWithValue("@id", MemberID );
            int count = 0; 

            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    count = da.GetInt32(0); 
                }
            }

            if ( count >=1  ) {
                MessageBox.Show("You are already following a Plan.");
                
            }
            else {
                Hide();
                using (memberDietPlanning form2 = new memberDietPlanning())
                    form2.ShowDialog();
                Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            using (MemberPTSB form2 = new MemberPTSB())
                form2.ShowDialog();
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
 /*           
            Hide();
            using (MemberDietPlanSelection form2 = new MemberDietPlanSelection())
                form2.ShowDialog();
            Show();
*/
            Hide();
            using ( DietReportSelf form2 = new DietReportSelf())
                form2.ShowDialog();
            Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {

            Hide();
            using (ReportsInterface form2 = new ReportsInterface())
                form2.ShowDialog();
            Show();



        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            using (wokoutReportSelf form2 = new wokoutReportSelf ()) 
                form2.ShowDialog();
            Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Hide();
            using (MemberTrainerFeedback form2 = new MemberTrainerFeedback())
                form2.ShowDialog();
            Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {


            
            Hide();
            using (MemberAppointmentsReport form2 = new MemberAppointmentsReport())
                form2.ShowDialog();
            Show();
            

        }
    }
}
