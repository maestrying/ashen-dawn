using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] public static int _indexScene;

    [SerializeField] private Vector3 _position;
    [SerializeField] private VectorValue _positionStorage;
    [SerializeField] private SpriteRenderer _characterSprite; 

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
        _positionStorage.initialValue = _position;
        _positionStorage.flipPlayer = _characterSprite.flipX;
        SceneManager.LoadScene(_indexScene);
    }
}
