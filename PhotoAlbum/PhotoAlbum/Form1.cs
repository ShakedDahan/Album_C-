using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoAlbum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PhotoForm pf = new PhotoForm();
            pf.Show();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            categoryform ct = new categoryform();
            ct.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LocatioForm f = new LocatioForm();
            f.Show();
        }

      

        private void button4_Click_1(object sender, EventArgs e)
        {
            ImageListViewForm f = new ImageListViewForm();
            f.Show();
        }

        private void LoadFromPc_Click(object sender, EventArgs e)
        {
            LoadFromFolder f = new LoadFromFolder();
            f.Show();
        }
    }
}
