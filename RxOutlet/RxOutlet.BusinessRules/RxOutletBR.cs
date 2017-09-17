using RxOutlet.Entity;
using RxOutlet.Services;
using System;
using System.Threading.Tasks;

namespace RxOutlet.BusinessRules
{
    public class RxOutletBR
    {
        RxOutletServiceWrapper service = new RxOutletServiceWrapper();
        
        public async Task<SignUpResponseModel> SignUp(SignUpModel model)
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

        public async Task<LoginResponse> Login(LoginModel model)
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

        public async Task<int> UploadProfilePic(ByteArrayModel model)
        {
            try
            {
                return await service.UploadProfilePic(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
