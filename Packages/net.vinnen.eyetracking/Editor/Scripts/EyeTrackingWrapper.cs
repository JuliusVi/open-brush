using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViveSR.anipal.Eye;

namespace EyeTracking
{
    public class EyeTrackingWrapper : MonoBehaviour
    {

        public GameObject eyeFramework;
        public Camera camera;

        public enum TrackingState
        {
            Eye,
            Head
        }

        public TrackingState trackingType;

        void Awake()
        {
            if (trackingType == TrackingState.Eye)
            {
                eyeFramework.SetActive(true);
            }
            else
            {
                EyeSubstitution.camera = this.camera;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            if(camera == null)
            {
                camera = Camera.main;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}