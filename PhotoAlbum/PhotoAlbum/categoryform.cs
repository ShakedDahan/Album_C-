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
    public partial class categoryform : Form
    {
        public string selectedID = "";
        public categoryform()
        {
            
            InitializeComponent();
            LoadCategoryToGrid();
        }

        public void LoadCategoryToGrid()
        {
            string str = "SELECT * FROM Category";
            OleDbDataAdapter dr = new
            OleDbDataAdapter(str, Properties.Settings.Default.Con);
            DataSet ds = new DataSet();
            dr.Fill(ds, "Category");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Category";
        }

        /* insert to database using insert button */
        private void button1_Click(object sender, EventArgs e) 
        {
            
            OleDbConnection con = new OleDbConnection(Properties.Settings.Default.Con);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Category([CatTitle])" +
            " VALUES(?)";  /*Query to insert to the selected table*/
            cmd.Connection = con;
            con.Open();
            cmd.Parameters.AddWithValue("@CatTitle", textBox1.Text); /* ? values */

            cmd.ExecuteNonQuery();

            con.Close();

            LoadCategoryToGrid();   //DataGridView1   קריאה לפונקציה לעננן את
        }
        /* Deleting from the Category table using the delete button*/

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) /*Deleting from the table*/
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            selectedID = dataGridView1.Rows[selectedIndex].Cells["ID"].Value.ToString(); /*gets the id of the selected row*/
            /* try
             {
                 if (selectedID == null)
                 {
                 }
             }
             catch
             {
                 MessageBox.Show("HELLO");
             }
             */
            //**********************
            /* only if the Delete was clicked on*/
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Del") 
            {
                OleDbConnection myCon = new OleDbConnection(Properties.Settings.Default.Con);
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "DELETE FROM [Category] WHERE ID="
                + Convert.ToInt32(selectedID) + ""; /*converts to int because it is saved in the table in int */
                cmd.Connection = myCon;
                myCon.Open();
                int n = cmd.ExecuteNonQuery(); /* how many rows affected */
                myCon.Close();
                if (n > 0)
                {
                    MessageBox.Show("record in row :" + selectedIndex.ToString() + " is Deleted");

                }
                else
                    MessageBox.Show("DELETE failed");
                myCon.Close();
                
            }
                
                /*IF the Update button was selected in the gridview table*/
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Update")
                { 

                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();

                }

            LoadCategoryToGrid();
        }/*end of Delete and Update function using the delete button*/


        /*Update CatTitle using button*/
        private void Update1_Click(object sender, EventArgs e)
        {
            OleDbConnection myCon = new OleDbConnection(Properties.Settings.Default.Con);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;


            cmd.CommandText = @"UPDATE Category  SET CatTitle = @CatTitle  WHERE ID="
            + Convert.ToInt32(selectedID) + "";
            cmd.Parameters.AddWithValue("@CatTitle", textBox1.Text);
            cmd.Connection = myCon;
            myCon.Open();
            int n = cmd.ExecuteNonQuery();
            myCon.Close();
            LoadCategoryToGrid();
        }
    }
}
