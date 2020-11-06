using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RegimeSubsidy : ModeratorFeeLiquidation
    {
        public override void CalculateRate()
        {
            Rate=0.05;
        }

        public override void ValidateMaximumStop()
        {
            if (ModeratorFee>200000)
            {
                ModeratorFee = 200000;
                MaximumStop = "Aplica";
            }
            else
            {
                MaximumStop = "No Aplica";
            }
        }
    }
}
