using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public TMPro.TMP_Text text;
    public static string name = "base name";
    public void SetName(string name)
    {
        Hook.name = name;
        text.text = "Name: " + name;
    }
}
