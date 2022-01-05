using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;
public class AboutUser_UI : MonoBehaviour
{
    networkManager nm = new networkManager();
    public playerData playerdata;
    dynamic output;
    public TMPro.TMP_Text username;
    public TMPro.TMP_Text address;
    public TMPro.TMP_Text role;
    public GameObject loginpage;
    public void logout()
    {
       
        nm.logout(playerdata.ACCESSTOKEN);
        this.gameObject.SetActive(false);
        loginpage.SetActive(true);
    }
    private void Start()
    {
      output=JsonConvert.DeserializeObject(nm.getuserbyname(playerdata.PLAYERNAME, playerdata.ACCESSTOKEN));
      username.text= ("username:"+Convert.ToString(output.data.user.username));
      address.text= ("address:"+Convert.ToString(output.data.user.currentLocation.address));
      role.text = ("role:"+Convert.ToString(output.data.user.role));
    }
}
