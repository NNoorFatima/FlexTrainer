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
    public partial class MembernewLogin : Form
    {
        public static string MemberID = ""; // to be used by other forms.
        public static string GymID = "";


        public MembernewLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();



            string id = textBox1.Text;
            MemberID = textBox1.Text;
            string pass = textBox2.Text;
            SqlCommand cm;

            string query1;

            query1 = "select ActiveStatus from Members where MemberID = @ID and Member_Password = @password";

            cm = new SqlCommand(query1, conn);

            cm.Parameters.AddWithValue("@ID", id);
            cm.Parameters.AddWithValue("@password", pass);


            string status = ""; 
            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    status = da.GetValue(0).ToString();
                    break;
                }
            }

            


            // if the member is approved. 

            string query;
            query = "select count (*) from Members where MemberID = @ID and Member_Password = @password";

            cm = new SqlCommand(query, conn);

            cm.Parameters.AddWithValue("@ID", id);
            cm.Parameters.AddWithValue("@password", pass);





            int count = (int)cm.ExecuteScalar();

            if (count > 0)
            {

                if (status == "Approved")
                {


                    // update gymid now ; 
                    query = "SELECT GymID FROM Members WHERE MemberID = @ID";
                    cm = new SqlCommand(query, conn);

                    cm.Parameters.AddWithValue("@ID", id);
                    using (SqlDataReader reader = cm.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Retrieve the GymID
                            GymID = reader.GetString(0); // Assuming GymID is stored as string
                        }
                    }
                    // MessageBox.Show(GymID);





                    Hide();
                    using (MemberOptions form2 = new MemberOptions())
                        form2.ShowDialog();
                    Show();

                }
                else {
                    //
                    Hide();
                    using (MemberRevokeGif form2 = new MemberRevokeGif())
                    {
                        form2.ShowDialog();
                    }
                    Show();
                   // MessageBox.Show("You have been Revoked");
                }
            }
            else
            {
                MessageBox.Show("Invalid id or password");

            }

        

            conn.Close(); 
           
        }
    }
}
