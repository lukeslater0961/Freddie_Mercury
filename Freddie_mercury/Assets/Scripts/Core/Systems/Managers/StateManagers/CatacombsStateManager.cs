using System.Collections;
using UnityEngine;
using System;

public class CatacombsStateManager : RoomBaseStateManager
{
	public static CatacombsEntranceState catacombsEntranceState = new CatacombsEntranceState();
	public static Catacombs1State catacombs1State = new Catacombs1State();
	public static Catacombs2State catacombs2State = new Catacombs2State();
	public static Catacombs3State catacombs3State = new Catacombs3State();

	private LevelBaseState<CatacombsStateManager> currentState = null;

	public EventHandler eventHandler;

	void Awake()
	{
		eventHandler = new EventHandler();
	}

	public void SwitchState(LevelBaseState<CatacombsStateManager> state)
	{
		currentState = state;
		currentState.EnterState(this);
	}
}
