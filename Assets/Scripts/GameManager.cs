using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private List<PointBridge> _listPoints;
    private List<Liaison> _listLiaisons;
    [SerializeField] public Material woodMaterial;

    [SerializeField] public LineDrawer lineDrawer;


    private void Start()
    {
        _listPoints = new List<PointBridge> { };
        _listLiaisons = new List<Liaison> { };
    }
    public static GameManager Instance
    {
        get { 
            if(_instance == null)
            {
                Debug.LogError("error!");
            }
            return _instance;
        }

    }
    public List<Liaison> getListLiaisons()
    {
        return _listLiaisons;
    }
    public List<PointBridge> getListPointsBridge()
    {
        return _listPoints;
    }

    private void Awake()
    {
        _instance = this;
    }

    internal Material GetMaterial()
    {
        return woodMaterial;
    }
}
