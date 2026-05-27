using System.Collections;
using UnityEngine;
using System;

public class CatacombsStateManager : RoomBaseStateManager
{
	public static CatacombsEntranceState catacombsEntranceState = new CatacombsEntranceState();
	public static Catacombs1State catacombs1State = new Catacombs1State();
	public static Catacombs2State catacombs2State = new Catacombs2State();
	public static Catacombs3State catacombs3State = new Catacombs3State();
	public static Catacombs4State catacombs4State = new Catacombs4State();

	private LevelBaseState<CatacombsStateManager> currentState = null;

	public EventHandler eventHandler;

	void Awake()
	{
		eventHandler = new EventHandler();
	}

	/*void OnDestroy()
	{
		catacombsEntranceState = null;
		catacombs1State = null;
		catacombs2State = null;
		catacombs3State = null;
		catacombs4State = null;
	}*/

	public void SwitchState(LevelBaseState<CatacombsStateManager> state)
	{
		Debug.Log($"switching state to {state}");
		currentState = state;
		currentState.EnterState(this);
	}
}
