using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankamatikUygulaması
{
    public partial class Form2 : Form
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        SqlDataAdapter sqlDataAdapter;
        public void Liste()
        {
            sqlConnection = new SqlConnection("Data Source=DESKTOP-RF82O7V;Initial Catalog=Kullanicilar;Integrated Security=True;");
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter("select * from hesap", sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();
        }
        public Form2()
        {
            InitializeComponent();
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            Liste();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection("Data Source=DESKTOP-RF82O7V;Initial Catalog=Kullanicilar;Integrated Security=True;");
            sqlConnection.Open();
            sqlCommand = new SqlCommand("update hesap set bakiye=bakiye-@bakiye", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@bakiye", txtpara.Text);
            
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            Liste();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection("Data Source=DESKTOP-RF82O7V;Initial Catalog=Kullanicilar;Integrated Security=True;");
            sqlConnection.Open();
            sqlCommand = new SqlCommand("update hesap set bakiye=bakiye+@bakiye", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@bakiye", txtpara.Text);
            
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            Liste();
        }
    }
}
