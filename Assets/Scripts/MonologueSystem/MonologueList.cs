using UnityEngine;

public class MonologueList : MonoBehaviour
{
    public Monologue[] monologues;
    public MonologueManager manager;

    public void Awake()
    {
        manager = FindFirstObjectByType<MonologueManager>();
    }
    public void StartMonologue(int id, bool hideUI)
    {
        Debug.Log(monologues[id].sentences.Count);
        manager.StartMonologue(monologues[id], hideUI);
    }
}
