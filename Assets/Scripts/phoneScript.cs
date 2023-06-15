using UnityEngine;

public class phoneScript : MonoBehaviour
{
    CircleCollider2D circleCollider;
    public void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();

        circleCollider.enabled = (ProgressManager.Instance.Quests.Count == 5 && ProgressManager.Instance.Quests[4].questState == Quest.state.InProgress) ? true : false;
    }
}
