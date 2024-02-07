using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform[] destination;

    public Transform GetDestination()
    {
        if (destination.Length == 0)
        {
            Debug.LogError("No destinations set for the teleporter!");
            return null;
        }

        int randomIndex = Random.Range(0, destination.Length);
        return destination[randomIndex];
    }
}
