using UnityEngine;

public abstract class LevelBaseState<TManager>
{
    public abstract void EnterState(TManager manager);
    public abstract void UnsubToEvents();
}
