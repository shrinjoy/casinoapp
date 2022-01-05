using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerData : MonoBehaviour
{
    [SerializeField]
    string id_token;
    [SerializeField]
    string access_token;
    [SerializeField]
    string playername;

    public string TOKEN
    {
         get { return id_token; }
         set { id_token = value; }
    }

    public string ACCESSTOKEN
    {
        get { return access_token; }
        set { access_token = value; }
    }
    public string PLAYERNAME
    {
        get { return playername; }
        set { playername = value; }
    }
}
