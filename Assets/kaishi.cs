using UnityEngine;
using System.Collections;
//using UnityEditor.SceneManagement;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class kaishi : MonoBehaviour
{
    private Vector3 startingPosition;
    int n;//凝视进度计算
    private Animation anim;//独立动画
    bool flag = false;//判定凝视有没有结束进度条
    void Start()
    {
        startingPosition = transform.localPosition;
        SetGazedAt(false);
        n = 0;//进度初始值
        anim = transform.GetComponent<Animation>();
        anim.Stop();
    }
    void LateUpdate()
    {
        Cardboard.SDK.UpdateState();
        if (Cardboard.SDK.BackButtonPressed)
        {
            Application.Quit();//退出程序
        }
       

    }
    public void SetGazedAt(bool gazedAt)
    {
        if (flag == false)
        {
            //GameObject slider = GameObject.Find("Text3d/Canvas/Slider");
            GameObject txt = GameObject.Find("Over/Text3d");
            //GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
            //凝视状态
            if (gazedAt)
            {
                Debug.Log("光标选中" + n.ToString());
                txt.GetComponent<TextMesh>().text = "Loading" + n.ToString() + "%";
                //slider.SetActive(true);
                //slider.GetComponent<Slider>().value = n;
                n += 1;//自动计数
                this.GetComponent<Renderer>().material.color = Color.blue;//外观响应
            }
            else
            {
                Debug.Log("光标移开");
                txt.GetComponent<TextMesh>().text = "";
                //slider.SetActive(false);
                //slider.GetComponent<Slider>().value = 0;
                n = 0;
                this.GetComponent<Renderer>().material.color = Color.red;//外观响应
            }
            //凝视结束
            if (n == 100)
            {
                Debug.Log("进度完成!");
                SceneManager.LoadScene("A");
            }

        }
    }
    //重启凝视
    public void replay()
    {
        flag = false;
    }
    public void Reset()
    {
        transform.localPosition = startingPosition;
    }
    public void ToggleVRMode()
    {
        Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
    }
    public void TeleportRandomly()
    {
        Vector3 direction = Random.onUnitSphere;
        direction.y = Mathf.Clamp(direction.y, 0.5f, 1f);
        float distance = 2 * Random.value + 1.5f;
        transform.localPosition = direction * distance;
    }
}