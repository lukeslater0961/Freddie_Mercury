using UnityEngine;
using System.Collections;

public class CatacombsStateManager : MonoBehaviour 
{
	public static Catacombs1State catacombs1State = new Catacombs1State();
	public static Catacombs2State catacombs2State = new Catacombs2State();
	public static Catacombs3State catacombs3State = new Catacombs3State();
	private LevelBaseState<CatacombsStateManager> currentState = null;

	public void SwitchState(LevelBaseState<CatacombsStateManager> state)
	{
		currentState = state;
		currentState.EnterState(this);
	}

	public void RunCoroutine(IEnumerator routine)
    {
        StartCoroutine(routine);
    }
}
