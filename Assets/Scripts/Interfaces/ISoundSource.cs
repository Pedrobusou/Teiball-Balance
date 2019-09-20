using UnityEngine;

public interface ISoundSource
{
    AudioClip Sound { get; }
    Vector3 Position { get; }
    float Volume { get; }
}
