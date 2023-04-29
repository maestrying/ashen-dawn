using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    public void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, int id)
    {
        Debug.Log("Starting dialogue with: " +  dialogue.name);

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


    }
}
