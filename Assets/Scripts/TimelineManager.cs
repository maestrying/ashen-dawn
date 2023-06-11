using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    public int indexNextScene;
    public Vector3 nextPosition;
    public SceneChanger sceneChanger;
    private PlayableDirector _director;

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
            sceneChanger.Fade();
        }
    }
}
