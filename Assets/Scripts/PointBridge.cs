using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class PointBridge
{
    public bool isFixed;
    public GameObject sphere;

    public PointBridge(bool paramIsFixed, GameObject paramSphere)
    {
        isFixed = paramIsFixed;
        sphere = paramSphere;
        
    }


    public void BreakThePoint()
    {
        for(int indexLisaions = 0; indexLisaions< GameManager.Instance.getListLiaisons().Count; indexLisaions ++)
        {
            if (GameManager.Instance.getListLiaisons()[indexLisaions].IsLinkedTo(this))
            {
                GameManager.Instance.getListLiaisons()[indexLisaions].BreakTheLiaison();
                indexLisaions--;

            }
        }
        GameManager.Instance.getListPointsBridge().Remove(this);
        GameObject.Destroy(this.sphere);
    }

}
