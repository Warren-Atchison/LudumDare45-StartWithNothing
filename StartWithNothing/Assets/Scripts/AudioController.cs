using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource sfxSource; // Audio source for playing sound effects
    public AudioSource musicSource; // Audio source for playing persistent music
    public static AudioController audioController = null; // Allows other scripts to call functions within AudioController

    // Awake is called when the script is loaded to the scene
    void Awake()
    {
        // If there is no instance of audioController, make it this
        if (audioController == null)
            audioController = this;
        // Enforces a singleton on the audioController ensuring there will only be one audioController
        else if (audioController != this)
            Destroy(gameObject);

        // Sets AudioController to DontDestroyOnLoad so that it won't be destroyed when reloading a scene
        DontDestroyOnLoad(gameObject);
    }

    // Function to play a single sound clip
    public void Play(AudioClip soundClip)
    {
        // Sets the clip played by the sfx audio source to the input clip
        sfxSource.clip = soundClip;
    }
}
