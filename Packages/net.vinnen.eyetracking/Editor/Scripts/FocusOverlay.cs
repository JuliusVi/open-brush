using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;
using ViveSR.anipal.Eye;

namespace EyeTracking
{
    public class FocusOverlay : MonoBehaviour
    {
        private FocusInfo FocusInfo;
        private float MaxDistance = 20;

        private void Start()
        {

        }

        private void Update()
        {

            Ray GazeRay;
            bool eye_focus = false;
            int overlayLayerId = LayerMask.NameToLayer("EyeTrackingOverlay");

            if (!SRanipal_Eye_Framework.Instance.EnableEye)
            {
                eye_focus = EyeSubstitution.Focus(GazeIndex.COMBINE, out GazeRay, out FocusInfo, 0, MaxDistance, (1 << overlayLayerId));
            }
            else
            {
                eye_focus = SRanipal_Eye.Focus(GazeIndex.COMBINE, out GazeRay, out FocusInfo, 0, MaxDistance, (1 << overlayLayerId));
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
