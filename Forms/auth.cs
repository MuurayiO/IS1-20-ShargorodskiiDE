using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace KRUS
{

    public partial class auth : Form
    {
        public auth()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;           
        }

        string connStr = "server=10.90.12.110;port=33333;user=st_1_20_31;database=is_1_20_st31_KURS;password=14639122;";
        MySqlConnection conn;

        private void auth_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
            Region = new Region(kraya.RoundedRect(new Rectangle(0, 0, Width, Height), 20));
        }
        //
        // События
        //
        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
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
        private void pass_TextChanged(object sender, EventArgs e)
        {
            pass.UseSystemPasswordChar = true;
        }

        private void auth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2Button1_Click(guna2Button1, null);
            }
        }     
        
        Point lastPoint;
        private void auth_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }

        private void auth_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        //     
        // Авторизация
        //
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

        public void GetUserInfo(string login_user)
        {
            string selected_id_stud = guna2TextBox1.Text;
            conn.Open();
            string sql = $"SELECT * FROM login_password WHERE login='{login_user}'";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                authclass.auth_id = reader[0].ToString();
                authclass.auth_fio = reader[1].ToString();
            }
            reader.Close();
            conn.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM login_password WHERE login = @un";
            conn.Open();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@un", MySqlDbType.VarChar, 25);
            command.Parameters.Add("@up", MySqlDbType.VarChar, 25);
            command.Parameters["@un"].Value = guna2TextBox1.Text;
            command.Parameters["@up"].Value = sha256(pass.Text);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            conn.Close();          
            if (table.Rows.Count > 0)
            {
                authclass.auth = true;
                GetUserInfo(guna2TextBox1.Text);
                Close();
            }
            else
            {
                MessageBox.Show("Неверные данные авторизации!");
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Register reg = new Register();           
            reg.ShowDialog();
        }
    }
}