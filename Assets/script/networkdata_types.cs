using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class networkdata_types
{


}
public struct login_data
{
  public  string username;
  public  string password;
  public  string currentMACAddress;
  public  string currentDeviceModel;
  public  string currentLatitude;
  public  string currentLongitude;
  public  string currentAddress;
   

}
/*
  "username": "BookieUser",
    "password": "12345678",
    "currentMACAddress": "00:25:96:FF:FE:22:36:59",
    "currentDeviceModel": "samsungA510",
    "currentLatitude": "40.785091",
    "currentLongitude": "-73.968285",
    "currentAddress": "Boo BOOm Boo"
 */