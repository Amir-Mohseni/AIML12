using System.Collections.Generic;
using UnityEngine;

public class MovingObjects
{
    private List<GameObject> gameObjects = new List<GameObject>(5);

    // Method to add a GameObject to the list
    public void AddGameObject(GameObject go)
    {
        if (gameObjects.Count < 5)
        {
            gameObjects.Add(go);
        }
    }

    // Method to check if the list contains the specified GameObject
    public bool Contains(GameObject go)
    {
        return gameObjects.Contains(go);
    }

    public GameObject GetFirstGameObject()
    {
        Debug.Log(gameObjects[0].tag);
        return gameObjects[0];
    }
}
