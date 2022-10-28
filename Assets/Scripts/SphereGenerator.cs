using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour
{

    private Vector3 _lineEnd;
    private PointBridge _selectedSphere;
    private PointBridge _destinationSphere;
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
            foreach (PointBridge point in GameManager.Instance.getListPointsBridge())
            {
                if (Vector3.Distance(mouseWorldPosition, point.sphere.transform.position) < 0.5)
                {
                    point.BreakThePoint();
                    return;
                }
            }

            GenerateNewSphere(mouseWorldPosition);



        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = GetMouseWorldPosition();
            foreach(PointBridge point in GameManager.Instance.getListPointsBridge())
               if(Vector3.Distance(mouseWorldPosition, point.sphere.transform.position )< 0.5)
                {
                    _selectedSphere = point;
                    hasAFirstSphere = true;


                }
        }
        if (Input.GetMouseButton(0) && hasAFirstSphere)
        {

            _lineEnd = GetMouseWorldPosition();

            GameManager.Instance.lineDrawer.DrawLine(_lineEnd, _selectedSphere.sphere.transform.position );
           
        }
        if (Input.GetMouseButtonUp(0) && hasAFirstSphere)
        {
            Vector3 mouseWorldPosition = GetMouseWorldPosition();
            foreach (PointBridge point in GameManager.Instance.getListPointsBridge())
                if (Vector3.Distance(mouseWorldPosition, point.sphere.transform.position) < 0.5)
                {
                    _destinationSphere = point;
                    _foundDestination = true;

                }
            if (!_foundDestination)
            {
                _destinationSphere = GenerateNewSphere(mouseWorldPosition);

            }

            GameManager.Instance.lineDrawer.CreateLine(_selectedSphere, _destinationSphere);
            _selectedSphere = _destinationSphere;
            _foundDestination = false;
            GameManager.Instance.lineDrawer.EraseLine();

        }





    }

    public PointBridge GenerateNewSphere(Vector3 position)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);


        sphere.name = "Sphere" + GameManager.Instance.getListPointsBridge().Count;
        sphere.transform.position = position;
        sphere.transform.localScale = new(0.5f, 0.5f, 0.5f);
        PointBridge generatedPoint = new PointBridge(false, sphere);
        GameManager.Instance.getListPointsBridge().Add(generatedPoint);
        return generatedPoint;
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
