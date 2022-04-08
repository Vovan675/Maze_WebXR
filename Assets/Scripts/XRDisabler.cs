using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebXR;

public class XRDisabler : MonoBehaviour
{
    public List<Object> VROnly;
    public List<Object> KeyboardOnly;
    public Transform mainCamera;

    WebXRState editorDefault = WebXRState.VR;//
    WebXRState webDefault = WebXRState.NORMAL;

    private void OnEnable()
    {
        WebXRManager.OnXRChange += OnXRChange;
    }

    private void OnDisable()
    {
        WebXRManager.OnXRChange -= OnXRChange;
    }

    void Start()
    {
#if UNITY_EDITOR
        OnXRChange(editorDefault, 0, Rect.zero, Rect.zero);
#else
        OnXRChange(webDefault, 0, Rect.zero, Rect.zero);
#endif
    }

    void OnXRChange(WebXRState state, int viewsCount, Rect leftRect, Rect rightRect)
    {
        Vector3 pos = mainCamera.position;
        pos.y = state == WebXRState.NORMAL ? 1.25f : 0.0f;
        mainCamera.position = pos;

        foreach (var obj in VROnly)
        {
            if (obj is GameObject)
            {
                ((GameObject)obj).SetActive(state == WebXRState.VR);
            }
            else if (obj is Component)
            {
                ((MonoBehaviour)obj).enabled = state == WebXRState.VR;
            }
        }

        foreach (var obj in KeyboardOnly)
        {
            if (obj is GameObject)
            {
                ((GameObject)obj).SetActive(state == WebXRState.NORMAL);
            }
            else if (obj is Component)
            {
                ((MonoBehaviour)obj).enabled = state == WebXRState.NORMAL;
            }
        }
    }
}
