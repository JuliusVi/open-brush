using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TiltBrush;

public class LoggerCAD : MonoBehaviour
{

    string filename = "";

    Transform mainCameraTransform;
    Transform wandTransform;
    Transform brushTransform;

    public Batch b;
    public GeometryPool p;

    public List<Vector3> verts;
    private int previousCount = 0;

    public GameObject spherePref;
    // Start is called before the first frame update
    void Start()
    {
        verts = new List<Vector3>();
        filename = "_StudyLog.txt";
        mainCameraTransform = GameObject.Find("Camera (eye)").transform;
        wandTransform = GameObject.Find("Controller (wand)").transform;
        brushTransform = GameObject.Find("Controller (brush)").transform;
    }

    private void OnEnable()
    {
        Application.logMessageReceived += Log;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= Log;
    }

    // Update is called once per frame
    void Update()
    {
        if(b != null)
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

        TextWriter tw = new StreamWriter(filename, true);

        tw.WriteLine("[" + System.DateTime.Now + "]" + "Head position: " + mainCameraTransform.position + "Wand position: " + wandTransform.position + "Brush position: " + brushTransform.position);

        tw.Close();
    }

    public void Log(string logString, string stackTrace, LogType type)
    {
        TextWriter tw = new StreamWriter(filename, true);

        tw.WriteLine("[" + System.DateTime.Now + "]" + logString);

        tw.Close();
    }

}
