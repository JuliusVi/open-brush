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

            if (!SRanipal_Eye_Framework.Instance.EnableEye)
            {
                enabled = false;
                return;
            }
        }

        private void Update()
        {

            Ray GazeRay;
            bool eye_focus = false;

            if (SRanipal_Eye_Framework.Status != SRanipal_Eye_Framework.FrameworkStatus.WORKING &&
                SRanipal_Eye_Framework.Status != SRanipal_Eye_Framework.FrameworkStatus.NOT_SUPPORT)
            {
                eye_focus = EyeSubstitution.Focus(GazeIndex.COMBINE, out GazeRay, out FocusInfo, 0, MaxDistance, (1 << 24));
            }
            else
            {
                eye_focus = SRanipal_Eye.Focus(GazeIndex.COMBINE, out GazeRay, out FocusInfo, 0, MaxDistance, (1 << 24));
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
