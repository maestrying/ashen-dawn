using System.Collections.Generic;
using UnityEngine;

public class TvScript : MonoBehaviour
{
    private void Start()
    {
        List<Quest> activeQuests = ProgressManager.Instance.Quests;
        Animator animator = GetComponent<Animator>();

        if ((activeQuests.Count == 8 && activeQuests[7].questState == Quest.state.Completed) || (activeQuests.Count == 9 && activeQuests[8].questState == Quest.state.InProgress))
        {
            animator.SetBool("isBroken", true);
        }
        else
        {
            animator.SetBool("isBroken", false);
        }
    }
}
