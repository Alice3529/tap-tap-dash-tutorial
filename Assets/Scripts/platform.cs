using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class platform : MonoBehaviour
{
    public float scaleValue = 0.25f;
    public int cells;
    public platformType type;
    public static platform platformEditor;

    private void OnEnable()
    {
        platformEditor = this;
    }

    public enum platformType
    {
        horizontal, vertical
    }
    
}
