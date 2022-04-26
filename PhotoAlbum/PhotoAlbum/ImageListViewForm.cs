using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace PhotoAlbum
{
    public partial class ImageListViewForm : Form
    {
        public ImageListViewForm()
        {
            InitializeComponent();
            LoadImages();
            CreateMyListView();
        }

//-----------------------------------------------
        private void CreateMyListView()
        {
            // Create a new ListView control.
            ListView listView1 = new ListView();
            listView1.Bounds = new Rectangle(new Point(10, 10), new Size(700, 500));

            // Set the view to show details.
            listView1.View = View.Details;
            // Allow the user to edit item text.
            listView1.LabelEdit = true;
            // Allow the user to rearrange columns.
            listView1.AllowColumnReorder = true;
            // Display check boxes.
            listView1.CheckBoxes = true;
            // Select the item and subitems when selection is made.
            listView1.FullRowSelect = true;
            // Display grid lines.
            listView1.GridLines = true;
            // Sort the items in the list in ascending order.
            listView1.Sorting = SortOrder.Ascending;
            //---------------------------------------------
            listView1.Columns.Add("Column 1", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 2", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 3", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 4", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("Column 5", 50, HorizontalAlignment.Center);

            //--------------------------------------------
        

            listView1.View = View.LargeIcon;
            this.imageList1.ImageSize = new Size(50, 50);
            listView1.LargeImageList = this.imageList1;
        
            for (int j = 0; j < this.imageList1.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                listView1.Items.Add(item);
            }

              listView1.LargeImageList = imageList1;
              this.Controls.Add(listView1);
        }
//-----------------------------------------------

        private Bitmap BytesToImage(byte[] bytes)
        {
            using (MemoryStream image_stream = new MemoryStream(bytes))
            {
                Bitmap bm = new Bitmap(image_stream);
                image_stream.Close();
                return bm;
            }
        }

        void LoadImages()
        {
            string str = "SELECT * from Photos";
            OleDbDataAdapter dr = new
            OleDbDataAdapter(str, Properties.Settings.Default.Con);
            DataSet ds = new DataSet();

            dr.Fill(ds, "Photos");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row["Pic"] != DBNull.Value)
                {
                    byte[] imageData = (byte[])row["Pic"];
                    Bitmap bmp = BytesToImage(imageData);

                    imageList1.Images.Add(bmp);

                }
            }
        }
    }
}