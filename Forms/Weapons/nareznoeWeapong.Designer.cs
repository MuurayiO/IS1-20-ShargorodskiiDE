
namespace KRUS
{
    partial class nareznoeWeapong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.guna2Panel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(863, 486);
            this.panel2.TabIndex = 10;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderRadius = 20;
            this.guna2Panel2.Controls.Add(this.label1);
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(99)))), ((int)(((byte)(255)))));
            this.guna2Panel2.Location = new System.Drawing.Point(109, 12);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(625, 54);
            this.guna2Panel2.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(99)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Mont Bold", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Нарезное оружие";
            // 
            // nareznoeWeapong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(863, 486);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "nareznoeWeapong";
            this.Text = "nareznoeWeapong";
            this.panel2.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label label1;
    }
}