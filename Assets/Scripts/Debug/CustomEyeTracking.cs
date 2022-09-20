using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TiltBrush;
using EyeTracking;

public class CustomEyeTracking : MonoBehaviour
{
    public GameObject aoiPrefab;

    public Transform wandTransform;
    public Transform brushTransform;

    private Transform wandAoI, brushAoI;

    private bool wandTransformSet = false;
    private bool brushTransformSet = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (wandTransform == null)
        {
            wandTransform = GameObject.Find("Controller (wand)").transform;
            wandTransformSet = true;
        }
        else if(wandTransform.gameObject.GetComponentInChildren<EyeTrackingAoI>() == null)
        {
            wandAoI = Instantiate(aoiPrefab, wandTransform).transform;
            wandAoI.localPosition = new Vector3(0, 0.1f, 0.6f);
            wandAoI.localScale = new Vector3(3, 3, 3);
            wandAoI.localRotation = Quaternion.Euler(77, 0, 0);
        }
        if (brushTransform == null)
        {
            brushTransform = GameObject.Find("Controller (brush)").transform;
            brushTransformSet = true;
        }
        else if (brushTransform.gameObject.GetComponentInChildren<EyeTrackingAoI>() == null)
        {
            brushAoI = Instantiate(aoiPrefab, brushTransform).transform;
            brushAoI.localPosition = new Vector3(0, -0.27f, -1.01f);
            brushAoI.localRotation = Quaternion.Euler(75, 0, 0);
        }
    }
}
