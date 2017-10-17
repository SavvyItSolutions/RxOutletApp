using RxOutlet.Entity;
using RxOutlet.Services;
using System;
using System.Threading.Tasks;

namespace RxOutlet.BusinessRules
{
    public class RxOutletBR
    {
        RxOutletServiceWrapper service = new RxOutletServiceWrapper();

        #region SignUp

        /// <summary>
        /// SignUp
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        #endregion

        #region Login

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// CheckDrivingLicense
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public async Task<DrivingLicenseResponse> CheckDrivingLicense(string userID)
        {
            try
            {
                return await service.CheckDrivingLicense(userID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Priscription

        public async Task<UploadPrescriptionResponse> UploadPrescription(UploadPrescriptionModel model)
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

        public async Task<TransferPrescriptionResponse> TransferPrescription(TransferPrescriptionModel model)
        {
            try
            {
                return await service.TransferPrescription(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
