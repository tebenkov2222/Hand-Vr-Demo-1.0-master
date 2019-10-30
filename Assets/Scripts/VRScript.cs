using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRScript : MonoBehaviour
{
    public GameObject InstantiateScript;
    public bool LeftTriger = false, RightTriger = false;
    private int TrigersState = 0, EnteredFigure = 0, EnteredFigureLast = -1;
    void FixedUpdate()
    {
        Controllers();
        EnterFigere();
    }
    void Controllers()
    {
        if (LeftTriger && RightTriger && TrigersState == 0)
        {
            TrigersState = 1;
        }
        if (TrigersState == 1)
        {
            InstantiateScript.GetComponent<RotationInst>().InstantiateSelectObject();
            TrigersState = 2;
        }
        if (!LeftTriger || !RightTriger)
        {
            if (TrigersState == 2) InstantiateScript.GetComponent<RotationInst>().ExitFromInstantiate();
            TrigersState = 0;
        }
    }
    void EnterFigere()
    {
        if (EnteredFigure != EnteredFigureLast)
        {
            if (EnteredFigure == 0) InstantiateScript.GetComponent<RotationInst>().EnterFromInstantiateCube();
            else if (EnteredFigure == 1) InstantiateScript.GetComponent<RotationInst>().EnterFromInstantiateRectangle();
            else if (EnteredFigure == 2) InstantiateScript.GetComponent<RotationInst>().EnterFromInstantiateIKSphere();
            EnteredFigureLast = EnteredFigure;
        } 
    }
    public void FigureChange()
    {
        if (EnteredFigure != 2) EnteredFigure++;
        else EnteredFigure = 0;
    }
}
