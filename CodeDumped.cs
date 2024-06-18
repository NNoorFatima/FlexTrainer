using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_forms
{
    public partial class CodeDumped : Form
    {
        public CodeDumped()
        {
            InitializeComponent();
            string f = "C:\\Users\\Hp EliteBook\\Downloads\\hardwork.mp4";
            axWindowsMediaPlayer1.URL = f;
        
           this.Size = new System.Drawing.Size(890, 500);
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string f = "C:\\Users\\Hp EliteBook\\Downloads\\hardwork.mp4";
        //    axWindowsMediaPlayer1.URL = f;
        //}
    }
}
