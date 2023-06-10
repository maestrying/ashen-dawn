using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonologueManager : MonoBehaviour
{
    public GameObject monologueWindow;
    public Text monologueText;
    public GameObject ui;
    private Queue<string> sentences;

    public void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartMonologue(Monologue monologue)
    {
        sentences.Clear();
        monologueWindow.SetActive(true);
        
        foreach (string sentence in monologue.sentences) 
        {
            sentences.Enqueue(sentence); 
        }

        NextSentence();
    }
    public void NextSentence()
    {
        if (sentences.Count == 0)
        {
            EndMonologue();
            return;
        }

        string sentence = sentences.Dequeue();
        monologueText.text = sentence;

        Invoke("NextSentence", sentence.Length / 4);
        Debug.Log(sentence);
    }

    public void EndMonologue()
    {
        monologueWindow.SetActive(false);
    }
}
