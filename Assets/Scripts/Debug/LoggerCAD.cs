using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoggerCAD : MonoBehaviour
{

    string filename = "";

    Transform mainCameraTransform;
    Transform wandTransform;
    Transform brushTransform;
    // Start is called before the first frame update
    void Start()
    {
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
