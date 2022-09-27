using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using EyeTracking;


namespace EyeTracking
{
    public class EyeRayVisualisation : MonoBehaviour, IFocusable
    {
        private Renderer Renderer;

        public float oX, oY, oZ, rotX, rotY, rotZ;
        private Transform tracking;

        public RectTransform rtDebug;
        public RectTransform rtProjectionTarget;
        public RectTransform attachedCanvasTransform;

        private void Awake()
        {
            Renderer = GetComponent<Renderer>();
            Collider c = GetComponent<Collider>();

            tracking = Camera.main.transform;
            this.transform.localPosition = new Vector3(oX, oY, oZ);

            Focus(Vector3.zero);
        }

        public void Focus(Vector3 focusPoint)
        {
            rtDebug.position = new Vector3(focusPoint.x, focusPoint.y, focusPoint.z);
            Ray r = new Ray(focusPoint, focusPoint - tracking.position);
            Plane p = new Plane(attachedCanvasTransform.forward, attachedCanvasTransform.position);
            float tmpRes;
            p.Raycast(r, out tmpRes);
            if (tmpRes != 0)
            {
                rtProjectionTarget.position = r.GetPoint(tmpRes);
            }

            //Debug.Log("FP: " + rtDebug.localPosition);
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
}