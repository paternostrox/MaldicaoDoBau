using UnityEngine;
using System.Collections;
using TMPro;

[System.Serializable]
public struct Dialogue 
{
    [TextArea]
    public string dialogueText; 
    public AudioClip clip; 
}

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Main;

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
        ShowTextMessage("Bem vindo herói, aproxime-se de um NPC e aperte 'E'.", 4f);
    }

    public void PlayDialogues(Dialogue[] dialogues, AudioSource audioSource)
    {
        StartCoroutine(DialogueRun(dialogues, audioSource));
    }

    IEnumerator DialogueRun(Dialogue[] dialogues, AudioSource audioSource)
    {
        for(int i=0; i<dialogues.Length; i++)
        {
            audioSource.PlayOneShot(dialogues[i].clip);
            UIText.text = dialogues[i].dialogueText;
            ShowPanel();
            float exibitionTime = dialogues[i].clip.length + .5f;
            yield return new WaitForSeconds(exibitionTime);
        }
        HidePanel();
    }

    public void ShowTextMessage(string newText, float exibitionTime)
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
