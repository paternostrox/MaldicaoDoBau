using UnityEngine;
using System.Collections;

public interface IInteractable
{
    bool NeedsButton { get; set; }

    void Interact();
}
