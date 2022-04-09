using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WebGLTest : MonoBehaviour
{
    public TMP_Text text;

    private void Start()
    {
        WebGLInput.captureAllKeyboardInput = false;
    }

    public void SetText()
    {
        text.text = "Function called!";
    }
}
