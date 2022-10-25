using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    private LineRenderer lr;
    public List<GameObject> listPoints;

    // Start is called before the first frame update
    void Start()
    {

        /*  -11,9
          -11, -7
          11
          */

        lr = GetComponent<LineRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateLine(Vector3 start, Vector3 end)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.startColor = Color.red;
        lr.endColor = Color.blue;
        lr.startWidth = 0.01f;
        lr.endWidth = 0.01f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }

    public void DrawLine(Vector3 start, Vector3 end)
    {
       
        lr.startColor = Color.red;
        lr.endColor = Color.blue;
        lr.startWidth = 0.01f;
        lr.endWidth = 0.01f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }

    internal static void DrawLine()
    {
        throw new NotImplementedException();
    }
}
