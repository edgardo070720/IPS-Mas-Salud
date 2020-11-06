using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entity;

namespace IPS_Mas_Salud
{
    public partial class ConsultationPage : Form
    {
        private readonly ModeratorFeeLiquidationService service;
        public ConsultationPage()
        {
            InitializeComponent();
            service = new ModeratorFeeLiquidationService();
        }

        private void ConsultationPage_Load(object sender, EventArgs e)
        {
            LookLiquidationTable();
        }
        private void LookLiquidationTable()
        {
            List<ModeratorFeeLiquidation> liquidations = new List<ModeratorFeeLiquidation>();
            liquidations = service.LiquidationConsult().Liquidations;
            DtgvLiquidationTable.DataSource = liquidations;
            if (service.LiquidationConsult().Error)
            {
                MessageBox.Show(service.LiquidationConsult().Message);
            }
        }
    }
}
