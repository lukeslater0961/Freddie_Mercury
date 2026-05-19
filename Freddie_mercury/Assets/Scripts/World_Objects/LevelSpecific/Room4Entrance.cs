using UnityEngine;
using System;

public class Room4Entrance : BaseRoomEntrance
{
	[SerializeField] GameObject door;

	public override void RoomEntered()
	{
		if (door)
		{
			door.SetActive(true); 
			gameObject.SetActive(false);
        }
	}
}
