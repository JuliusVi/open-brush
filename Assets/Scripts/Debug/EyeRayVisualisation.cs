using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TiltBrush;

public class EyeRayVisualisation : MonoBehaviour, IFocusable
{
    private Renderer Renderer;

    public float oX, oY, oZ, rotX, rotY, rotZ;
    private Transform tracking;
    public string trackingName;

    public RectTransform rtDebug;
    public RectTransform rtOverlay;

    public float tuneTop, tuneBottom, tuneLeftRight, tuneWidth;


    private void Awake()
    {
        Renderer = GetComponent<Renderer>();
        Collider c = GetComponent<Collider>();

        tracking = GameObject.Find(trackingName).transform;
        this.transform.localPosition = new Vector3(oX, oY, oZ);

        Focus(Vector3.zero);
    }

    public void Focus(Vector3 focusPoint)
    {
        rtDebug.position = new Vector3(focusPoint.x, focusPoint.y, focusPoint.z);

        //rtOverlay.position = rtDebug.localPosition*10;
        tuneWidth = rtOverlay.GetComponentInParent<Canvas>().pixelRect.height/ rtOverlay.GetComponentInParent<Canvas>().pixelRect.width;
        tuneWidth += 0.02f;
        rtOverlay.position = new Vector2(tuneLeftRight + (rtOverlay.GetComponentInParent<Canvas>().pixelRect.width/2 + (rtDebug.localPosition.x/5)*rtOverlay.GetComponentInParent<Canvas>().pixelRect.width/2)*tuneWidth, rtOverlay.GetComponentInParent<Canvas>().pixelRect.height/2 + (rtDebug.localPosition.y / 5)* rtOverlay.GetComponentInParent<Canvas>().pixelRect.height/2);
        Debug.Log("FP: " + rtDebug.localPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (tracking != null)
        {
            this.transform.parent.position = tracking.transform.position;
            this.transform.parent.rotation = tracking.transform.rotation * Quaternion.Euler(rotX, rotY, rotZ);

        }
    }
}
