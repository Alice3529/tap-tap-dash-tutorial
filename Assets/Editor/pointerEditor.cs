using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(pointer))]
public class pointerEditor : Editor
{
    pointer pointerClass;
    public override void OnInspectorGUI()
    {

        pointerClass = (pointer)target;
        DrawDefaultInspector();
        CreatePointer();
        ChangePointerDirection();

        void CreatePointer()
        {
            if (pointerClass.GetPointerObject() == null && pointerClass.direction != pointer.directions.Null)
            {
                GameObject pointerObject = PrefabUtility.InstantiatePrefab(gameSettings.instance.pointerObject, pointerClass.transform) as GameObject;
                pointerClass.SetPointerObject(pointerObject);
                pointerClass.GetPointerObject().transform.localPosition = Vector3.zero; //create a pointer in the center of the block
                float pointerSize = gameSettings.instance.pointerSize;
                pointerClass.GetPointerObject().transform.localScale = Vector3.one * pointerSize;
                Undo.RegisterCreatedObjectUndo(pointerObject, "Created pointer");

            }

            if (pointerClass.direction == pointer.directions.Null && pointerClass.GetPointerObject() != null)
            {
                Undo.DestroyObjectImmediate(pointerClass.GetPointerObject());

            }

        }

        void ChangePointerDirection()
        {
            if (pointerClass.GetPointerObject() == null) { return; }

            Transform pointerObject = pointerClass.GetPointerObject().transform;

            if (pointerClass.direction == pointer.directions.Up)
            {
                pointerObject.rotation = Quaternion.identity;
            }
            else if (pointerClass.direction == pointer.directions.Right)
            {
                pointerObject.rotation = Quaternion.Euler(0, 0, -90);
            }
            else if (pointerClass.direction == pointer.directions.Left)
            {
                pointerObject.rotation = Quaternion.Euler(0, 0, 90);
            }
        }




    }
}
