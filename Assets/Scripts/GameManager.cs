using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private List<GameObject> _listPoints;
    private List<Liaisons> _listLiaisons;

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
    public List<GameObject> getListLiaisons()
    {
        return _listPoints;
    }

    private void Awake()
    {
        _instance = this;
    }



}
