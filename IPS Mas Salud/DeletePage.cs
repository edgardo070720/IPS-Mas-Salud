using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BLL;

namespace IPS_Mas_Salud
{
    public partial class DeletePage : Form
    {
        private readonly ModeratorFeeLiquidationService service;
        public DeletePage()
        {
            InitializeComponent();
            service = new ModeratorFeeLiquidationService();
        }

        private void DeletePage_Load(object sender, EventArgs e)
        {
            LookLiquidationTable();
        }
        private void LookLiquidationTable()
        {
            List<ModeratorFeeLiquidation> liquidations = new List<ModeratorFeeLiquidation>();
            liquidations = service.LiquidationConsult().Liquidations;
            DtgvLiquidationTable.DataSource = liquidations;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteLiquidation();
            LookLiquidationTable();
        }
        private void DeleteLiquidation()
        {
            MessageBox.Show(service.DeleteLiquidation(Int32.Parse(txtDelete.Text)));
        }
    }
}
