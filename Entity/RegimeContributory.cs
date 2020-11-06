using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RegimeContributory : ModeratorFeeLiquidation
    {
        public override void CalculateRate()
        {
            if (Salary<2*SalaryMinimumValid)
            {
                Rate = 0.15;
            }
            if ((Salary>=2*SalaryMinimumValid)&&(Salary<=5*SalaryMinimumValid))
            {
                Rate = 0.2;
            }
            if (Salary>5*SalaryMinimumValid)
            {
                Rate = 0.25;
            }
        }

        public override void ValidateMaximumStop()
        {
            if (Salary < 2 * SalaryMinimumValid)
            {
                if (ModeratorFee>250000)
                {
                    ModeratorFee = 250000;
                    MaximumStop = "Aplica";
                }
                else
                {
                    MaximumStop = "No Aplica";
                }
            }
            if ((Salary >= 2 * SalaryMinimumValid) && (Salary <= 5 * SalaryMinimumValid))
            {
                if (ModeratorFee > 900000)
                {
                    ModeratorFee = 900000;
                    MaximumStop = "Aplica";
                }
                else
                {
                    MaximumStop = "No Aplica";
                }
            }
            if (Salary > 5 * SalaryMinimumValid)
            {
                if (ModeratorFee > 1500000)
                {
                    ModeratorFee = 1500000;
                    MaximumStop = "Aplica";
                }
                else
                {
                    MaximumStop = "No Aplica";
                }
            }
        }
    }
}
