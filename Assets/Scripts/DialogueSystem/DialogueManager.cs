using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public NPCScript npcScript;
    public GameObject dialogueWindow;
    public Text dialogueText;
    public GameObject ui;
    private Queue<string> sentences;

    private NPCDialogues npc;
    private int id;

    public void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(NPCDialogues npc, int id)
    {
        this.npc = npc;
        this.id = id;

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
        if (npc.dialogues[id].isQuestDialogue)
        {
            npcScript.giveQuest(npc.dialogues[id].questId);
        }

        if (npc.dialogues[id].isOneTimeDialogue)
        {
            npcScript.GetComponent<CircleCollider2D>().enabled = false;
        }


        dialogueWindow.SetActive(false);
        ui.SetActive(true);
    }
}
