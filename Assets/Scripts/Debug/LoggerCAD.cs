using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TiltBrush;

public class LoggerCAD : MonoBehaviour
{
    private readonly object loggerLock = new object();

    static string filename = "_StudyLog.txt";

    public Transform mainCameraTransform;
    public Transform wandTransform;
    public Transform brushTransform;

    public Batch b;
    public GeometryPool p;

    public List<Vector3> verts;
    private int previousCount = 0;

    public GameObject spherePref;

    TextWriter tw;
    // Start is called before the first frame update
    void Start()
    {
        verts = new List<Vector3>();
        
        tw = new StreamWriter(filename, true);
    }

    private void OnEnable()
    {
        Application.logMessageReceived += Log;
        mainCameraTransform = GameObject.Find("Camera (eye)").transform;
        //tw = new StreamWriter(filename, true);
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= Log;
    }

    // Update is called once per frame
    void Update()
    {
        if(wandTransform == null)
        {
            wandTransform = GameObject.Find("Controller (wand)").transform;
        }
        if (brushTransform == null)
        {
            brushTransform = GameObject.Find("Controller (brush)").transform;
        }

        if (b != null)
        {
            p = b.Geometry;
            if (p.m_Vertices.Count != previousCount)
            {
                foreach (Vector3 ver in p.m_Vertices)
                {
                    if (!verts.Contains(ver))
                    {
                        GameObject tmp = Instantiate(spherePref);
                        tmp.transform.position = ver;
                        verts.Add(ver);
                    }

                }
                previousCount = p.m_Vertices.Count;
            }
        }

        

        Debug.Log("[" + System.DateTime.Now + "]" + ":" + mainCameraTransform.position + ":" + wandTransform.position + ":" + brushTransform.position
            + ":" + mainCameraTransform.rotation + ":" + wandTransform.rotation + ":" + brushTransform.rotation);
        //Debug.Log("[" + System.DateTime.Now + "]" + ":");
        //Debug.Log(mainCameraTransform.position + ":");
        //Debug.Log(wandTransform.position + ":");
        //Debug.Log(brushTransform.position);
    }

    public void Log(string logString, string stackTrace, LogType type)
    {
            tw.WriteLineAsync("[" + System.DateTime.Now + "]" + logString);
    }

    void OnDestroy()
    {
        tw.Close();
    }

}
