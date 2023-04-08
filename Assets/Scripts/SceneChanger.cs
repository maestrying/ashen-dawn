using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneChanger : MonoBehaviour
{
    private Animator _anim;
    public static int _indexScene;

    private void FixedUpdate() {
        Debug.Log(_indexScene);
    }
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
        SceneManager.LoadScene(_indexScene);
        
    }
}
