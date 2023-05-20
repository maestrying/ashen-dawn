using UnityEngine;

public class SceneTimer : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private int _indexScene;
    private SceneChanger changer;

    private void Awake()
    {
        changer = GameObject.Find("SceneChanger").GetComponent<SceneChanger>();
    }

    private void FixedUpdate()
    {
        _time -= Time.deltaTime;

        if (_time <= 0 )
        {
            SceneChanger.indexScene = _indexScene;
            changer.Fade();
        }
    }
}
