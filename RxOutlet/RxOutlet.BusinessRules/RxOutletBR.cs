using RxOutlet.Models;
using RxOutlet.Services;
using System;
using System.Threading.Tasks;

namespace RxOutlet.BusinessRules
{
    public class RxOutletBR
    {
        RxOutletServiceWrapper service = new RxOutletServiceWrapper();
        
        public async Task<RegistrationResponseModel> RegModel(RegistrationModel model)
        {
            try
            {
                return await service.Registration(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Login(LoginModel model)
        {
            try
            {
                return await service.Login(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
