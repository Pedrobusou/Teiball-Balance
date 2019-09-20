using UnityEngine;

public class Checkpoint : MonoBehaviour, ISoundSource
{
    private SoundSourceController _soundSourceController;
    [SerializeField] private AudioClip sound;
    [SerializeField] private float volume = 1f;

    public AudioClip Sound => sound;
    public float Volume => volume;
    public Vector3 Position => transform.position;

    private void Awake()
    {
        _soundSourceController = new SoundSourceController(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        _soundSourceController.Play();
    }
}