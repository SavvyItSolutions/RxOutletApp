
namespace RxOutlet.Entity
{
    public class LoginResponse : BaseServiceResponse
    {
        public bool IsMailConfirmed { get; set; }
        public string UserID { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
