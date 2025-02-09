using System;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{

    public List<GameObject> prefabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void CreateGameObjectFromClick(int prefabIndex)
    {
     
        var well = Instantiate(prefabs[prefabIndex], Vector3.zero, Quaternion.identity);
        var dadWell = well.GetComponent<DragAndDrop>();


        dadWell.isDragging = true;
        
    }
}
