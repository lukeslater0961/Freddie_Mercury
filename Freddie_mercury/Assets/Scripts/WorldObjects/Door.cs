using UnityEngine;

public class Door : MonoBehaviour
{
	[SerializeField] Animator		animator;
	[SerializeField] AudioSource	sound;

    void Start()
    {
       BasePuzzleHandler.OnAllPuzzlesCompleted += OpenDoor;
    }

    void OnDestroy()
    {
       BasePuzzleHandler.OnAllPuzzlesCompleted -= OpenDoor;
    }

    void OpenDoor()
    {
		Debug.Log("opening door");
		sound.Play();
		animator.SetTrigger("OpenDoor");
    }
}
