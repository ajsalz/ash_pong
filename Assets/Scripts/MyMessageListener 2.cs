using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class messageListener : MonoBehaviour
{
    void onMessageArrived(string msg)
    {
        Debug.Log("Arrived: " + msg);
    }

    void onConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device Connected" : "Device Disconnected");
    }
}


