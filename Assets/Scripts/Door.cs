using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public Transform player;

    public Vector2 positionToMove;

    public bool NeedsButton { get { return true; } set => throw new System.NotImplementedException(); }

    public void Interact()
    {
        player.position = positionToMove;
    }
}
