using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       Room1PuzzleHandler.OnAllPuzzlesCompleted += OpenDoor;
    }

    // Update is called once per frame
    void OnDestroy()
    {
       Room1PuzzleHandler.OnAllPuzzlesCompleted -= OpenDoor;
    }

    void OpenDoor()
    {
        gameObject.SetActive(false);
    }
}
