using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class should be attached to the main camera.
/// </summary>
/// testing if repository works
public class Interaction2 : MonoBehaviour
{
    
    public float reach = 5f;
    public Image crosshair;
    public Text infoPanel;

    public AudioClip audioClick; //click sound
    private AudioSource audioSource;

    private InteractableObject lastInteraction;

    // stores currently active InfoBox
    // is called an auto-property
    public NavigationWaypoint CurrentWaypoint { get; set; }

    //there should be only one instance of this Interaction script in the scene
    public static Interaction2 instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            enabled = false;
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * reach, Color.blue, 0.01f);

        //if ray hits object
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit objectHit, reach) == true)
        {
            if (objectHit.collider.TryGetComponent(out InteractableObject interactableThing) == true)
            {
                Debug.Log("This is an interactable object");

                if (interactableThing.GetType().ToString() == "InfoBox")
                {
                    crosshair.color = Color.green;
                    lastInteraction = interactableThing;    //last interaction becomes current thing
                }

                if (interactableThing.GetType().ToString() == "NavigationWaypoint")
                {
                    crosshair.color = Color.green;
                }
                
                if (Input.GetKeyDown(KeyCode.Mouse0) == true)
                {
                    audioSource.PlayOneShot(audioClick);

                    if (interactableThing.Activate() == false)
                    {
                        interactableThing.Deactivate();
                    }
                }
            }
        }

    }
}

public abstract class InteractableObject : MonoBehaviour
{
    //should return true if activation was successful
    public abstract bool Activate();
    
    //should return true if deactivation was successful
    public abstract bool Deactivate();
}