using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rubiesGenerator : MonoBehaviour
{
    [SerializeField] GameObject ruby;
    gameSettings gameSettings;

    private void Start()
    {
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("platform");
        gameSettings = FindObjectOfType<gameSettings>();
        foreach (GameObject platform in platforms)
        {
            CreateRubies(platform);
        }
    }

    private void CreateRubies(GameObject platform)
    {
        foreach (Transform block in platform.transform)
        {
            if (block.childCount == 0) //if the block does not contain a pointer, create a ruby
            {
                GameObject newRuby = Instantiate(ruby, block);
                newRuby.transform.localPosition = Vector3.zero; //place the ruby ​​in the center of the platform
                newRuby.transform.localScale = Vector2.one * gameSettings.rubySize;
                newRuby.transform.localRotation = block.transform.rotation;
            }
        }
    }
}
