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
    public partial class TrainerAppointment : Form
    {
        public static string MainTrainer;
        public static string status;
        public static string meid;
        public TrainerAppointment()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }




        private void button3_Click(object sender, EventArgs e)
        {
            meid = comboBox1.Text;

            Hide();
            using (TrainerAppointmentSetAppointmentDate form2 = new TrainerAppointmentSetAppointmentDate())
                form2.ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-VH2BAA0\\SQLEXPRESS;Initial Catalog=work;Integrated Security=True");
                conn.Open();
                SqlCommand cm;
                string query;
                string memid = comboBox1.Text;
                meid = comboBox1.Text;
                query = "UPDATE appointments SET status = 'cancel' WHERE MemberId = @memid";
                cm = new SqlCommand(query, conn);

                cm.Parameters.AddWithValue("@memid", memid);
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



        private void TrainerAppointment_Load(object sender, EventArgs e)
        {
            MainTrainer = trainer.TrainerID;
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

            SqlCommand cm;
            string query;
            query = "select distinct(MemberId) from appointments where TrainerID=@MainTrainer and status='hold'";

            cm = new SqlCommand(query, conn);
            cm.Parameters.AddWithValue("@MainTrainer", MainTrainer);

            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    comboBox1.Items.Add(da["MemberId"].ToString());
                }
            }

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-VH2BAA0\\SQLEXPRESS;Initial Catalog=work;Integrated Security=True");
                conn.Open();
                SqlCommand cm;
                string query;
                string memid = comboBox1.Text;
                meid = memid;
                query = "UPDATE appointments SET status = 'Approved' WHERE MemberId = @memid";
                cm = new SqlCommand(query, conn);

                cm.Parameters.AddWithValue("@memid", memid);
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

}