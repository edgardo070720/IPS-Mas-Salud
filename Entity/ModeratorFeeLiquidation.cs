using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class ModeratorFeeLiquidation
    {
        public int NumberOfLiquidation { get; set; }
        public int ClientId { get; set; }
        public string  ClientName { get; set; }
        public string ClientLastName { get; set; }
        public string AffiliationType { get; set; }
        public double Salary { get; set; }
        public double ValueService { get; set; }
        public double Rate { get; set; }
        public double ModeratorFee { get; set; }
        public string MaximumStop { get; set; }
        public string RateApplied { get; set; }
        public DateTime Date { get; set; }
        public double SalaryMinimumValid { get; set; }

        public abstract void CalculateRate();
        public abstract void ValidateMaximumStop();
        public void CalculateModeratorFee()
        {
            CalculateRate();
            ModeratorFee = ValueService * Rate;
            RateApplied = $"{Rate * 100}%";
            ValidateMaximumStop();
        }
    }
}
