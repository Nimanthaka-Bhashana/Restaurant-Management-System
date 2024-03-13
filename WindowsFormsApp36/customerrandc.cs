using Mainform;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WindowsFormsApp27
{
    public partial class customerrandc : Form
    {
        

        SqlConnection con = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=RESTURANTDATABASE2;Integrated Security=True;Encrypt=False");
        public customerrandc() 
        {
            InitializeComponent();
        }

       

        private void redrice_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btncalculate1_click(object sender, EventArgs e)
        {
            
            
        }
        private void btncalculate9_click(object sender, EventArgs e)
        {
            
        }

        private void customerrandc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rESTURANTDATABASE2DataSet81.yellowrs' table. You can move, or remove it, as needed.
            this.yellowrsTableAdapter1.Fill(this.rESTURANTDATABASE2DataSet81.yellowrs);
            // TODO: This line of code loads data into the 'rESTURANTDATABASE2DataSet80.adminyellow' table. You can move, or remove it, as needed.
            this.adminyellowTableAdapter2.Fill(this.rESTURANTDATABASE2DataSet80.adminyellow);
            // TODO: This line of code loads data into the 'rESTURANTDATABASE2DataSet79.whiters' table. You can move, or remove it, as needed.
            this.whitersTableAdapter1.Fill(this.rESTURANTDATABASE2DataSet79.whiters);
            // TODO: This line of code loads data into the 'rESTURANTDATABASE2DataSet78.adminwhite' table. You can move, or remove it, as needed.
            this.adminwhiteTableAdapter2.Fill(this.rESTURANTDATABASE2DataSet78.adminwhite);
            // TODO: This line of code loads data into the 'rESTURANTDATABASE2DataSet72.redrs' table. You can move, or remove it, as needed.
            this.redrsTableAdapter4.Fill(this.rESTURANTDATABASE2DataSet72.redrs);
            // TODO: This line of code loads data into the 'rESTURANTDATABASE2DataSet71.addminreds' table. You can move, or remove it, as needed.
            this.addminredsTableAdapter2.Fill(this.rESTURANTDATABASE2DataSet71.addminreds);






        }

        private void dataGridView10_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            con.Open();
            SqlCommand com2 = new SqlCommand("SELECT * FROM addminred", con);
            DataTable dt = new DataTable();
            dt.Load(com2.ExecuteReader());
            dataGridView10.DataSource = dt;
            con.Close();
        }

        private void btncalculate_click(object sender, EventArgs e)
        {
            
            int price;
            int quantity;
            int total;

            price=Convert.ToInt32(this.txtpp.Text);
            quantity=Convert.ToInt32(this.txtpq.Text);

            total=price*quantity;

          

            this.txtt.Text=total.ToString();
            


        }

        private void btnview1_Click(object sender, EventArgs e)
        {


            con.Open();

            string sqlinsert = "INSERT INTO redrs(productid,productname,productprice,quantity,total)values(@productid,@productname,@productprice,@quantity,@total)";
            SqlCommand com = new SqlCommand(sqlinsert, con);
            com.Parameters.AddWithValue("@productid", this.txtrrpi.Text);
            com.Parameters.AddWithValue("@productname", this.txtpn.Text);
            com.Parameters.AddWithValue("@productprice", this.txtpp.Text);
            com.Parameters.AddWithValue("@quantity", this.txtpq.Text);
            com.Parameters.AddWithValue("@total", this.txtt.Text);

            int ret = com.ExecuteNonQuery();
            MessageBox.Show("no of records inserted in staffredrice " + ret, "information");

            string sqlinsert3 = "INSERT INTO finalreport(productid,productname,productprice,quantity,total)values(@productid,@productname,@productprice,@quantity,@total)";
            SqlCommand com3 = new SqlCommand(sqlinsert3, con);
            com3.Parameters.AddWithValue("@productid", this.txtproid.Text);
            com3.Parameters.AddWithValue("@productname", this.txtpn.Text);
            com3.Parameters.AddWithValue("@productprice", this.txtpp.Text);
            com3.Parameters.AddWithValue("@quantity", this.txtpq.Text);
            com3.Parameters.AddWithValue("@total", this.txtt.Text);

            int ret3 = com3.ExecuteNonQuery();
            MessageBox.Show("product inserted in final bill" + ret3, "information");

            string sqlview = "SELECT * FROM redrs";
            SqlCommand com2 = new SqlCommand(sqlview, con);

            SqlDataAdapter sda = new SqlDataAdapter(com2);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            this.txtrrpi.Text = ds.Tables[0].Rows[0][0].ToString();
            this.txtpn.Text = ds.Tables[0].Rows[0][1].ToString();
            this.txtpp.Text = ds.Tables[0].Rows[0][2].ToString();
            this.txtpq.Text = ds.Tables[0].Rows[0][3].ToString();
            this.txtt.Text = ds.Tables[0].Rows[0][4].ToString();

            this.dataGridView16.DataSource = ds.Tables[0];

            txtrrpi.Clear();
            txtpn.Clear();
            txtpp.Clear();
            txtpq.Clear();
            txtt.Clear();
            txtproid.Clear();

            con.Close();


        }

        private void txtproductc_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

       

        private void btnaddfb_Click(object sender, EventArgs e)
        {
            con.Open();

            string sqlinsert = "INSERT INTO finalreport(productid,productname,productprice,quantity,total)values(@productid,@productname,@productprice,@quantity,@total)";
            SqlCommand com = new SqlCommand(sqlinsert, con);
            com.Parameters.AddWithValue("@productid", this.txtproid.Text);
            com.Parameters.AddWithValue("@productname", this.txtpn.Text);
            com.Parameters.AddWithValue("@productprice", this.txtpp.Text);
            com.Parameters.AddWithValue("@quantity", this.txtpq.Text);
            com.Parameters.AddWithValue("@total", this.txtt.Text);

            int ret = com.ExecuteNonQuery();
            MessageBox.Show("product inserted" + ret, "information");

            con.Close();
        }

        private void whiterice_Click(object sender, EventArgs e)
        {

        }

        private void txtbillno_TextChanged(object sender, EventArgs e)
        {
        

        }

        private void btncalculate2_Click(object sender, EventArgs e)
        {
         
        }

        private void dataGridView12_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtpc2_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void dataaddview2_Click(object sender, EventArgs e)
        {
            

        }

        private void finalbill2_Click(object sender, EventArgs e)
        {
          
        }

        private void txtpc2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
           
        }

        private void txtpc3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btncalculate3_Click(object sender, EventArgs e)
        {
           
        }

        private void dataaddview_click(object sender, EventArgs e)
        {
           
        }

        private void finalbill3_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

            int a;
            int b;

            a = Convert.ToInt32(this.txtrrpi.Text);


            b = a;

            this.txtproid.Text = b.ToString();


            con.Open();

            if(txtrrpi.Text!="")
            {
                SqlCommand com = new SqlCommand("SELECT productname,productprice FROM addminreds where productid=@productid", con);
                com.Parameters.AddWithValue("@productid", int.Parse(txtrrpi.Text));
                SqlDataReader dr=com.ExecuteReader();
                while(dr.Read())
                {
                    txtpn.Text=dr.GetValue(0).ToString();
                    txtpp.Text=dr.GetValue(1).ToString();
                }

                con.Close();
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            dataGridView16.DataSource = null;

            con.Open();

            string sqldeleteall = "TRUNCATE TABLE redrs";
            SqlCommand com2 = new SqlCommand(sqldeleteall, con);

            com2.ExecuteNonQuery();

            con.Close();


        }

        private void btnsearch2_Click(object sender, EventArgs e)
        {
            int a;
            int b;

            a = Convert.ToInt32(this.txtwrid2.Text);


            b = a;

            this.txtproid2.Text = b.ToString();

            con.Open();

            if (txtwrid2.Text != "")
            {
                SqlCommand com = new SqlCommand("SELECT productname,productprice FROM adminwhite where productid=@productid", con);
                com.Parameters.AddWithValue("@productid", int.Parse(txtwrid2.Text));
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    txtpn2.Text = dr.GetValue(0).ToString();
                    txtpp2.Text = dr.GetValue(1).ToString();
                }

                con.Close();
            }
        }

        private void btncalculate2_Click_1(object sender, EventArgs e)
        {
            int price;
            int quantity;
            int total;

            price = Convert.ToInt32(this.txtpp2.Text);
            quantity = Convert.ToInt32(this.txtpq2.Text);

            total = price * quantity;



            this.txtt2.Text = total.ToString();

        }

        private void btndataaddview2_Click(object sender, EventArgs e)
        {

            con.Open();

            string sqlinsert = "INSERT INTO whiters(productid,productname,productprice,quantity,total)values(@productid,@productname,@productprice,@quantity,@total)";
            SqlCommand com = new SqlCommand(sqlinsert, con);
            com.Parameters.AddWithValue("@productid", this.txtwrid2.Text);
            com.Parameters.AddWithValue("@productname", this.txtpn2.Text);
            com.Parameters.AddWithValue("@productprice", this.txtpp2.Text);
            com.Parameters.AddWithValue("@quantity", this.txtpq2.Text);
            com.Parameters.AddWithValue("@total", this.txtt2.Text);

            int ret = com.ExecuteNonQuery();
            MessageBox.Show("no of records inserted" + ret, "information");

            string sqlinsert3 = "INSERT INTO finalreport(productid,productname,productprice,quantity,total)values(@productid,@productname,@productprice,@quantity,@total)";
            SqlCommand com3 = new SqlCommand(sqlinsert3, con);
            com3.Parameters.AddWithValue("@productid", this.txtproid2.Text);
            com3.Parameters.AddWithValue("@productname", this.txtpn2.Text);
            com3.Parameters.AddWithValue("@productprice", this.txtpp2.Text);
            com3.Parameters.AddWithValue("@quantity", this.txtpq2.Text);
            com3.Parameters.AddWithValue("@total", this.txtt2.Text);

            int ret3 = com3.ExecuteNonQuery();
            MessageBox.Show("product inserted" + ret3, "information");

            string sqlview = "SELECT * FROM whiters";
            SqlCommand com2 = new SqlCommand(sqlview, con);

            SqlDataAdapter sda = new SqlDataAdapter(com2);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            this.txtrrpi.Text = ds.Tables[0].Rows[0][0].ToString();
            this.txtpn.Text = ds.Tables[0].Rows[0][1].ToString();
            this.txtpp.Text = ds.Tables[0].Rows[0][2].ToString();
            this.txtpq.Text = ds.Tables[0].Rows[0][3].ToString();
            this.txtt.Text = ds.Tables[0].Rows[0][4].ToString();

            this.dataGridView43.DataSource = ds.Tables[0];
            txtwrid2.Clear();
            txtpn2.Clear();
            txtpp2.Clear();
            txtpq2.Clear();
            txtt2.Clear();
            txtproid2.Clear();

            con.Close();
        }

        private void btnclear2_Click(object sender, EventArgs e)
        {
            dataGridView43.DataSource = null;

            con.Open();

            string sqldeleteall = "TRUNCATE TABLE whiters";
            SqlCommand com2 = new SqlCommand(sqldeleteall, con);

            com2.ExecuteNonQuery();

            con.Close();
        }

        private void btnfinalre_Click(object sender, EventArgs e)
        {
            con.Open();

            string sqlinsert = "INSERT INTO finalreport(productid,productname,productprice,quantity,total)values(@productid,@productname,@productprice,@quantity,@total)";
            SqlCommand com = new SqlCommand(sqlinsert, con);
            com.Parameters.AddWithValue("@productid", this.txtproid2.Text);
            com.Parameters.AddWithValue("@productname", this.txtpn2.Text);
            com.Parameters.AddWithValue("@productprice", this.txtpp2.Text);
            com.Parameters.AddWithValue("@quantity", this.txtpq2.Text);
            com.Parameters.AddWithValue("@total", this.txtt2.Text);

            int ret = com.ExecuteNonQuery();
            MessageBox.Show("product inserted" + ret, "information");

            con.Close();
        }

        private void yellowrice_Click(object sender, EventArgs e)
        {

        }

        private void btnsearch3_Click(object sender, EventArgs e)
        {
            int a;
            int b;

            a= Convert.ToInt32(this.txtyrid3.Text);


            b = a;

            this.txtproid3.Text=b.ToString();

            con.Open();

            if (txtyrid3.Text != "")
            {
                SqlCommand com = new SqlCommand("SELECT productname,productprice FROM adminyellow where productid=@productid", con);
                com.Parameters.AddWithValue("@productid", int.Parse(txtyrid3.Text));
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    txtpn3.Text = dr.GetValue(0).ToString();
                    txtpp3.Text = dr.GetValue(1).ToString();
                }

                con.Close();
            }
        }

        private void btncalculate3_Click_1(object sender, EventArgs e)
        {

        }

        private void btncalculate3_Click_2(object sender, EventArgs e)
        {
            int price;
            int quantity;
            int total;

            price = Convert.ToInt32(this.txtpp3.Text);
            quantity = Convert.ToInt32(this.txtpq3.Text);

            total = price * quantity;



            this.txtt3.Text = total.ToString();
        }

        private void dataaddview3_Click(object sender, EventArgs e)
        {
            con.Open();

            string sqlinsert = "INSERT INTO yellowrs(productid,productname,productprice,quantity,total)values(@productid,@productname,@productprice,@quantity,@total)";
            SqlCommand com = new SqlCommand(sqlinsert, con);
            com.Parameters.AddWithValue("@productid", this.txtyrid3.Text);
            com.Parameters.AddWithValue("@productname", this.txtpn3.Text);
            com.Parameters.AddWithValue("@productprice", this.txtpp3.Text);
            com.Parameters.AddWithValue("@quantity", this.txtpq3.Text);
            com.Parameters.AddWithValue("@total", this.txtt3.Text);

            int ret = com.ExecuteNonQuery();
            MessageBox.Show("no of records inserted in staffwhiterice" + ret, "information");

            string sqlinsert3 = "INSERT INTO finalreport(productid,productname,productprice,quantity,total)values(@productid,@productname,@productprice,@quantity,@total)";
            SqlCommand com3 = new SqlCommand(sqlinsert3, con);
            com3.Parameters.AddWithValue("@productid", this.txtproid3.Text);
            com3.Parameters.AddWithValue("@productname", this.txtpn3.Text);
            com3.Parameters.AddWithValue("@productprice", this.txtpp3.Text);
            com3.Parameters.AddWithValue("@quantity", this.txtpq3.Text);
            com3.Parameters.AddWithValue("@total", this.txtt3.Text);

            int ret3 = com3.ExecuteNonQuery();
            MessageBox.Show("product inserted in finalbillreport" + ret3, "information");


            string sqlview = "SELECT * FROM yellowrs";
            SqlCommand com2 = new SqlCommand(sqlview, con);

            SqlDataAdapter sda = new SqlDataAdapter(com2);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            this.txtrrpi.Text = ds.Tables[0].Rows[0][0].ToString();
            this.txtpn.Text = ds.Tables[0].Rows[0][1].ToString();
            this.txtpp.Text = ds.Tables[0].Rows[0][2].ToString();
            this.txtpq.Text = ds.Tables[0].Rows[0][3].ToString();
            this.txtt.Text = ds.Tables[0].Rows[0][4].ToString();

            this.dataGridView44.DataSource = ds.Tables[0];

            txtyrid3.Clear();
            txtpn3.Clear();
            txtpp3.Clear();
            txtpq3.Clear();
            txtt3.Clear();
            txtproid3.Clear();

            con.Close();
        }

        private void btnclear_Click_1(object sender, EventArgs e)
        {
            dataGridView44.DataSource = null;

            con.Open();

            string sqldeleteall = "TRUNCATE TABLE yellowrs";
            SqlCommand com2 = new SqlCommand(sqldeleteall, con);

            com2.ExecuteNonQuery();

            con.Close();
        }

        private void btnfinalreport3_Click(object sender, EventArgs e)
        {
            con.Open();

            string sqlinsert = "INSERT INTO finalreport(productid,productname,productprice,quantity,total)values(@productid,@productname,@productprice,@quantity,@total)";
            SqlCommand com = new SqlCommand(sqlinsert, con);
            com.Parameters.AddWithValue("@productid", this.txtproid3.Text);
            com.Parameters.AddWithValue("@productname", this.txtpn3.Text);
            com.Parameters.AddWithValue("@productprice", this.txtpp3.Text);
            com.Parameters.AddWithValue("@quantity", this.txtpq3.Text);
            com.Parameters.AddWithValue("@total", this.txtt3.Text);

            int ret = com.ExecuteNonQuery();
            MessageBox.Show("product inserted" + ret, "information");

            con.Close();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            con.Open();
            SqlCommand com2 = new SqlCommand("SELECT * FROM addminred", con);
            DataTable dt = new DataTable();
            dt.Load(com2.ExecuteReader());
            dataGridView10.DataSource = dt;
            con.Close();
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            con.Open();
            SqlCommand com2 = new SqlCommand("SELECT * FROM adminwhite", con);
            DataTable dt = new DataTable();
            dt.Load(com2.ExecuteReader());
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void dataGridView22_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            con.Open();
            SqlCommand com2 = new SqlCommand("SELECT * FROM adminyellow", con);
            DataTable dt = new DataTable();
            dt.Load(com2.ExecuteReader());
            dataGridView22.DataSource = dt;
            con.Close();
        }

        private void btndelete_click(object sender, EventArgs e)
        {

        }

        private void dataGridView16_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datadeleteview_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard("staff");
            this.Hide();
            ds.ShowDialog();
        }

        private void datadeleteview_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("DELETE redrs WHERE productid=@productid", con);
            com.Parameters.AddWithValue("@productid", this.txtpid11.Text);


            com.ExecuteNonQuery();


            SqlCommand com2 = new SqlCommand("SELECT * FROM redrs", con);
            DataTable dt = new DataTable();
            dt.Load(com2.ExecuteReader());
            dataGridView16.DataSource = dt;

            SqlCommand com3 = new SqlCommand("DELETE finalreport WHERE productid=@productid", con);
            com3.Parameters.AddWithValue("@productid", this.txtpid11.Text);

            com3.ExecuteNonQuery();
            MessageBox.Show("product deleted");

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void datadelview_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("DELETE whiters WHERE productid=@productid", con);
            com.Parameters.AddWithValue("@productid", this.productid12.Text);


            com.ExecuteNonQuery();


            SqlCommand com2 = new SqlCommand("SELECT * FROM whiters", con);
            DataTable dt = new DataTable();
            dt.Load(com2.ExecuteReader());
            dataGridView43.DataSource = dt;

            SqlCommand com3 = new SqlCommand("DELETE finalreport WHERE productid=@productid", con);
            com3.Parameters.AddWithValue("@productid", this.productid12.Text);

            com3.ExecuteNonQuery();
            MessageBox.Show("product deleted");

            con.Close();
        }

        private void btndeleview_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("DELETE yellowrs WHERE productid=@productid", con);
            com.Parameters.AddWithValue("@productid", this.productid13.Text);


            com.ExecuteNonQuery();


            SqlCommand com2 = new SqlCommand("SELECT * FROM yellowrs", con);
            DataTable dt = new DataTable();
            dt.Load(com2.ExecuteReader());
            dataGridView43.DataSource = dt;

            SqlCommand com3 = new SqlCommand("DELETE finalreport WHERE productid=@productid", con);
            com3.Parameters.AddWithValue("@productid", this.productid13.Text);

            com3.ExecuteNonQuery();
            MessageBox.Show("product deleted");

            con.Close();

        }

        private void txtrrpi_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void txtpid11_TextChanged(object sender, EventArgs e)
        {

        }

        private void addminredsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void redrsBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void txtpn_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtpp_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtpq_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void productid12_TextChanged(object sender, EventArgs e)
        {

        }

        private void adminwhiteBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtpn2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtwrid2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtproid2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtt2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtpp2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtpq2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView43_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void whitersBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void productid13_TextChanged(object sender, EventArgs e)
        {

        }

        private void adminyellowBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtpn3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtyrid3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtproid3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtt3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void txtpp3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void txtpq3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView44_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void yellowrsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void adminyellowBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void addminredBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void adminwhiteBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void riceandcurry3BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void riceandcurry2BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void riceandcurryBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void redricecBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void redricetableBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void redrtbBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void addminredBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void redrsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void addminredsBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void redrsBindingSource2_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void redrsBindingSource3_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void addminredsBindingSource2_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void redrsBindingSource4_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard("staff");
            this.Hide();
            ds.ShowDialog();
        }
    }
}
