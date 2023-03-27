using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] float speed;
    camera Camera;

    void Start()
    {
        Camera = GetComponent<camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 vec = Time.deltaTime * Vector3.up * speed;
        Camera.transform.Translate(vec);
    }
}
