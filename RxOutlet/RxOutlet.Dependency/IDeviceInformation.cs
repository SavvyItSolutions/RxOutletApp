
namespace RxOutlet.Dependency
{
    public interface IDeviceInformation
    {
        string GetDeviceID();

        bool CheckDeviceInternetAccess();
    }
}
