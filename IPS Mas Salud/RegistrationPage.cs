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
    public partial class RegistrationPage : Form
    {
        private readonly ModeratorFeeLiquidationService service;
        public RegistrationPage()
        {
            InitializeComponent();
            service = new ModeratorFeeLiquidationService();
        }

        private void PbBehind_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void RegisterLiquidation()
        {
           
            ModeratorFeeLiquidation liquidation;
            DateTime date = DateTime.Today;
            if (CmbAffiliationType.Text.Equals("REGIMEN SUBSIDIADO"))
            {
                liquidation = new RegimeSubsidy();
            }
            else
            {
                liquidation = new RegimeContributory();
            }
            liquidation.NumberOfLiquidation =Int32.Parse(TxtNumberOfLiquidation.Text);
            liquidation.ClientId = Int32.Parse(TxtClientId.Text);
            liquidation.ClientName = TxtName.Text.ToUpper();
            liquidation.ClientLastName = TxtLastName.Text.ToUpper();
            liquidation.AffiliationType = CmbAffiliationType.Text.ToUpper();
            liquidation.Salary = Double.Parse(TxtSalary.Text);
            liquidation.ValueService = Double.Parse(TxtValueService.Text);
            liquidation.SalaryMinimumValid = Double.Parse(TxtMinimumSalaryValid.Text);
            liquidation.Date =DateTime.Parse(DateTime.Today.ToString("dd/MM/yyyy"));
            liquidation.CalculateModeratorFee();
           MessageBox.Show(service.SaveLiquidation(liquidation));
        }
     

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            RegisterLiquidation();
        }
    }
}
