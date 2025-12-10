using UnityEngine;

public class Door : MonoBehaviour
{
	[SerializeField] Animator		animator;
	[SerializeField] AudioSource	sound;

    void OnEnable()
    {
       BasePuzzleHandler.OnAllPuzzlesCompleted += OpenDoor;
    }

    void OpenDoor()
    {
		BasePuzzleHandler.OnAllPuzzlesCompleted -= OpenDoor;
		Debug.Log($"opening door {gameObject.name}");
		sound.Play();
		animator.SetTrigger("OpenDoor");
    }
}
