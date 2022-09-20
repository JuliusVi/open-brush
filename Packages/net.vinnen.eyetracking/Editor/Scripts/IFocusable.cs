using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EyeTracking { 
    public interface IFocusable
    {
        void Focus(Vector3 focusPoint);
    }
}
