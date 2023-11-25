using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public int playerSpeed = 1;
    public int rSpeed = 50;
    public int headLeanAngle=45;
    public int headTilt=30;    

    public float DOUBLE_CLICK_TIME = 0.2f;
    private float lastClickTime;  
   
    void Update()
    {       
        //KeyBoard Input:=============================
        if (Input.GetKey("up"))
        {
             transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
        }

        if (Input.GetKey("down"))
        {
             transform.position = transform.position - Camera.main.transform.forward * playerSpeed * Time.deltaTime;
        }

        if (Input.GetKey("left"))
        {
            //transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * playerSpeed*rSpeed, Space.World);
             transform.position = transform.position - Camera.main.transform.right * playerSpeed * Time.deltaTime;
        }

        if (Input.GetKey("right"))
        {
            //transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * playerSpeed*rSpeed, Space.World);
             transform.position = transform.position + Camera.main.transform.right * playerSpeed * Time.deltaTime;
        }

        //keyboard double click:
        /*if (Input.GetKeyUp("right"))
        {
            float timeSinceLastClick = Time.time - lastClickTime;
            Debug.Log(lastClickTime +"   "+ Time.time +"   "+ timeSinceLastClick );

            if(timeSinceLastClick<=DOUBLE_CLICK_TIME)
            {
                transform.Rotate(new Vector3(0, 1, 0) * 30, Space.World);
            }
            lastClickTime = Time.time;
        }*/

        /*if (Input.GetKeyUp("left"))
        {
            float timeSinceLastClick = Time.time - lastClickTime;
            Debug.Log(lastClickTime +"   "+ Time.time +"   "+ timeSinceLastClick );

            if(timeSinceLastClick<=DOUBLE_CLICK_TIME)
            {
                transform.Rotate(new Vector3(0, -1, 0) * 30, Space.World);
            }
            lastClickTime = Time.time;
        }*/
        //Head Gesture input:================================

        Debug.Log(Camera.main.transform.eulerAngles);

        if (Camera.main.transform.eulerAngles.z>headTilt && Camera.main.transform.eulerAngles.z<90)
        {
              transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * playerSpeed*rSpeed, Space.World);
        }

        if (Camera.main.transform.eulerAngles.z>270 && Camera.main.transform.eulerAngles.z<360-headTilt)
        {
              transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * playerSpeed*rSpeed, Space.World);
        }

        if (Camera.main.transform.eulerAngles.x>headLeanAngle && Camera.main.transform.eulerAngles.x<90)
        {
             transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
        }

    }

}
