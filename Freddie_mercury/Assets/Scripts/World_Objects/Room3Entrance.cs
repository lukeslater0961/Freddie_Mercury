using UnityEngine;
using System;

public class Room3Entrance : BaseRoomEntrance
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
