using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViveSR.anipal.Eye;

namespace EyeTracking
{
    public class EyeTrackingWrapper : MonoBehaviour
    {

        private GameObject eyeFramework;

        [Tooltip("The Camera that is used if Tracking Type is set to Head")]
        private Camera trackingCamera = null;

        public enum TrackingState
        {
            Eye,
            Head
        }

        [Tooltip("If set to Head, the raycasting just follows the head \nIf set to Eye, the raycasting follows the eye")]
        public TrackingState trackingType;

        void Awake()
        {
            if (trackingCamera == null)
            {
                trackingCamera = Camera.main;
            }
            eyeFramework = transform.GetChild(0).gameObject;
            if (trackingType == TrackingState.Eye)
            {
                eyeFramework.GetComponent<SRanipal_Eye_Framework>().EnableEye = true;
            }
            else
            {
                EyeSubstitution.camera = this.trackingCamera;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}