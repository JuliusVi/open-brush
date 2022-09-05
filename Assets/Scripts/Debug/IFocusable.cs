using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TiltBrush { 
    public interface IFocusable
    {
        void Focus(Vector3 focusPoint);
    }
}
