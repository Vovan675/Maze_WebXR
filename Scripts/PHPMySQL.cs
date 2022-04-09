using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class PHPMySQL : MonoBehaviour
{
    public TMP_InputField timeText;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SubmitTime()
    {
        StartCoroutine(SubmitTimeRoutine(Hook.name, int.Parse(timeText.text)));
    }

    IEnumerator SubmitTimeRoutine(string name, int time)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("time", time);
        
        using (UnityWebRequest req = UnityWebRequest.Post("http://26.191.121.140/submitScore.php", form))
        {
            yield return req.SendWebRequest();
            print(req.downloadHandler.text);
        }
    }


    [ContextMenu("GetData")]
    public void GetData()
    {
        StartCoroutine(GetInfo());
    }

    IEnumerator GetInfo()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", "123");
        using (UnityWebRequest req = UnityWebRequest.Post("http://localhost/display.php", form))
        {
            yield return req.SendWebRequest();
            print(req.downloadHandler.text);
        }
    }

    [ContextMenu("SetData")]
    public void SetData()
    {
        StartCoroutine(SetInfo());
    }

    IEnumerator SetInfo()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", "1234");
        form.AddField("time ", 1233);
        using (UnityWebRequest req = UnityWebRequest.Post("http://localhost/register.php", form))
        {
            yield return req.SendWebRequest();
            print(req.downloadHandler.text);
        }
    }
}
