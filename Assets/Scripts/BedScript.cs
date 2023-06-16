using System.Collections.Generic;
using UnityEngine;

public class BedScript : MonoBehaviour
{
    public static bool objectTouched;
    private SceneChanger _changer;

    public void Start()
    {
        if (!(ProgressManager.Instance.light == ProgressManager.LightState.Night))
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            _changer = GameObject.FindGameObjectWithTag("SceneChanger").GetComponent<SceneChanger>();
        }
    }
    private void OnMouseDown()
    {
        List<Quest> activeQuests = ProgressManager.Instance.Quests;

        objectTouched = true;

        if (activeQuests.Count == 4)
        {
            SceneChanger.indexScene = 17;
        }
        else if (activeQuests.Count == 9)
        {
            SceneChanger.indexScene = 23;
        }
        
        _changer.Fade();
    }
    private void OnMouseUp()
    {
        objectTouched = false;
    }
}
