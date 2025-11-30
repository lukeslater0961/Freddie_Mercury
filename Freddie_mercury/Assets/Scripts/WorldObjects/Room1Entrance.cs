using UnityEngine;
using System;

public class Room1Entrance : BaseRoomEntrance
{
	[SerializeField] GameObject door;
	public override void RoomEntered()
	{
		if (door)
			door.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
	}
}
