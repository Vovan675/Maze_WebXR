using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class XRButton : MonoBehaviour
{
    public UnityEvent onClick;
    Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    public void OnClick()
    {
        onClick.Invoke();
    }

    public void SetSelected(bool selected)
    {
        if (selected)
        {
            material.color = new Color(1.0f, 0.7f, 0.7f);
        }
        else
        {
            material.color = Color.white;
        }
    }
}
