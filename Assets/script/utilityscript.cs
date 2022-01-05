using UnityEngine;
using System.Collections;
using System.Net.NetworkInformation;
using UnityEngine.Networking;
public static class utilityscript 
{
    public static string GetMacAddress()
    {
        string physicalAddress = "";
        NetworkInterface[] networkinterface = NetworkInterface.GetAllNetworkInterfaces();
        foreach (NetworkInterface adaper in networkinterface)
        {
            Debug.Log(adaper.Description);
            if (adaper.Description == "en0")
            {
                physicalAddress = adaper.GetPhysicalAddress().ToString();
                break;
            }
            else
            {
                physicalAddress = adaper.GetPhysicalAddress().ToString();
                if (physicalAddress != "")
                {
                    break;
                };
            }
        }
        return physicalAddress;
    }
   
}
