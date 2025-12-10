using UnityEngine;
using System;

public class Room2Exit : MonoBehaviour
{
    public static event Action OnRoomExited;

    void OnTriggerEnter(Collider other)
    {
		Debug.Log($"Room exit triggered by {other.gameObject.name}");
        OnRoomExited?.Invoke();
        gameObject.SetActive(false);
    } 
}
