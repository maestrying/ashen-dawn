using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
   
    void Start()
    {
        if (ProgressManager.Instance.flashlight)
        {
            Destroy(gameObject);
        }
    }

    public void takeFlashlight()
    {
        List<Quest> quests = ProgressManager.Instance.Quests;

        if (quests.Count == 4 && quests[3].questState == Quest.state.InProgress)
        {
            ProgressManager.Instance.flashlight = true;
            ProgressManager.Instance.setStateQuest(-1, 0, Quest.state.Completed);
            ProgressManager.Instance.light = ProgressManager.LightState.Evening;

            Destroy(gameObject);
        }
    }
}
