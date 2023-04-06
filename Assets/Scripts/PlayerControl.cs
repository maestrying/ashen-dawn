using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 _input;
    private bool _IsMoving;
    
    private Rigidbody2D _rigidbody;
    private PlayerAnimations _animations;
    [SerializeField] private SpriteRenderer _characterSprite;
    [SerializeField] private VectorValue _position;

    private void Start()
    {
        transform.position = _position.initialValue;
        _characterSprite.flipX = _position.flipPlayer;

        _rigidbody = GetComponent<Rigidbody2D>();
        _animations = GetComponentInChildren<PlayerAnimations>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
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
        _input = new Vector2(Input.GetAxis("Horizontal"), 0); // Заменить на вектор (0, 0)
    }
}
