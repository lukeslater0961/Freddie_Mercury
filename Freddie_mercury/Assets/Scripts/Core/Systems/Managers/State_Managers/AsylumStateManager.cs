using System.Collections;
using UnityEngine;
using System;

public class AsylumStateManager : RoomBaseStateManager 
{
	public static AsylumEntranceState asylumEntranceState = new AsylumEntranceState();
	public static Asylum1State asylum1State = new Asylum1State();
	public static Asylum2State asylum2State = new Asylum2State();
	public static Asylum3State asylum3State = new Asylum3State();

	private LevelBaseState<AsylumStateManager> currentState = null;

	private EventHandler eventHandler;

	void Awake()
	{
		eventHandler = new EventHandler();
	}

	public void SwitchState(LevelBaseState<AsylumStateManager> state)
	{
		currentState = state;
		currentState.EnterState(this);
	}
}
