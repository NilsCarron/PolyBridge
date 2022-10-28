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



    public void CreateLine(PointBridge start, PointBridge end)
    {
        if (start == end)
        {
            return;
        }
        foreach (Liaison line in GameManager.Instance.getListLiaisons()) {
            if (line.CouplesAreEquals(start, end)) { 
                Debug.Log("equalds");
                return;
            }
        }

        GameObject myLine = new GameObject();
        myLine.transform.position = start.sphere.transform.position;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.SetPosition(0, start.sphere.transform.position);
        lr.SetPosition(1, end.sphere.transform.position);
        lr.material = GameManager.Instance.GetMaterial();
        Liaison lia = new Liaison(start, end, lr);
        GameManager.Instance.getListLiaisons().Add(lia);
        
    }

    public void DrawLine(Vector3 start, Vector3 end)
    {
        lr.material = GameManager.Instance.GetMaterial();
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }

    public void EraseLine()
    {
        lr.SetPosition(0, Vector3.zero);
        lr.SetPosition(1, Vector3.zero);
    }


}
