using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour
{

    private Vector3 _lineEnd;
    private GameObject _selectedSphere;
    private GameObject _destinationSphere;
    bool hasAFirstSphere;
    bool _foundDestination;
    // Start is called before the first frame update
    void Start()
    {
        _lineEnd = new Vector3();
         hasAFirstSphere = false;
         _foundDestination = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (  Input.GetMouseButtonDown(1))
        {
            Vector3 mouseWorldPosition = GetMouseWorldPosition();
            GenerateNewSphere(mouseWorldPosition);



        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = GetMouseWorldPosition();
            foreach(GameObject sphere in GameManager.Instance.getListPoints())
               if(Vector3.Distance(mouseWorldPosition, sphere.transform.position )< 0.5)
                {
                    _selectedSphere = sphere;
                    hasAFirstSphere = true;


                }
        }
        if (Input.GetMouseButton(0) && hasAFirstSphere)
        {

            _lineEnd = GetMouseWorldPosition();

            GameManager.Instance.lineDrawer.DrawLine(_lineEnd, _selectedSphere.transform.position );
           
        }
        if (Input.GetMouseButtonUp(0) && hasAFirstSphere)
        {
            Vector3 mouseWorldPosition = GetMouseWorldPosition();
            foreach (GameObject sphere in GameManager.Instance.getListPoints())
                if (Vector3.Distance(mouseWorldPosition, sphere.transform.position) < 0.5)
                {
                    _destinationSphere = sphere;
                    _foundDestination = true;

                }
            if (!_foundDestination)
            {
                _destinationSphere = GenerateNewSphere(mouseWorldPosition);

            }

            GameManager.Instance.lineDrawer.CreateLine(_selectedSphere.transform.position, _destinationSphere.transform.position);
            _selectedSphere = _destinationSphere;
            _foundDestination = false;

        }





    }

    public GameObject GenerateNewSphere(Vector3 position)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);


        sphere.name = "Sphere" + GameManager.Instance.getListPoints().Count;
        sphere.transform.position = position;
        sphere.transform.localScale = new(0.5f, 0.5f, 0.5f);
        GameManager.Instance.getListPoints().Add(sphere);
        return sphere;
    }




    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;

        return vec;
    }

    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        screenPosition.z = Mathf.Abs(worldCamera.transform.position.z);
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);

        return worldPosition;
    }

}
