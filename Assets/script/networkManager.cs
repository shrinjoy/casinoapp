using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using RestSharp;
using System.Text;
using System;
public class networkManager : MonoBehaviour
{
    private dynamic output;
    public System.Net.HttpStatusCode statuscode;
    public string login(string uri,string jsondata)
    {   
        var client = new RestClient(uri);
        client.Timeout = -1;
        var request = new RestRequest(Method.POST);        
        request.AddParameter("application/json",jsondata, ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);
        statuscode = response.StatusCode;
        return(response.Content);
    }
    public string logout(string token)
    {
        var client = new RestClient("https://openmode-roulette.herokuapp.com/v1/auth/logout");
        client.Timeout = -1;      
        var request = new RestRequest(Method.POST);
        request.AddHeader("Authorization", "Bearer" + " " + token);
        IRestResponse response = client.Execute(request);
        statuscode = response.StatusCode;
        return response.Content;
    }
    public string getuserbyname(string username,string token)
    {
        print(token);
        RestClient client = new RestClient("https://openmode-roulette.herokuapp.com/v1/users/username/" + username);
        RestRequest request = new RestRequest(Method.GET);
        request.AddHeader("Authorization","Bearer" +" "+ token);
        IRestResponse respose = client.Execute(request);
        statuscode = respose.StatusCode;
        return respose.Content;
    }
   
   

}
