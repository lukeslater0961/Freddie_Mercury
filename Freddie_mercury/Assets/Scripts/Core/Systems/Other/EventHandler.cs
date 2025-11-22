using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public void ApplyTimerPenalty(RoomBaseStateManager manager)
    {
		manager.ApplyTimePenalty();
    }
}
