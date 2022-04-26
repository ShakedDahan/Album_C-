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
    public partial class ImageList : Form
    {
        public ImageList()
        {
            InitializeComponent();
           
            MyImagelist();
          CreateMyListView();

        }

        //-------------------------------
        private void CreateMyListView()
        {
            // Create a new ListView control.
            ListView listView1 = new ListView();
            listView1.Bounds = new Rectangle(new Point(10, 10), new Size(300, 200));

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
            /*
            // Create three items and three sets of subitems for each item.
            ListViewItem item1 = new ListViewItem("item1", 0);
            // Place a check mark next to the item.
            item1.Checked = true;
            item1.SubItems.Add("1");
            item1.SubItems.Add("2");
            item1.SubItems.Add("3");
            ListViewItem item2 = new ListViewItem("item2", 1);
            item2.SubItems.Add("4");
            item2.SubItems.Add("5");
            item2.SubItems.Add("6");
            ListViewItem item3 = new ListViewItem("item3", 0);
            // Place a check mark next to the item.
            item3.Checked = true;
            item3.SubItems.Add("7");
            item3.SubItems.Add("8");
            item3.SubItems.Add("9");
            */
            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            listView1.Columns.Add("Column 1", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 4", -2, HorizontalAlignment.Center);

            //Add the items to the ListView.
         //   listView1.Items.AddRange(new ListViewItem[] { item1, item2, item3 });

            // Create two ImageList objects.
            listView1.View = View.LargeIcon;

            this.imageList1.ImageSize = new Size(200, 200);
            listView1.LargeImageList = this.imageList1;


            for (int j = 0; j < this.imageList1.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                listView1.Items.Add(item);



            }
            /* Initialize the ImageList objects with bitmaps.
            imageList1.Images.Add(Bitmap.FromFile("C:\\MySmallImage1.bmp"));
            imageList1.Images.Add(Bitmap.FromFile("C:\\MySmallImage2.bmp"));
            imageList1.Images.Add(Bitmap.FromFile("C:\\MyLargeImage1.bmp"));
            imageList1.Images.Add(Bitmap.FromFile("C:\\MyLargeImage2.bmp"));
            */



            //Assign the ImageList objects to the ListView.
            listView1.LargeImageList = imageList1;
           // listView1.SmallImageList = imageListSmall;

            // Add the ListView to the control collection.
            this.Controls.Add(listView1);
        }
        //-------------------------------

        // Convert a byte array into an image.
        private Bitmap BytesToImage(byte[] bytes)
        {
            using (MemoryStream image_stream = new MemoryStream(bytes))
            {
                Bitmap bm = new Bitmap(image_stream);
                image_stream.Close();
                return bm;
            }
        }

       


       

        void MyImagelist()
        {


            //------------------------------
            string str = "SELECT    Photos.Title, Photos.ID, Category.CatTitle, Location.LocationTitle, Photos.Pic" +
                          " FROM            ((Photos INNER JOIN " +
                          " Category ON Photos.CatId = Category.ID) INNER JOIN " +
                           " Location ON Photos.LocId = Location.ID)";
            OleDbDataAdapter dr = new
            OleDbDataAdapter(str, Properties.Settings.Default.Con);
            DataSet ds = new DataSet();

            dr.Fill(ds, "Photos");




            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row["Pic"] != DBNull.Value)
                {
                    byte[] imageData = (byte[])row["Pic"];
                    //-------------------------

                    Bitmap bmp = BytesToImage(imageData);
                    imageList1.Images.Add(bmp);


                }

            }
            /*
            //-----------------------------
            this.listView1.View = View.LargeIcon;
         
            this.imageList1.ImageSize = new Size(200,200);
            this.listView1.LargeImageList = this.imageList1;
          
            
            for (int j = 0; j < this.imageList1.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                this.listView1.Items.Add(item);

      
              
            }
             * */
        }
    }
}