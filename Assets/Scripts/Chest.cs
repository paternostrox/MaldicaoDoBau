using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public bool NeedsButton { get { return true; } set => throw new System.NotImplementedException(); }

    public Dialogue[] dialogues;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        DialogueManager.Main.PlayDialogues(dialogues, audioSource);
        Invoke("CloseGame", 6f);
    }

    void CloseGame()
    {
        Application.Quit();
    }
}
