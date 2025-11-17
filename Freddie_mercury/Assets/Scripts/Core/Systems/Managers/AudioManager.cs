using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
	[SerializeField]	AudioMixer		masterMixer;
	[SerializeField]	float			defaultVolume = 0f;

	public void InitAudio()
	{
		Debug.Log("Audio Manager => Initializing mixers");
		masterMixer.SetFloat("MusicVol", defaultVolume);
		masterMixer.SetFloat("VFXVol", defaultVolume);
	}
}
