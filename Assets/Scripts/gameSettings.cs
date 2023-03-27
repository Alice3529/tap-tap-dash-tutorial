using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class gameSettings : MonoBehaviour
{
    public GameObject squareBlock;
    public GameObject roundedBlock;
    public GameObject roundBlock;
    public GameObject platformObject;
    public GameObject pointerObject;
    public float pointerSize;
    public float rubySize;
    public static gameSettings instance;
    

    private void OnEnable()
    {
        instance = this;
    }


}
