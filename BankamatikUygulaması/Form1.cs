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
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        public Form1()
        {
            InitializeComponent();
        }
        byte deneme = 3;
        private void btngiris_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection("Data Source=DESKTOP-RF82O7V;Initial Catalog=Kullanicilar;Integrated Security=True;");
            command = new SqlCommand("select * from bilgiler where tc=@tc and sifre=@sifre", connection);
            command.Parameters.AddWithValue("@tc",txttc.Text);
            command.Parameters.AddWithValue("sifre",txtsifre.Text);
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre");
                deneme--;
                if (deneme==0)
                {
                    MessageBox.Show("deneme hakkı kalmadı");
                    
                    Application.Exit();
                }
            }
            
        }
    }
}
