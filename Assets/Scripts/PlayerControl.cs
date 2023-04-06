using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _pcMode; // ��� ��������, ����� - �������
    private Vector3 _input;
    private bool _IsMoving;
    
    private Rigidbody2D _rigidbody;
    private PlayerAnimations _animations;
    [SerializeField] private SpriteRenderer _characterSprite;
    [SerializeField] private VectorValue _position;
    [SerializeField] private bool _enableVectorPosition;

    private void Start()
    {
        _characterSprite.flipX = _position.flipPlayer;

        _rigidbody = GetComponent<Rigidbody2D>();
        _animations = GetComponentInChildren<PlayerAnimations>();

        if (_enableVectorPosition) {
            transform.position = _position.initialValue;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_pcMode) _input = new Vector2(Input.GetAxis("Horizontal"), 0); // ��� ��������, ����� - �������

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
    }

    public void OnRightButtonDown()
    {
        _input = new Vector2(1, 0);
    }

    public void OnButtonUp() 
    {
        _input = new Vector2(0, 0);
    }
}
