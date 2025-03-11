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
        var dadWell = well.GetComponent<Instance>();

        dadWell.isDragging = true;
    }
    public void CreateGameObjectFromDataBase(Object2D object2D)
    {
        var VgameObject = Instantiate(prefabs[Int32.Parse(object2D.prefabId)], new Vector3() { x = object2D.positionX, y = object2D.positionY, z = 0}, new Quaternion() { z = object2D.rotationZ});
        var instance = VgameObject.GetComponent<Instance>();
        instance.object2D = object2D;
    }
}
