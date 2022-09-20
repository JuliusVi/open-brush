using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using ViveSR.anipal.Eye;

namespace EyeTracking
{
    public class EyeTrackingAoI : MonoBehaviour, IFocusable
    {
        private Renderer Renderer;

        private float lastHit;
        private bool isFocused = false;

        public Material red, green;
        public string debugName;




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

        }

        public void Update()
        {

            if (Time.realtimeSinceStartup - lastHit < 0.1f)
            {
                Renderer.material = green;
                if (!isFocused)
                {
                    Debug.Log(debugName + " was focused at: " + System.DateTime.Now + " : " + System.DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString());
                    isFocused = true;
                }
            }
            else
            {
                Renderer.material = red;
                if (isFocused)
                {
                    Debug.Log(debugName + " was unfocused at: " + System.DateTime.Now + " : " + System.DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString());
                    isFocused = false;
                }
            }
        }

    }
}
