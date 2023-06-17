using UnityEngine;

public class MonologueTrigger : MonoBehaviour
{
    private MonologueList monologue;
    public int id;
    public bool hideUI;

    private void Awake()
    {
        monologue = GetComponent<MonologueList>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Character")
        {
            monologue.StartMonologue(id, hideUI);
            Destroy(gameObject);
        }
    }
}
