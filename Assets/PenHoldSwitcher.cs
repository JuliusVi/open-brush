using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenHoldSwitcher : MonoBehaviour
{

    public Collider cube;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Controller (brush)").transform.Find("PointerAttachAnchor").transform.rotation = Quaternion.Euler(150, 0, 0);
        Debug.Log("Rotpoint");
    }
}
