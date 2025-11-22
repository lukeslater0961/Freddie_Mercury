using UnityEngine;
using System;

public class LevelEntrance : MonoBehaviour
{
   public static event Action EntranceExited;

   void OnTriggerEnter()
   {
        EntranceExited?.Invoke();
   }
}
