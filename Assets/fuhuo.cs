using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;
[RequireComponent(typeof(Collider))]
public class fuhuo : MonoBehaviour
{
    private Vector3 startingPosition;
    int n;//凝视进度计算
    void Start()
    {
        startingPosition = transform.localPosition;
        SetGazedAt(false);
        n = 0;//进度初始值
    }
    void LateUpdate()
    {
        Cardboard.SDK.UpdateState();
        if (Cardboard.SDK.BackButtonPressed)
        {
            Application.Quit();//退出程序
        }
        if (n == 100)
        {
            Debug.Log("进度完成!");
            SceneManager.LoadScene("A");
        }
    }
    public void SetGazedAt(bool gazedAt)
    {
        GameObject txt1 = GameObject.Find("Cube1/Text3d");
        if (gazedAt)
        {
            Debug.Log("光标选中" + n.ToString());
            txt1.GetComponent<TextMesh>().text = "复活中" + n.ToString() + "%";
            //slider.SetActive(true);
            //slider.GetComponent<Slider>().value = n;
            n += 1;//自动计数
            this.GetComponent<Renderer>().material.color = Color.blue;//外观响应
        }
        else
        {
            Debug.Log("光标移开");
            txt1.GetComponent<TextMesh>().text = "";
            //slider.SetActive(false);
            //slider.GetComponent<Slider>().value = 0;
            n = 0;
            this.GetComponent<Renderer>().material.color = Color.green;//外观响应
        }
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
