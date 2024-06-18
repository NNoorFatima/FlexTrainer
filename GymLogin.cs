﻿using System;
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


    public partial class GymLogin : Form
    {
        public static string OwnerId = "" ; 
        
        public GymLogin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            SqlCommand cm;
            string id = textBox1.Text;
            OwnerId = textBox1.Text;
            string pass = textBox2.Text;
            string query;
            query = "select count (*) from Owners where OwnerID = @ID and Owner_Password = @password";

            cm = new SqlCommand(query, conn);

            cm.Parameters.AddWithValue("@ID", id);
            cm.Parameters.AddWithValue("@password", pass);


            int count = (int)cm.ExecuteScalar();



            if (count > 0)
            {


                Hide();
                using (GymOwner form2 = new GymOwner())
                    form2.ShowDialog();
                Show();

            }
            else
            {
                MessageBox.Show("Invalid id or password");

            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
