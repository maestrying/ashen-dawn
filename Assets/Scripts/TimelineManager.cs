using System.Linq;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    public int indexNextScene;
    public Vector3 nextPosition;
    public SceneChanger sceneChanger;
    private PlayableDirector _director;
    public Quest[] quests;

    void Start()
    {
        _director = GetComponent<PlayableDirector>();   
        SceneChanger.indexScene = indexNextScene;
        SceneChanger.position = nextPosition;
    }

    void Update()
    {
        if (_director.state == PlayState.Paused)
        {
            if (quests.Count() > 0) { 
                foreach (Quest quest in quests)
                {
                    ProgressManager.Instance.addQuest(quest);
                }

                ProgressManager.Instance.light = ProgressManager.LightState.Day;
            }
            sceneChanger.Fade();
        }
    }
}
