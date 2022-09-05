using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TiltBrush
{

    public class EyeDebugCubeBehaviour : MonoBehaviour, IFocusable
    {
        private Renderer Renderer;

        public float lastHit;

        public Material red, green;
        public float oX, oY, oZ, rotX, rotY, rotZ;
        private Transform tracking;
        public string trackingName;

       


        private void Awake()
        {
            Renderer = GetComponent<Renderer>();
            Collider c = GetComponent<Collider>();
            
            Focus(Vector3.zero);
        }

        public void Focus(Vector3 focusPoint)
        {
            lastHit = Time.realtimeSinceStartup;
        }

        void Start()
        {
            this.transform.localPosition = new Vector3(oX, oY, oZ);
        }

        public void Update()
        {
            if (GameObject.Find(trackingName).transform != null)
            {
                tracking = GameObject.Find(trackingName).transform;

                this.transform.parent.position = tracking.transform.position;
                this.transform.parent.rotation = tracking.transform.rotation * Quaternion.Euler(rotX, rotY, rotZ);

            }

            if (Time.realtimeSinceStartup - lastHit < 1)
            {
                Renderer.material = green;
                //Renderer.material.SetColor("_Color", Color.green);
            }
            else
            {
                Renderer.material = red;
                //Renderer.material.SetColor("_Color", Color.red);
            }
        }
        
    }
}

