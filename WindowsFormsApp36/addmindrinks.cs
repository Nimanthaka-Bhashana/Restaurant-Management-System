﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Mainform;

namespace WindowsFormsApp36
{
    public partial class addmindrinks : Form
    {
        String imageUrl = null;
        SqlConnection con = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=RESTURANTDATABASE2;Integrated Security=True;Encrypt=False");
        public addmindrinks()
        {
            InitializeComponent();
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imageUrl = ofd.FileName;
                    pictureBox7.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Image img = pictureBox7.Image;
            byte[] arr;
            ImageConverter converter = new ImageConverter();
            arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

            con.Open();
            SqlCommand com = new SqlCommand("INSERT INTO admindrinks(productid,productname,productprice,Photo,PhotoUrl)VALUES(@productid,@productname,@productprice,@Photo,@PhotoUrl)", con);
            com.Parameters.AddWithValue("@productid", txtprid.Text);
            com.Parameters.AddWithValue("@productname", txtproductdname.Text);
            com.Parameters.AddWithValue("@productprice", txtproductdprice.Text);
            com.Parameters.AddWithValue("@Photo", arr);
            com.Parameters.AddWithValue("@PhotoUrl", imageUrl);

            com.ExecuteNonQuery();
            MessageBox.Show("product saved");

            SqlCommand com2 = new SqlCommand("SELECT * FROM admindrinks", con);
            DataTable dt = new DataTable();
            dt.Load(com2.ExecuteReader());
            dataGridView3.DataSource = dt;
            con.Close();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            Image img = pictureBox7.Image;
            byte[] arr;
            ImageConverter converter = new ImageConverter();
            arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

            con.Open();
            SqlCommand com = new SqlCommand("DELETE admindrinks WHERE productid=@productid", con);
            com.Parameters.AddWithValue("@productid", txtproductdid.Text);


            com.ExecuteNonQuery();
            MessageBox.Show("product deleted");

            SqlCommand com2 = new SqlCommand("SELECT * FROM admindrinks", con);
            DataTable dt = new DataTable();
            dt.Load(com2.ExecuteReader());
            dataGridView3.DataSource = dt;
            con.Close();
        }

        private void btnbrowse4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imageUrl = ofd.FileName;
                    pictureBox8.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            Image img = pictureBox8.Image;
            byte[] arr;
            ImageConverter converter = new ImageConverter();
            arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

            con.Open();
            SqlCommand com = new SqlCommand("UPDATE admindrinks SET productname=@productname,productprice=@productprice,Photo=@Photo,PhotoUrl=@PhotoUrl WHERE productid=@productid", con);
            com.Parameters.AddWithValue("@productid", txtpid.Text);
            com.Parameters.AddWithValue("@productname", txtpname.Text);
            com.Parameters.AddWithValue("@productprice", txtpprice.Text);
            com.Parameters.AddWithValue("@Photo", arr);
            com.Parameters.AddWithValue("@PhotoUrl", imageUrl);


            com.ExecuteNonQuery();
            MessageBox.Show("product updated");

            SqlCommand com2 = new SqlCommand("SELECT * FROM admindrinks", con);
            DataTable dt = new DataTable();
            dt.Load(com2.ExecuteReader());
            dataGridView3.DataSource = dt;
            con.Close();
        }

        private void addmindrinks_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rESTURANTDATABASE2DataSet56.admindrinks' table. You can move, or remove it, as needed.
            this.admindrinksTableAdapter2.Fill(this.rESTURANTDATABASE2DataSet56.admindrinks);
            
            


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard("admin");
            this.Hide();
            ds.ShowDialog();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
