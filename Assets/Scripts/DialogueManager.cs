using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.Audio;

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

    public AudioMixerGroup dialogueGroup;

    float dialoguePitch;

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

        dialogueGroup.audioMixer.GetFloat("dialoguePitch", out dialoguePitch);
        ShowTextMessage("Bem vindo herói, aproxime-se de um NPC e aperte 'E'.", 2.5f);
    }

    public void PlayDialogues(Dialogue[] dialogues, AudioSource audioSource)
    {
        StartCoroutine(DialogueRun(dialogues, audioSource));
    }

    IEnumerator DialogueRun(Dialogue[] dialogues, AudioSource audioSource)
    {
        PlayerController.Main.isFrozen = true;
        for(int i=0; i<dialogues.Length; i++)
        {
            if (dialogues[i].clip != null)
            {
                audioSource.PlayOneShot(dialogues[i].clip);
                UIText.text = dialogues[i].dialogueText;
                ShowPanel();
                float exibitionTime = dialogues[i].clip.length / Mathf.Abs(dialoguePitch) + .5f;
                print(exibitionTime);
                yield return new WaitForSeconds(exibitionTime);
            }
        }
        HidePanel();
        PlayerController.Main.isFrozen = false;
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
