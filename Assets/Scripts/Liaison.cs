
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liaison
{
    private PointBridge _pointStart;
    private PointBridge _pointEnd;
    private LineRenderer _lr;
    public Liaison(PointBridge paramointStart, PointBridge paramointEnd, LineRenderer lr)
    {
        _pointStart = paramointStart;
        _pointEnd = paramointEnd;
        _lr = lr;

    }
    public bool IsLinkedTo(PointBridge point)
    {
        return (_pointStart == point || _pointEnd == point);

    }



    public bool CouplesAreEquals(PointBridge firstPoint, PointBridge secondPoint)
    {
        if (_pointStart == firstPoint && _pointEnd == secondPoint)
        {
            return true;
        }
        else if (_pointStart == secondPoint && _pointEnd == firstPoint)
        {
            return true;
        }
        
        else
        {
            return false;
        }
    }

    internal void BreakTheLiaison()
    {
        GameManager.Instance.getListLiaisons().Remove(this);
        GameObject.Destroy(_lr);

    }
}