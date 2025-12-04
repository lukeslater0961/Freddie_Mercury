using UnityEngine;
using System;

public class Room2Entrance : BaseRoomEntrance
{
	[SerializeField] GameObject door;

	public override void RoomEntered()
	{
		if (door)
			door.SetActive(true);
	}
}
