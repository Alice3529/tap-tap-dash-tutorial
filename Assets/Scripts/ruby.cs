using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ruby : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    Vector3 size;
    void Start()
    {
        gameSettings gameSettings;
        gameSettings=FindObjectOfType<gameSettings>();
        size = gameSettings.rubySize*Vector3.one;
        Collider2D[] colliders=Physics2D.OverlapBoxAll(transform.position, size, 0, layer);
        if (colliders.Length > 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
         Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }


}
