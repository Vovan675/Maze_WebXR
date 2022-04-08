using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DatabaseManager : MonoBehaviour
{
    [HideInInspector]
    public DatabaseManager instance;

    void Start()
    {
        if (instance)
        {
            Destroy(this);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);
    }
    
    [ContextMenu("Send")]
    public void SetScore()
    {
        StartCoroutine(SetScoreRoutine("Снова воа ахахах", -1));
    }

    IEnumerator SetScoreRoutine(string name, int time)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("time", time);

        using (var req = UnityWebRequest.Post("http://localhost/setScore.php", form))
        {
            yield return req.SendWebRequest();
            print(req.downloadHandler.text);
        }
    }
}
