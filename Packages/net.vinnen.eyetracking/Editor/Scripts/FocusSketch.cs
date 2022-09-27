using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;
using ViveSR.anipal.Eye;

namespace EyeTracking {
    public class FocusSketch : MonoBehaviour
    {
        private FocusInfo FocusInfo;
        private float MaxDistance = 200;

        private void Start()
        {

        }

        private void Update()
        {
            Ray GazeRay;
            bool eye_focus = false;
            int aoiLayerId = LayerMask.NameToLayer("EyeTrackingAoI");

            if (!SRanipal_Eye_Framework.Instance.EnableEye)
            {
                eye_focus = EyeSubstitution.Focus(GazeIndex.COMBINE, out GazeRay, out FocusInfo, 0, MaxDistance, (1 << aoiLayerId));
            }
            else
            {
                eye_focus = SRanipal_Eye.Focus(GazeIndex.COMBINE, out GazeRay, out FocusInfo, 0, MaxDistance, (1 << aoiLayerId));
            }
            
            
            
            
            if (eye_focus)
            {
                IFocusable edcb = FocusInfo.transform.GetComponent<IFocusable>();
                if (edcb != null) edcb.Focus(FocusInfo.point);

                return;
            }

        }
    }
}
