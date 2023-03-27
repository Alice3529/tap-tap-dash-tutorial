using PlasticPipe.PlasticProtocol.Lz4;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(platform))]
public class platformEditor : Editor
{
    platform platformClass;
    gameSettings gameSettings;

    private void OnEnable()
    {
        gameSettings = gameSettings.instance;
    }


    public override void OnInspectorGUI()
    {
        platformClass = (platform)target;
        DrawDefaultInspector(); //automatically draw the inspector
        if (GUILayout.Button("Create"))
        {
           GameObject platformObject=CreatePlatform(); 
           Selection.activeGameObject = platformObject;
        }
    }

    private GameObject CreatePlatform()
    {
        GameObject platformObject = PrefabUtility.InstantiatePrefab(gameSettings.platformObject) as GameObject; 
        platformObject.name = "platform" + Random.Range(0, 1000);//add a random number to each platform name to make it easier to distinguish between them
        platformObject.transform.position=platformClass.transform.position;//set the position of the platform to be the same as the position of the platform editor
        float blockSize = platformClass.scaleValue;
        AddPlatformBlocks(platformClass.cells, blockSize, platformObject.transform);
        RotatePlatform(platformObject);
        Undo.RegisterCreatedObjectUndo(platformObject, "Created platform");
        return platformObject;

    }

    private void AddPlatformBlocks(int blockAmount, float blockScale, Transform parent)
    {
        if (blockAmount == 1) //if the platform consists of one block, then we create this block in the form of a circle
        {
            RoundBlock(parent);
            return;
        }
        //create multiple blocks
        float bottomPosY = parent.transform.position.y - (blockScale * blockAmount) / 2;
        MultipleBlocks(parent, bottomPosY, blockAmount, blockScale);

    }

    void MultipleBlocks(Transform parent, float bottomPosY, int blockAmount, float blockScale) 
    {
        Transform startBlock = Block(parent, bottomPosY, gameSettings.roundedBlock); //create rounded square block in the start
        startBlock.gameObject.AddComponent<pointer>(); //add the pointer script to the start block
        startBlock.transform.rotation = Quaternion.Euler(0, 0, 180); //this is the first block so we have to rotate it 180 degrees around the z-axis
        for (int i=1; i<blockAmount-1; i++)
        {
            Block(parent, bottomPosY + i * blockScale, gameSettings.squareBlock); // create square blocks in the middle
        }
        Debug.Log((blockAmount - 1) * blockScale);
        GameObject endBlock=Block(parent, bottomPosY + (blockAmount - 1) * blockScale, gameSettings.roundedBlock).gameObject; //create rounded square block in the end
        endBlock.gameObject.AddComponent<pointer>(); //add the pointer script to the end block
    }

    Transform Block(Transform parent, float yPosition, GameObject blockShape)//this function creates a block of the given shape
    {
        float blockScale = platformClass.scaleValue;
        GameObject block=PrefabUtility.InstantiatePrefab(blockShape, parent) as GameObject;
        block.transform.localScale = blockScale * Vector3.one; //set block size
        block.transform.position=new Vector3(parent.position.x, yPosition+blockScale/2, parent.position.z);
        return block.transform;
    }

    private void RoundBlock(Transform parent)
    {
        GameObject roundBlock = PrefabUtility.InstantiatePrefab(gameSettings.roundBlock, parent) as GameObject; //each block should be a child of a platformObject game object
        float blockScale=platformClass.scaleValue;
        roundBlock.transform.localScale=blockScale*Vector3.one;
        roundBlock.AddComponent<pointer>();
    }

    void RotatePlatform(GameObject platformObject)
    {
        if (platformClass.type == platform.platformType.vertical)
        {
            platformObject.transform.rotation = Quaternion.identity;
        }
        else if (platformClass.type==platform.platformType.horizontal) //if the platform type is horizontal, then we must rotate it 180 degrees around the z-axis
        {
            platformObject.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

    [MenuItem("Hotkeys/platformEditor _g")]

    private static void SelectPlatformEditor()
    {
        Selection.activeObject = platform.platformEditor;
    }
   
}
