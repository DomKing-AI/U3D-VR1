using UnityEngine;
using System.Collections;
//using UnityEditor.SceneManagement;
using UnityEngine.UI;


[RequireComponent(typeof(Collider))]
public class Look : MonoBehaviour
{
    private Vector3 startingPosition;
    int n;
    private Animation anim;
    bool flag = false;

    void Start()
    {
        startingPosition = transform.localPosition;
        SetGazedAt(false);
        n = 0;
        anim = transform.GetComponent<Animation>();
        anim.Stop();
    }

    void LateUpdate()
    {
        Cardboard.SDK.UpdateState();
        if (Cardboard.SDK.BackButtonPressed)
        {
            Application.Quit();
        }

    }

    public void SetGazedAt(bool gazedAt)
    {
        GameObject txt = GameObject.Find("Over/Text3D");
        //GameObject slider = GameObject.Find("Cube/Text3D/Canvas/Slider");
        if (gazedAt)
        {
            Debug.Log("光标选中");
            txt.GetComponent<TextMesh>().text = "Loading" + n.ToString() + "%";
            //slider.SetActive(true);
            //slider.GetComponent<Slider>().value = n;
            n += 1;
            this.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            Debug.Log("光标移开");
            //txt.GetComponent<TextMesh>().text = "";
            //slider.SetActive(false);
            //slider.GetComponent<Slider>().value = 0;
            n = 0;
            this.GetComponent<Renderer>().material.color = Color.red;
        }
        if (n == 100)
        {
            Debug.Log("进度完成!");
            flag = true;
            txt.GetComponent<TextMesh>().text = "";
            //slider.SetActive(false);
            //slider.GetComponent<Slider>().value = 0;
            n = 0;
            anim.Play();

            UnityEngine.SceneManagement.SceneManager.LoadScene("2");
        }
        // GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
    }
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