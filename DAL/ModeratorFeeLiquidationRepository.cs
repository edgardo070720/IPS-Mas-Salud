using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Entity;

namespace DAL
{
    public class ModeratorFeeLiquidationRepository
    {
        private readonly string NameFile = @"Liquidaciones.txt";

        public void Save(ModeratorFeeLiquidation liquidation)
        {
            FileStream file = new FileStream(NameFile,FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine($"{liquidation.NumberOfLiquidation};{liquidation.ClientId};{liquidation.ClientName};{liquidation.ClientLastName};" +
                $"{liquidation.AffiliationType};{liquidation.Salary};{liquidation.SalaryMinimumValid};{liquidation.RateApplied};" +
                $"{liquidation.ValueService};{liquidation.MaximumStop};{liquidation.ModeratorFee};{liquidation.Date}");
            writer.Close();
            file.Close();
        }

        public List<ModeratorFeeLiquidation> Consult()
        {
            List<ModeratorFeeLiquidation> liquidations = new List<ModeratorFeeLiquidation>();
            FileStream file = new FileStream(NameFile, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(file);
            string line = string.Empty;
            while ((line=reader.ReadLine())!=null)
            {
                ModeratorFeeLiquidation liquidation = MapLiquidation(line);
                liquidations.Add(liquidation);
            }
            reader.Close();
            file.Close();
            return liquidations;
        }
        private ModeratorFeeLiquidation MapLiquidation(string line)
        {
            string[]matrixOfLiquidation = line.Split(';');
            ModeratorFeeLiquidation liquidation = ValidateInstance(matrixOfLiquidation[4]);
            liquidation.NumberOfLiquidation =Int32.Parse(matrixOfLiquidation[0]);
            liquidation.ClientId = Int32.Parse(matrixOfLiquidation[1]);
            liquidation.ClientName = matrixOfLiquidation[2];
            liquidation.ClientLastName = matrixOfLiquidation[3];
            liquidation.AffiliationType = matrixOfLiquidation[4];
            liquidation.Salary = Double.Parse(matrixOfLiquidation[5]);
            liquidation.SalaryMinimumValid = Double.Parse(matrixOfLiquidation[6]);
            liquidation.RateApplied = matrixOfLiquidation[7];
            liquidation.ValueService = Double.Parse(matrixOfLiquidation[8]);
            liquidation.MaximumStop = matrixOfLiquidation[9];
            liquidation.ModeratorFee = Double.Parse(matrixOfLiquidation[10]);
            liquidation.Date = DateTime.Parse(matrixOfLiquidation[11]);
            return liquidation;
        }
        private ModeratorFeeLiquidation ValidateInstance(string affiliationType)
        {
            ModeratorFeeLiquidation liquidation;
            if (affiliationType.Equals("REGIMEN SUBSIDIADO"))
            {
                liquidation = new RegimeSubsidy();
            }
            else
            {
                    liquidation = new RegimeContributory();
            }
            return liquidation;
        }
        public ModeratorFeeLiquidation SearchLiquidation(int numberOfLiquidation)
        {
            IList<ModeratorFeeLiquidation> liquidations = Consult();
            return liquidations.Where(l => l.NumberOfLiquidation.Equals(numberOfLiquidation)).First();
        }
        public int ValidateExistenceLiquidation(int numberOfLiquidation)
        {
            IList<ModeratorFeeLiquidation> liquidations = Consult();
            return liquidations.Where(l => l.NumberOfLiquidation.Equals(numberOfLiquidation)).Count();
        }
        public void Delete(int numberOfLiquidation)
        {
            List<ModeratorFeeLiquidation> liquidations = new List<ModeratorFeeLiquidation>();
            liquidations = Consult();
            FileStream file = new FileStream(NameFile, FileMode.Create);
            file.Close();
            foreach (ModeratorFeeLiquidation liquidation in liquidations)
            {
                if (liquidation.NumberOfLiquidation!=numberOfLiquidation)
                {
                    Save(liquidation);
                }
            }
        }
    }
}
