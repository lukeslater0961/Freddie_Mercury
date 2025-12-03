using UnityEngine;
using System;

public class Room2Exit : MonoBehaviour
{
    public static event Action OnRoomExited;

    void OnTriggerEnter(Collider other)
    {
        OnRoomExited?.Invoke();
    } 
}
