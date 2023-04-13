using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _pcMode; // delete later
    private Vector3 _input;
    private bool _IsMoving;
    
    private Rigidbody2D _rigidbody;
    private PlayerAnimations _animations;
    [SerializeField] private SpriteRenderer _characterSprite;
    private AudioSource _moveSound;

    private void Start()
    {
        if (SceneChanger.position != new Vector3(0,0,0)) transform.position = SceneChanger.position;
        _rigidbody = GetComponent<Rigidbody2D>();
        _animations = GetComponentInChildren<PlayerAnimations>();
        _moveSound = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_pcMode) _input = new Vector2(Input.GetAxis("Horizontal"), 0); // delete later

        transform.position += _input * _speed * Time.deltaTime;

        _IsMoving = _input.x != 0 ? true : false;

        if (_IsMoving) {
            _characterSprite.flipX = _input.x < 0 ? true : false;
        }

        _animations.IsMoving = _IsMoving;
    }

    public void OnLeftButtonDown()
    {
        _input = new Vector2(-1, 0);
        _moveSound.Play();
    }

    public void OnRightButtonDown()
    {
        _input = new Vector2(1, 0);
        _moveSound.Play();
    }

    public void OnButtonUp() 
    {
        _input = new Vector2(0, 0);
        _moveSound.Stop();
    }
}
