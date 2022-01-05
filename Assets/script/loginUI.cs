using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
public class loginUI : MonoBehaviour
{
    networkManager networkmanager = new networkManager();
    dynamic output;
    string temp_output;
    public TMPro.TMP_InputField username;
    public TMPro.TMP_InputField password;
    public GameObject aboutpanel;
    public playerData playerdata;
    public GameObject invalidmacmessage;
    public UnityEngine.UI.Toggle superusermode;
    IEnumerator showmessage()
    {
        invalidmacmessage.SetActive(true);
        yield return new WaitForSeconds(3);
        invalidmacmessage.SetActive(false);
    }
    public void loginbutton()
    {
        login_data data = new login_data();
        data.username = (username.text).ToString().Trim();
        data.password = (password.text).ToString().Trim();
        if(superusermode.isOn)
        {
            data.currentMACAddress = "00:25:96:FF:FE:12:34:56";
        }
        else
        {
            data.currentMACAddress = utilityscript.GetMacAddress();//"00:25:96:FF:FE:12:34:56";
        }
       
        data.currentLongitude = "30.785091";
        data.currentLatitude = "-53.968285";
        data.currentAddress = "testadress";
        data.currentDeviceModel = "dummymodel";
        output = JsonConvert.DeserializeObject(networkmanager.login("https://openmode-roulette.herokuapp.com/v1/auth/login", JsonConvert.SerializeObject(data)));
        temp_output = Convert.ToString(output);
        print(Convert.ToString(output));
        if((int)networkmanager.statuscode == 201)
        {
            if (temp_output.Contains("access_token") == true)
            {
                print(Convert.ToString(output.data.access_token));
                playerdata.ACCESSTOKEN = Convert.ToString(output.data.access_token);
                playerdata.PLAYERNAME = data.username;
                this.gameObject.SetActive(false);
                aboutpanel.SetActive(true);
            }
            else if(temp_output.Contains("message") == true)
            {
                StartCoroutine(showmessage());
            }
        }
        else if((int)networkmanager.statuscode==400)
        {
            print("wrong user name or password ");
        }
    }
}
