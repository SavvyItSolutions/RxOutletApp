using System;
using Foundation;
using UIKit;
using RxOutlet.Dependency;
using System.Net;
using SystemConfiguration;
using CoreFoundation;
using Security;
using Xamarin.Forms;
using RxOutlet.iOS.DependencyImplementation;

[assembly:Dependency(typeof(iOSDeviceInformation))]
namespace RxOutlet.iOS.DependencyImplementation
{
    public class iOSDeviceInformation : IDeviceInformation
    {
        private NetworkReachability defaultRouteReachability;
        private event EventHandler ReachabilityChanged;
        
        public bool CheckDeviceInternetAccess()
        {
            try
            {
                NetworkReachabilityFlags flags;
                bool defaultNetworkAvailable = IsNetworkAvailable(out flags);

                if (defaultNetworkAvailable && (flags & NetworkReachabilityFlags.IsDirect) != 0) return false;

                else if ((flags & NetworkReachabilityFlags.IsWWAN) != 0) return true;

                else if (flags == 0) return false;

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetDeviceID()
        {
            try
            {
                string serial = string.Empty;
                var query = new SecRecord(SecKind.GenericPassword);
                query.Service = NSBundle.MainBundle.BundleIdentifier;
                query.Account = "UniqueID";

                NSData uniqueId = SecKeyChain.QueryAsData(query);
                if (uniqueId == null)
                {
                    NSUuid identifier = UIDevice.CurrentDevice.IdentifierForVendor;
                    if (identifier.ToString().Contains(">"))
                    {
                        string[] deviceID = identifier.ToString().Split('>');
                        serial = deviceID[1];
                    }
                    else
                    {
                        serial = identifier.ToString();
                    }
                    
                    query.ValueData = NSData.FromString(serial.Trim());

                    var err = SecKeyChain.Add(query);
                    if (err != SecStatusCode.Success && err != SecStatusCode.DuplicateItem)
                        throw new Exception("Cannot store Unique ID");

                    return query.ValueData.ToString();
                }
                else
                {
                    return uniqueId.ToString();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Methods

        private bool IsNetworkAvailable(out NetworkReachabilityFlags flags)
        {
            try
            {
                if (defaultRouteReachability == null)
                {
                    defaultRouteReachability = new NetworkReachability(new IPAddress(0));
                    defaultRouteReachability.SetNotification(OnChange);
                    defaultRouteReachability.Schedule(CFRunLoop.Current, CFRunLoop.ModeDefault);
                }
                if (!defaultRouteReachability.TryGetFlags(out flags))  return false;

                return IsReachableWithoutRequiringConnection(flags);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        private void OnChange(NetworkReachabilityFlags flags)
        {
            try
            {
                ReachabilityChanged?.Invoke(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool IsReachableWithoutRequiringConnection(NetworkReachabilityFlags flags)
        {
            try
            {
                // Is it reachable with the current network configuration?
                bool isReachable = (flags & NetworkReachabilityFlags.Reachable) != 0;

                // Do we need a connection to reach it?
                bool noConnectionRequired = (flags & NetworkReachabilityFlags.ConnectionRequired) == 0;

                // Since the network stack will automatically try to get the WAN up,
                // probe that
                if ((flags & NetworkReachabilityFlags.IsWWAN) != 0)
                    noConnectionRequired = true;

                return isReachable && noConnectionRequired;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        #endregion
        
    }
}