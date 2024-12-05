using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sounds", menuName = "SoundsSriptable", order = 1)]
public class SoundClipsScriptable : ScriptableObject
{
    public List<AudioClip> audioClips;
}
