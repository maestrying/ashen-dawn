using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueWindow;
    public Text dialogueText;
    private Queue<string> sentences;

    public void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, int id)
    {
        sentences.Clear();

        foreach (Sentences sentence in dialogue.sentences)
        {
            if (sentence.id == id)
            {
                foreach(string sentence2 in sentence.sentences)
                {
                    sentences.Enqueue(sentence2);
                }
            }
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
    }
}
