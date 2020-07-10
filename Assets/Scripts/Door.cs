using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public Transform player;

    public Vector2 positionToMove;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public bool NeedsButton { get { return true; } set => throw new System.NotImplementedException(); }

    public void Interact()
    {
        audioSource.Play();
        Invoke("TeleportPlayer", .5f);
    }

    void TeleportPlayer()
    {
        player.position = positionToMove;
    }
}
