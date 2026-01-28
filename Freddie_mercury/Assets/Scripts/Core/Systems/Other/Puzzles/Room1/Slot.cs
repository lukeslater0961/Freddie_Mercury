using UnityEngine;
using System;

public class Slot : MonoBehaviour
{
	public static event Action<bool, int> OnObjectPlaced;

	public int id;

    private PuzzleObject objectInTrigger;

    void OnTriggerStay(Collider other)
    {
        var obj = other.GetComponent<PuzzleObject>();
        if (obj != null)
        {
            objectInTrigger = obj;
			SetObject(objectInTrigger);
        }
    }

    void OnTriggerExit(Collider other)
    {
        var obj = other.GetComponent<PuzzleObject>();
        if (obj != null && objectInTrigger == obj)
            objectInTrigger = null;
    }

    public void SetObject(PuzzleObject obj)
    {
		Debug.Log($"Object of Id {obj.id} was place on id {id}");
		if (obj.id == id)
			OnObjectPlaced?.Invoke(true, id);
		else
			OnObjectPlaced?.Invoke(false, id);
	}
}
