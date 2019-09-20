
using UnityEngine;

public class SoundSourceController
{
    private ISoundSource _soundSource;

    public SoundSourceController(ISoundSource soundSource)
    {
        _soundSource = soundSource;
    }

    public void Play()
    {
        AudioSource.PlayClipAtPoint(_soundSource.Sound, _soundSource.Position, _soundSource.Volume);
    }
}
