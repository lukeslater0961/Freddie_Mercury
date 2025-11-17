using UnityEngine;

public class RecordPlayer : Interactible
{
	[SerializeField] AudioSource audioSource;

	public override void OnSelect()
	{
		if (audioSource.isPlaying)
			audioSource.Stop();
		else
			audioSource.Play();
	}
}
