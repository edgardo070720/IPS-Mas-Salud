using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPS_Mas_Salud
{
    public partial class PagePrincipal : Form
    {
        public PagePrincipal()
        {
            InitializeComponent();
        }

        private void PagePrincipal_Load(object sender, EventArgs e)
        {
            OpenPanel(new PageOfIcon());
            PbBehind.Visible = false;
            PnlMenu.Width = 0;
        }
        private void OpenPanel(object windows)
        {
            if (this.PnlContainer.Controls.Count > 0)
                this.PnlContainer.Controls.RemoveAt(0);
            Form vn = windows as Form;
            vn.TopLevel = false;
            vn.Dock = DockStyle.Fill;
            this.PnlContainer.Controls.Add(vn);
            this.PnlContainer.Tag = vn;
            vn.Show();
        }

        private void PbContract_Click(object sender, EventArgs e)
        {
            PnlMenu.Width = 0;
            PbExpand.Visible = true;
        }

        private void PbExpand_Click(object sender, EventArgs e)
        {
            PnlMenu.Width = 149;
            PbExpand.Visible = false;
        }

        private void BtnRegistration_Click(object sender, EventArgs e)
        {
            OpenPanel(new RegistrationPage());
            PbBehind.Visible = true;
            PnlMenu.Width = 0;
            PbExpand.Visible = true;
        }

       

        private void PbBehind_Click_1(object sender, EventArgs e)
        {
            OpenPanel(new PageOfIcon());
            PbBehind.Visible = false;
            PnlMenu.Width = 0;
            PbExpand.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PbBehind.Visible = true;
            OpenPanel(new ConsultationPage());
            PnlMenu.Width = 0;
            PbExpand.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenPanel(new DeletePage());
            PbBehind.Visible = true;
            PnlMenu.Width = 0;
            PbExpand.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PnlMenu.Width = 0;
            PbExpand.Visible = true;
        }
    }
}
