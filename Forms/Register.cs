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
        private void pass_TextChanged(object sender, EventArgs e)
        {
            pass.UseSystemPasswordChar = true;
        }

        private void checkPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPass.Checked)
            {
                pass.UseSystemPasswordChar = false;
            }
            else
            {
                pass.UseSystemPasswordChar = true;
            }
        }

        static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (checkUser())
            {
                return;
            }

            if (fio.Text == "" || phone.Text == "" || user.Text == "" || pass.Text == "")
            {
                MessageBox.Show("Введите пустые поля");
                return;
            }

            MySqlCommand command = new MySqlCommand("INSERT INTO `login_password` (`id_login_password`, `login`, `password`, `fio`, `phone`) " +
                "VALUES (NULL, @login, @password, @fio, @phone);", conn);
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = user.Text;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = sha256(pass.Text);
            command.Parameters.Add("@fio", MySqlDbType.VarChar).Value = fio.Text;
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone.Text;

            conn.Open();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Пользователь зарегистрирован");               
                Close();                
            }
            conn.Close();
        }

        public Boolean checkUser()
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM login_password WHERE login = @un", conn);
            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = user.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже существует");
                return true;
            }
            else
            {
                return false;
            }

        }       
    }
}
