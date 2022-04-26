using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace PhotoAlbum
{
    public partial class LoadFromFolder : Form
    {
        List<Image> li = new List<Image>();
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataSet ds;
        int rno = 0;
        MemoryStream ms;
        Image SourceImage;
        byte[] photo_aray;
        String selectedID = "";


        public LoadFromFolder()
        {
            InitializeComponent();
            LoadFromPc();
        }
        void LoadFromPc()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C: \Users\shake\Desktop\PhotoAlbum\pics");
            foreach(FileInfo file in dir.GetFiles())
            {
                try
                {
                    this.imageList1.Images.Add(Image.FromFile(file.FullName));

                    li.Add(Image.FromFile(file.FullName));
                }

                catch
                {
                    Console.WriteLine("This is not an image file");
                }
            }
           

            listView1.CheckBoxes = true;

                this.listView1.View = View.LargeIcon;
                this.imageList1.ImageSize = new Size(150, 150);
                this.listView1.LargeImageList = this.imageList1;

               
           
            for (int j = 0; j < this.imageList1.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                this.listView1.Items.Add(item);

            }
        }
        byte[] conv_photo(Image img)
        {

            //converting photo to binary data

            if (img != null)

            {
                //using MemoryStream:
                ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);


                photo_aray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo_aray, 0, photo_aray.Length);
            }
            return photo_aray;
        }

        void savetodb(Image img)
        {
            OleDbConnection con = new OleDbConnection(Properties.Settings.Default.Con);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Photos([Pic]) VALUES(?)";
            cmd.Connection = con;
            con.Open();

            cmd.Parameters.AddWithValue("@Pic", conv_photo(img));


            cmd.ExecuteNonQuery();

            con.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count>0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                Image img = item.ImageList.Images[item.ImageIndex];
                ShowPhoto f = new ShowPhoto(li[item.ImageIndex]);
                f.Show();
            }
        }

        private void Del_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itemRow in listView1.Items)
            {
                if (itemRow.Checked)
                    itemRow.Remove();
            }
        }

        private void Sall_Click(object sender, EventArgs e)
        {
             foreach (ListViewItem itemRow in listView1.Items)
            {
                itemRow.Checked = true;
            }
        }

        private void DSall_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itemRow in listView1.Items)
            {
                itemRow.Checked =false;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itemRow in listView1.Items)
            {
                int imgIndex = itemRow.ImageIndex;
                if(imgIndex>=0 && imgIndex<this.listView1.Items.Count)
                {
                    if(itemRow.Checked)
                    savetodb((Image)itemRow.ImageList.Images[imgIndex]);
                }
            }
        }
    }
}
