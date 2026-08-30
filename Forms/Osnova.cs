using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pacient
{
    public partial class Osnova : Form
    {
        public Osnova()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            guna2Button2.BackColor = Color.FromArgb(46, 51, 73);

            guna2HtmlLabel2.Text = "Карточка пациента";
            this.guna2CustomGradientPanel1.Controls.Clear();
            CardPacient FrmDashboard_Vrb = new CardPacient() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.guna2CustomGradientPanel1.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Button1.BackColor = Color.FromArgb(46, 51, 73);

            guna2HtmlLabel2.Text = "Аккаунт";
            this.guna2CustomGradientPanel1.Controls.Clear();
            Accaunt FrmDashboard_Vrb = new Accaunt() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.guna2CustomGradientPanel1.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2Button3.BackColor = Color.FromArgb(46, 51, 73);

            guna2HtmlLabel2.Text = "Заявка на прием";
            this.guna2CustomGradientPanel1.Controls.Clear();
            Application2 FrmDashboard_Vrb = new Application2() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.guna2CustomGradientPanel1.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
