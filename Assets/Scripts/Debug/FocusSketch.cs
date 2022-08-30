using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using ViveSR.anipal.Eye;

namespace TiltBrush {
    public class FocusSketch : MonoBehaviour
    {
        private FocusInfo FocusInfo;
        private float MaxDistance = 20;
        private void Start()
        {

            if (!SRanipal_Eye_Framework.Instance.EnableEye)
            {
                enabled = false;
                return;
            }
        }

        private void Update()
        {
            
            if (SRanipal_Eye_Framework.Status != SRanipal_Eye_Framework.FrameworkStatus.WORKING &&
                SRanipal_Eye_Framework.Status != SRanipal_Eye_Framework.FrameworkStatus.NOT_SUPPORT) return;
            
            Ray GazeRay;
            bool eye_focus = SRanipal_Eye.Focus(GazeIndex.COMBINE, out GazeRay, out FocusInfo, 0, MaxDistance);
            
            if (eye_focus)
            {
                EyeDebugCubeBehaviour edcb = FocusInfo.transform.GetComponent<EyeDebugCubeBehaviour>();
                if (edcb != null) edcb.Focus(FocusInfo.point);
                return;
            }

        }
    }
}
