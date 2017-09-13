using RxOutlet.Models;
using RxOutlet.Services;
using System;
using System.Threading.Tasks;

namespace RxOutlet.BusinessRules
{
    public class RxOutletBR
    {
        RxOutletServiceWrapper service = new RxOutletServiceWrapper();
        
        public async Task<RegistrationResponseModel> SignUp(RegistrationModel model)
        {
            try
            {
                return await service.SignUp(model);
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

        public async Task<int> UploadPrescription(UploadPrescriptionModel model)
        {
            try
            {
                return await service.UploadPrescription(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
