using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueWindow;
    public Text dialogueText;
    public GameObject ui;
    private Queue<string> sentences;

    public void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(NPCDialogues npc, int id)
    {
        sentences.Clear();
        ui.SetActive(false);

        Dialogue dialogue = npc.dialogues[id];
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
 
        NextSentence();
    }

    public void NextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        dialogueWindow.SetActive(false);
        ui.SetActive(true);
    }
}
