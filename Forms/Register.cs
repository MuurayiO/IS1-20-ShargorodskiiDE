using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KRUS
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        string connStr = "server=10.90.12.110;port=33333;user=st_1_20_31;database=is_1_20_st31_KURS;password=14639122;";
        MySqlConnection conn;

        private void Register_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
            Region = new Region(kraya.RoundedRect(new Rectangle(0, 0, Width, Height), 20));
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `login_password` (`id_login_password`, `login`, `password`) VALUES ('2', @login, @password);", conn);
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = user.Text;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = pass.Text;
            conn.Open();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("KRUTO");
            }
            else
            {
                MessageBox.Show("NE KRUTO");
            }
            conn.Close();

        }      
    }
}
