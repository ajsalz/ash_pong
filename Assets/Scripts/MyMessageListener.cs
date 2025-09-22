using UnityEngine;

public class MyMessageListener : MonoBehaviour
{ 
    public static float horizontal = 0f;
    public static float vertical = 0f;

    private float holdTime = .4f;
    private float releaseTime = 0f;

    void OnMessageArrived(string msg)
    {
        Debug.Log("Arrived: " + msg);
        msg = msg.Trim().ToLower();

        if (msg == null)
            return;

        switch (msg)
        {
            case "right":
                horizontal = 1f;
                releaseTime = Time.time + holdTime;
                break;
            case "left":
                horizontal = -1f;
                releaseTime = Time.time + holdTime;
                break;
            case "up":
                vertical = 1f;
                releaseTime = Time.time + holdTime;
                break;
        }
        Debug.Log("Horizontal: " + horizontal);
    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device Connected" : "Device Disconnected");
    }

    void Update()
    { 
        if(Time.time > releaseTime)
        {
            vertical = 0f;
            horizontal = 0f;
        }
    }
}


