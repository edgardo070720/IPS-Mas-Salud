using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using System.Security.Policy;

namespace BLL
{
    public class ModeratorFeeLiquidationService
    {
        private readonly ModeratorFeeLiquidationRepository repository;
        public ModeratorFeeLiquidationService()
        {
            repository = new ModeratorFeeLiquidationRepository();
        }

        public string SaveLiquidation(ModeratorFeeLiquidation liquidation)
        {
            try
            {
                if (repository.ValidateExistenceLiquidation(liquidation.NumberOfLiquidation)==0)
                {
                    repository.Save(liquidation);
                    return "Se Guardo La Liquidacion Satisfactoriamente";
                }
                return "Ya Existe Una Liquidacion Con Este Numero";
            }
            catch (Exception e)
            {
                return "Se Produjo Un Error Al Momento De Guardar: " + e.Message;
            }
        }
        public LiquidationConsultationResponse LiquidationConsult()
        {
            LiquidationConsultationResponse response = new LiquidationConsultationResponse();
            try
            {
                response.Liquidations = repository.Consult();
                response.Error = false;
                return response;
            }
            catch (Exception e)
            {
                response.Liquidations = null;
                response.Message = "Se Produjo Un Error Al Momento De Consultar Los Datos: " + e.Message;
                response.Error = true;
                return response;
            }
        }
        public string DeleteLiquidation(int numberOfLiquidation)
        {
            try
            {
                if (repository.ValidateExistenceLiquidation(numberOfLiquidation)>0)
                {
                    repository.Delete(numberOfLiquidation);
                    return "Se Elimino La Liquidacion Satisfactoriamente";
                }
                return "No Existe Liquidacion Con Este Numero ";
            }
            catch (Exception e)
            {

                return "Error Al Momento De Eliminar: " + e.Message;
            }
        }
    }
    public class LiquidationConsultationResponse
    {
        public  string Message;
        public bool Error;
        public  List<ModeratorFeeLiquidation> Liquidations;
        public LiquidationConsultationResponse()
        {
            Liquidations = new List<ModeratorFeeLiquidation>();
        }
    }
}
