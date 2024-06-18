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
    public partial class TrainerAppointmentSetAppointmentDate : Form
    {
        public static string id;
        public static string memid;
        public TrainerAppointmentSetAppointmentDate()
        {
            InitializeComponent();
        }

        private void TrainerAppointmentSetAppointmentDate_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();
            string ans;
            ans = textBox1.Text;
            // id = TrainerAppointment.meid;
            SqlCommand cm;
            string query;
            query = "UPDATE appointments SET status = 'Approved',AppointmentDate=@ans WHERE MemberId = @memid";
            cm = new SqlCommand(query, conn);
            //MessageBox.Show(TrainerAppointment.meid);

            cm.Parameters.AddWithValue("@memid", TrainerAppointment.meid);
            cm.Parameters.AddWithValue("@ans", ans);
            cm.ExecuteNonQuery();
            cm.Dispose();

            MessageBox.Show("Done");

            conn.Close();
            Hide();
            using (TrainerOptionscs form2 = new TrainerOptionscs())
                form2.ShowDialog();
            Show();
        }

      
    }
}