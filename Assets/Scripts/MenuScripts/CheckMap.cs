using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMap : MonoBehaviour
{
    public Flowchart fungus;
    private GameObject buttonRoute;

    private void Update()
    {
        if(fungus.GetVariable("IsAelarRoute") == true)
        {
            //buttonRoute = GameObject.Find("AelarRoute");
            buttonRoute = GameObject.Find("LonelyRoute");
            buttonRoute.SetActive(false);
        }
        else
        {
            buttonRoute = GameObject.Find("AelarRoute");
            buttonRoute.SetActive(false);
        }
    }
}
