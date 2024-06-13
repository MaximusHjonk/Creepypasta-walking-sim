using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationWaypoint : InteractableObject
{
    public AudioClip interactClip;
    public Vector3 offset;

    private ParticleSystem particles;
    private Collider objectCollider;
    private AudioSource audioSource;

    private void Awake()
    {
        particles = GetComponentInChildren<ParticleSystem>();
        objectCollider = GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (objectCollider != null)
        {
            objectCollider.enabled = true;
        }

        if (particles != null)
        {
            particles.Play();
        }
    }

    public override bool Activate()
    {
        if (Interaction2.instance.CurrentWaypoint != this)
        {
            if (Interaction2.instance.CurrentWaypoint != null)
            {
                Interaction2.instance.CurrentWaypoint.Deactivate();
            }

            Interaction2.instance.CurrentWaypoint = this;
            Interaction2.instance.transform.parent.position = transform.position + offset;

            if (objectCollider != null)
            {
                objectCollider.enabled = false;
            }
            if (particles != null)
            {
                particles.Stop();
            }
            if (audioSource != null && interactClip != null)
            {
                audioSource.PlayOneShot(interactClip);
            }
            return true;
        }
        return false;
    }

    public override bool Deactivate()
    {
        if (Interaction2.instance.CurrentWaypoint == this)
        {
            Interaction2.instance.CurrentWaypoint = null;
            if (objectCollider != null)
            {
                objectCollider.enabled = true;
            }
            if (particles != null)
            {
                particles.Play();
            }
            return true;
        }
        
        return false;
    }
}
