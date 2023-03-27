using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class grid : MonoBehaviour
{
    [SerializeField] float snapValue = 0.5f;

    private void Update()
    {
        transform.position=GetRoundedPosition(transform.position);
    }

    public Vector3 GetRoundedPosition(Vector3 position)
    {
        return new Vector3(
            snapValue * Mathf.RoundToInt(position.x / snapValue),
            snapValue * Mathf.RoundToInt(position.y / snapValue),
            position.z
            );
           
    }
}
