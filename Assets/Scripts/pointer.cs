using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pointer : MonoBehaviour
{
   public enum directions { Right, Left, Up, Null}
   public directions direction = directions.Null;
   [SerializeField] GameObject pointerObject;

   public void SetPointerObject(GameObject pointerObject)
   {
        this.pointerObject = pointerObject;
   }

    public GameObject GetPointerObject()
    {
        return this.pointerObject;
    }

}
