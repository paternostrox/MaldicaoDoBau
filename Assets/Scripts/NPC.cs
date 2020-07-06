using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [TextArea]
    public string dialogue;

    public float exibitionTime = 5f;

    public bool needsButton = true;

    public bool NeedsButton { 
        get { return needsButton; } 
        set { needsButton = value; } 
    }

    public void Interact()
    {
        DialogueUI.Main.ChangeText(dialogue, exibitionTime);
    }
}
