using UnityEngine;
using System.Collections;

public class Room3_Platforms : MonoBehaviour
{
	[SerializeField]	Transform targetTransform;
	float speed	= 1f;
	float step;

    void OnEnable()
    {
       BasePuzzleHandler.OnAllPuzzlesCompleted += CallRaisePlatforms;
    }

	void OnDisable()
	{
       BasePuzzleHandler.OnAllPuzzlesCompleted -= CallRaisePlatforms;
	}

	void CallRaisePlatforms()
	{
		Debug.Log("Raising platforms");
		step = speed * Time.deltaTime;
		StartCoroutine(RaisePlatforms());
		BasePuzzleHandler.OnAllPuzzlesCompleted -= CallRaisePlatforms;
	}

	IEnumerator RaisePlatforms()
	{
		while (Vector3.Distance(transform.position, targetTransform.position) > 0.1f)
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, step);
			yield return null;
		}

		transform.position = targetTransform.position;
	}
}

