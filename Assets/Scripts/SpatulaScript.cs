using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatulaScript : MonoBehaviour
{
    void Start()
    {
        if (ProgressManager.Instance.spatula)
        {
            Destroy(gameObject);
        }
    }

    public void takeSpatula()
    {
        List<Quest> quests = ProgressManager.Instance.Quests;

        if (quests.Count == 8 && quests[7].questState == Quest.state.InProgress)
        {
            ProgressManager.Instance.spatula = true;
            ProgressManager.Instance.light = ProgressManager.LightState.Evening;

            Destroy(gameObject);
        }
    }
}
