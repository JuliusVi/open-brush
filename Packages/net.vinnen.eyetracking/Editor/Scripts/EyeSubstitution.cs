using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ViveSR
{
    namespace anipal
    {
        namespace Eye
        {

            public class EyeSubstitution
            {

                public static Camera camera;

                public static bool Focus(GazeIndex index, out Ray ray, out FocusInfo focusInfo, float radius, float maxDistance, int focusableLayer)
                {
                    bool valid = GetGazeRay(index, out ray);
                    if (valid)
                    {
                        Ray rayGlobal = ray;
                        RaycastHit hit;
                        if (radius == 0) valid = Physics.Raycast(rayGlobal, out hit, maxDistance, focusableLayer);
                        else valid = Physics.SphereCast(rayGlobal, radius, out hit, maxDistance, focusableLayer);
                        focusInfo = new FocusInfo
                        {
                            point = hit.point,
                            normal = hit.normal,
                            distance = hit.distance,
                            collider = hit.collider,
                            rigidbody = hit.rigidbody,
                            transform = hit.transform
                        };
                    }
                    else
                    {
                        focusInfo = new FocusInfo();
                    }
                    return valid;
                }

                public static bool GetGazeRay(GazeIndex gazeIndex, out Ray ray)
                {
                    bool valid = false;
                    Vector3 origin = camera.transform.position;
                    valid = true;

                    Vector3 direction = camera.transform.forward;
                    
                    //direction.x *= -1;
                    //direction.y *= -1;
                    //direction.z *= -1;
                    ray = new Ray(origin, direction);

                    return valid;
                }

            }
        }
    }
}
