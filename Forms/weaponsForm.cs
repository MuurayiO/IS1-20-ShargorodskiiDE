using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KRUS
{
    public partial class weaponsForm : Form
    {
        public weaponsForm()
        {
            InitializeComponent();
        }

        public void loadForm(object Form)
        {
            if (panel2.Controls.Count > 0) panel2.Controls.RemoveAt(0);
            Form form = Form as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panel2.Controls.Add(form);
            panel2.Tag = form;
            form.Show();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            loadForm(new gladkoWeapon());
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            loadForm(new nareznoeWeapong());
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            loadForm(new samooboronaWeapon());
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            loadForm(new pnevmat());
        }
    }
}
