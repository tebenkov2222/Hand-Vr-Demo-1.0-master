using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotationInst : MonoBehaviour
{
    Vector3 firstPoint, secondPoint, center, InstObjectScale;
    public GameObject Cube, Rectangle, IKSphere, LeftSphere, RightSphere, VRScript  ;
    private bool ActiveInstantiateBool = false;
    private GameObject SelectObject, InstObject;
    cat c = new cat("Жирок", "белый", 1);
    private void Start()
    {
        c.Voice();
        SelectObject = Cube;
    }
    private void FixedUpdate()
    {
        KeyboardScript();
    }
    private void KeyboardScript()
    {
        if (Input.GetKeyUp(KeyCode.E)) ExitFromInstantiate();
        if (Input.GetKeyDown(KeyCode.E) && !ActiveInstantiateBool) InstantiateSelectObject();
        if (Input.GetKeyDown(KeyCode.C)) EnterFromInstantiateCube();
        if (Input.GetKeyDown(KeyCode.R)) EnterFromInstantiateRectangle();
        if (Input.GetKeyDown(KeyCode.I)) EnterFromInstantiateIKSphere();
        if (Input.GetKeyDown(KeyCode.F)) VRScript.GetComponent<VRScript>().FigureChange();
        ActiveInstantiate();
    }
    private void ActiveInstantiate()
    {
        if (ActiveInstantiateBool)
        {
            firstPoint = LeftSphere.transform.position;
            secondPoint = RightSphere.transform.position;
            PositionControl();
            InstObject.transform.position = center;
            ScaleControl();
            InstObject.transform.localScale = InstObjectScale;
            RotationControl();
        }
    }
    void NormalPositionAndScale()
    {
        PositionControl();
        ScaleControl();
    }
    void PositionControl()
    {
        center = new Vector3((firstPoint.x + secondPoint.x) / 2, (firstPoint.y + secondPoint.y) / 2, (firstPoint.z + secondPoint.z) / 2);
    }

    void ScaleControl()
    {
        float spaceBetween = Mathf.Sqrt
        (
            Mathf.Pow(firstPoint.x - secondPoint.x, 2) +
            Mathf.Pow(firstPoint.y - secondPoint.y, 2) +
            Mathf.Pow(firstPoint.z - secondPoint.z, 2)
        );
        if (InstObject.tag != "Rectangle")
            InstObjectScale = new Vector3(spaceBetween, spaceBetween, spaceBetween);
        else InstObjectScale = new Vector3(0.4f, 0.2f, spaceBetween);
    }

    void RotationControl()
    {
        InstObject.transform.LookAt(RightSphere.transform);
    }
    public void ExitFromInstantiate()
    {
        Debug.Log("EXIT");
        ActiveInstantiateBool = false;
        InstObject.GetComponent<Rigidbody>().useGravity = true;
        InstObject.GetComponent<ChangeColorGameObject>().InstantiatedObject();
    }
    public void EnterFromInstantiateCube()
    {
        SelectObject = Cube;

    }
    public void EnterFromInstantiateRectangle()
    {
        SelectObject = Rectangle;
    }
    public void EnterFromInstantiateIKSphere()
    {
        SelectObject = IKSphere;
    }
    public void InstantiateSelectObject()
    {
        ActiveInstantiateBool = true;
        InstObject = Instantiate(SelectObject, center, Quaternion.identity);
        ActiveInstantiate();
    }
}

