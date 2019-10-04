using UnityEngine;

public class ParticleEmisor : MonoBehaviour
{
    private ParticleSystem ps;
    public string targetCollider;

    void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(targetCollider)) ps.Play();
    }
}
