using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeTrigger : MonoBehaviour
{
    [SerializeField] private int _indexScene;
    private SceneChanger _sceneChanger;


    private void Awake()
    {
        _sceneChanger = GameObject.Find("SceneChanger").GetComponent<SceneChanger>();
    }
    public void changeScene()
    {
        SceneChanger.indexScene = _indexScene;
        _sceneChanger.Fade();
       
    }
}
