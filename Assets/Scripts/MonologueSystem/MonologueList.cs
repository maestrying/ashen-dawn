using UnityEngine;

public class MonologueList : MonoBehaviour
{
    public Monologue monologue;
    public MonologueManager manager;
    public void StartMonologue()
    {
        manager.StartMonologue(monologue);
    }
}
