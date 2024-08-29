using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionState : MonoBehaviour
{
    [SerializeField] private LayerMask _collisionLayer;
    //[SerializeField] private Vector2 _bottomPosition = Vector2.zero;
    //[SerializeField]
    //private Vector2 _rightPosition = Vector2.zero;
    //[SerializeField]
    //private Vector2 _leftPosition = Vector2.zero;
    //[SerializeField] private float _collisionRadius = 10f;
    [SerializeField] private Color _debugCollisionColor = Color.red;

    private Size _size;

    public float y = 1f;

    public static event Action OnLanded;

    public bool Standing { get; private set; }

    private bool _onAir = false;

    private void Awake()
    {
        _size = GetComponentInParent<Size>();
    }

    private void FixedUpdate()
    {
        var pos = Vector2.zero;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        float x = _size.GetSize / 2 - _size.GetSize / 10;

        Vector2 size = Vector2.zero;
        size.x += x;
        size.y += y;

        if (!Standing)
            _onAir = true;
        

        Standing = Physics2D.OverlapBox(pos, size, 0, _collisionLayer);

        if (Standing && _onAir)
        {
            _onAir = false;
            OnLanded?.Invoke();
        }


    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = _debugCollisionColor;

    //    var pos = Vector2.zero;
    //    pos.x += transform.position.x;
    //    pos.y += transform.position.y;

    //    float x = _size.GetSize / 2 - _size.GetSize / 10;

    //    Vector2 size = Vector2.zero;
    //    size.x += x;
    //    size.y += y;

    //    Gizmos.DrawWireCube(pos, size);

    //}
}
