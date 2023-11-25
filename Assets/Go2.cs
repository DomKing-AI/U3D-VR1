using System.Collections;
using System.Collections.Generic;
//using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Go2 : MonoBehaviour
{
    public void Log(string msg)
    {
        Debug.Log(msg);
    }

    //碰撞开始,碰撞后跳转场景  
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene("A");
        }
    }
}
