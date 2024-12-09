using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;

    [SerializeField] private AudioSource sfxObject;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void PlaySFXClip(AudioClip sfxClip, Transform spawnTransform, float volume=1.0f)
    {
        //spawn in gameObject
        AudioSource audioSource = Instantiate(sfxObject, spawnTransform.position, Quaternion.identity);

        //assign the AudioClip
        audioSource.clip = sfxClip;

        //assign volume
        audioSource.volume = volume;

        //play sound
        audioSource.Play();

        //get lenght of sfxClip
        float clipLength = audioSource.clip.length;

        //destroy gameObject
        Destroy(audioSource.gameObject, clipLength);
    }

    public void PlayRandomSFXClip(AudioClip[] sfxClip, Transform spawnTransform, float volume=1.0f)
    {
        //assign a random index
        int randIdx = Random.Range(0, sfxClip.Length);

        //spawn in gameObject
        AudioSource audioSource = Instantiate(sfxObject, spawnTransform.position, Quaternion.identity);

        //assign the AudioClip
        audioSource.clip = sfxClip[randIdx];

        //assign volume
        audioSource.volume = volume;

        // Apply a random pitch variation between 0.9x and 1.1x speed/pitch
        audioSource.pitch = Random.Range(0.9f, 1.1f);

        //play sound
        audioSource.Play();

        // Get the length of the clip (adjusted for pitch)
        float clipLength = audioSource.clip.length / Mathf.Abs(audioSource.pitch);

        //destroy gameObject
        Destroy(audioSource.gameObject, clipLength);
    }
}


// to play sfx use
// [SerializeField] private AudioClip <soundClip name>
// SoundFXManager.instance.PlaySFXClip(<soundClip name>, transform, <volume float - default 1.0f>)

// for random sfx use
// [SerializeField] private AudioClip[] <soundClip name>
// SoundFXManager.instance.PlayRandomSFXClip(<soundClip name>, transform, <volume float - default 1.0f>)