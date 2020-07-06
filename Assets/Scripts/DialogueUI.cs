﻿using UnityEngine;
using System.Collections;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Main;

    public TMP_Text UIText;

    public GameObject dialoguePanel;

    private void Awake()
    {
        if(Main == null)
        {
            Main = this;
            return;
        }
        Destroy(this);
    }

    private void Start()
    {
        ChangeText("Dica: Aproxime-se de um NPC e aperte 'E'.",4f);
    }

    public void ChangeText(string newText, float exibitionTime)
    {
        UIText.text = newText;
        ShowPanel();
        Invoke("HidePanel", exibitionTime);
    }

    public void ShowPanel()
    {
        dialoguePanel.SetActive(true);
    }

    public void HidePanel()
    {
        dialoguePanel.SetActive(false);
    }
}