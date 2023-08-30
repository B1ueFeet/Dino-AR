using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public enum Sound
    {
        playerSteep01,
        playerSteep02, pterodactyl,
        wind,
            music
    }
    public static void PlaySound(Sound sound)
    {
        GameObject soundGO = new GameObject("Sound");
        AudioSource audioSource = soundGO.AddComponent<AudioSource>();
        audioSource.PlayOneShot(getAudioClip(sound));
    }

    private static AudioClip getAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip audioClip in GameAssets.i.audioSourceArray)
        {
            if (audioClip.sound == sound)
            {
                return audioClip.clip;
            }
        }
        Debug.LogError("Sound " + sound + " not found");
        return null;
    }
}
