using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectLibrary : MonoBehaviour
{
    [SerializeField] private SoundEffectGroup[] soundEffectGroups;
    private Dictionary<string, List<AudioClip>> soundDictionary;

    private void Awake()
    {
        InitializeDictionary();
    }

    private void InitializeDictionary()
    {
        soundDictionary = new Dictionary<string, List<AudioClip>>();
        foreach (SoundEffectGroup soundEffectGroup in soundEffectGroups)
        {
            soundDictionary[soundEffectGroup.name] = soundEffectGroup.audioClips;
        }
    }

    public AudioClip GetRandomClip(string name)
    {
        if (soundDictionary.ContainsKey(name))
        {
            List<AudioClip> audioCLips = soundDictionary[name];
            if (audioCLips.Count > 0)
            {
                return audioCLips[UnityEngine.Random.Range(0, audioCLips.Count)];
            }
        }
        return null;
    }

    [System.Serializable]
    public struct SoundEffectGroup
    {
        public string name;
        public List<AudioClip> audioClips;
    }
}