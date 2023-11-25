using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int Speed = 1;
    public Transform w;//目标位置
    private Vector3 qt; //自身初始位置
    void Start()
    {

        qt = this.transform.position;
    }



    // Use this for initialization
    void Update()
    {
        if (transform.tag == "zs")
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, qt, Speed*Time.deltaTime);// Camera.main.transform.forward * OverSpeed * Time.deltaTime;
            this.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else if (transform.tag == "zq")
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, w.position,Speed*Time.deltaTime);// - Camera.main.transform.forward * OverSpeed;// * Time.deltaTime;
            
        }
    }

    // Update is called once per frame
    /*public bool Ts()
    {
        if (GameObject.FindWithTag("zq"))
        {
            GameObject.FindWithTag("zq").tag = "zs";

        }
        transform.tag = "zq";
        return true;
    }*/
}

