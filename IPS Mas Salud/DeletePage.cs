﻿using System;
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
            dtgvLiquidationTable.ColumnCount = 12;
            dtgvLiquidationTable.ColumnHeadersVisible = true;
            dtgvLiquidationTable.Columns[0].Name = "NUMERO DE LIQUIDACION";
            dtgvLiquidationTable.Columns[1].Name = "CEDULA";
            dtgvLiquidationTable.Columns[2].Name = "NOMBRES";
            dtgvLiquidationTable.Columns[3].Name = "APELLIDOS";
            dtgvLiquidationTable.Columns[4].Name = "TIPO DE AFILIACION";
            dtgvLiquidationTable.Columns[5].Name = "SALARIO";
            dtgvLiquidationTable.Columns[6].Name = "VALOR DEL SERVICIO";
            dtgvLiquidationTable.Columns[7].Name = "CUOTA MODERADORA";
            dtgvLiquidationTable.Columns[8].Name = "TOPE MAXIMO";
            dtgvLiquidationTable.Columns[9].Name = "TARIFA APLICADA";
            dtgvLiquidationTable.Columns[10].Name = "FECHA";
            dtgvLiquidationTable.Columns[11].Name = "SALARIO MINIMO VIGENTE";
            foreach (ModeratorFeeLiquidation liquidation in liquidations)
            {
                dtgvLiquidationTable.Rows.Add(liquidation.NumberOfLiquidation, liquidation.ClientId, liquidation.ClientName, liquidation.ClientLastName,
                    liquidation.AffiliationType, liquidation.Salary, liquidation.ValueService, liquidation.ModeratorFee, liquidation.MaximumStop,
                    liquidation.RateApplied, liquidation.Date, liquidation.SalaryMinimumValid);
            }
            if (service.LiquidationConsult().Error)
            {
                MessageBox.Show(service.LiquidationConsult().Message);
            }
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
