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

using Microsoft.VisualBasic;


namespace DB_forms
{
    public partial class TrainerFeedbackReport : Form
    {

        public static string MemID = "";

        public TrainerFeedbackReport()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MemID = comboBox1.Text;


            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();



            SqlCommand cm;
            string query = "";
            
            query = "select Rating , Comments from Feedback where MemberID = @tid";

            cm = new SqlCommand(query, conn);
            cm.Parameters.AddWithValue("@tid", MemID );

            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {

                    textBox1.Text = da.GetValue(0).ToString();
                    textBox2.Text = da.GetValue(1).ToString();


                    break;
                }
            }

        }

        private void TrainerFeedbackReport_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();



            SqlCommand cm;
            string query ;
           
            query = "select MemberID from Feedback where TrainerID = @tid";

            cm = new SqlCommand(query, conn);
            cm.Parameters.AddWithValue("@tid ", trainer.TrainerID );

            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    comboBox1.Items.Add(da["MemberID"].ToString() ); 

                   
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {



            Hide();
            using (TrainerOptionscs form2 = new TrainerOptionscs())
                form2.ShowDialog();
            Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
