using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NPC : MonoBehaviour, IInteractable
{
    public Dialogue[] dialogues;

    public bool needsButton = true;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public bool NeedsButton { 
        get { return needsButton; } 
        set { needsButton = value; } 
    }

    public void Interact()
    {
        DialogueManager.Main.PlayDialogues(dialogues, audioSource);
    }
}
