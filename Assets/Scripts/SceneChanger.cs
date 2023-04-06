using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] private int _indexScene;

    [SerializeField] private Vector3 _position;
    [SerializeField] private VectorValue _positionStorage;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void Fade()
    {
        _anim.SetTrigger("fade");
    }

    public void FadeComplete()
    {
        _positionStorage.initialValue = _position;
        SceneManager.LoadScene(_indexScene);
    }
}
