using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private List<GameObject> _listPoints;
    [SerializeField] public LineDrawer lineDrawer;


    private void Start()
    {
        _listPoints = new List<GameObject> { };
        
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
    public List<GameObject> getListPoints()
    {
        return _listPoints;
    }


    private void Awake()
    {
        _instance = this;
    }
}
