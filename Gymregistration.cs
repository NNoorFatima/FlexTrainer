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
    public partial class Gymregistration : Form
    {
        public static string usname;
        public static string password;
        public static string email;
        public static string name;
        public Gymregistration()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Gymregistration_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True");
            conn.Open();


            SqlCommand cm;
            string query;

            query = "select AdminId from Admins";
            cm = new SqlCommand(query, conn);


            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    comboBox1.Items.Add(da["AdminId"].ToString());
                }
            }

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True");
            conn.Open();
            MessageBox.Show("Connection Open");
            SqlCommand cm, nid;
            string un = textBox4.Text;
            string pass = textBox3.Text;
            string email = textBox2.Text;
            string loc = textBox1.Text;
            string fac = textBox6.Text;
            string adid = comboBox1.Text;


            //activestaus yahan se dekhna hai
            //owner ka interface 
            //figure out gym id keses arahi hai 
            string query1 = "Insert into Registration(Username, Owner_Password,Owner_email,Location, Facilities,Admin_ID) values ('" + un + "','" + pass + "','" + email + "','" + loc + "','" + fac + "','" + adid + "')";
            cm = new SqlCommand(query1, conn);
            cm.ExecuteNonQuery();
            cm.Dispose();
            conn.Close();


            Hide();
            using (GymOwner form2 = new GymOwner())
                form2.ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            using (GymLogin form2 = new GymLogin())
                form2.ShowDialog();
            Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
