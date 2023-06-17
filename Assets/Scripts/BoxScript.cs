using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public Sprite box;
    public Quest[] quests;
    public static bool objectTouched;

    private void OnMouseDown()
    {
        objectTouched = true;
        GetComponent<BoxCollider2D>().enabled = false;

        GetComponent<SpriteRenderer>().sprite = box;
        ProgressManager.Instance.setStateQuest(1, 0, Quest.state.BackToComplete);
        
        foreach (Quest quest in quests)
        {
            ProgressManager.Instance.addQuest(quest);
        }
    }

    private void OnMouseUp()
    {
        objectTouched = false;
    }
}
