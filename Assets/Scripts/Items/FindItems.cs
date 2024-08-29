using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FindItems : MonoBehaviour
{
    [SerializeField] private string _targetTag;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] Vector2 _targetZone = Vector2.zero;
    [SerializeField] float _collisionRadius = 3f;
    [SerializeField] Color _degudColor = Color.blue;

    private Collider2D _currentTarget;

    public Collider2D CurrentTarget { get { return _currentTarget; } }

    private void Update()
    {
        List<Collider2D> items = FindAllItems();

        FindClosestItem(items);

        BackLightClosestItem(items);
    }

    private List<Collider2D> FindAllItems()
    {
        var pos = _targetZone;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        var allObjects = Physics2D.OverlapCircleAll(pos, _collisionRadius, _layerMask);

        List<Collider2D> items = new();

        foreach (var ob in allObjects)
        {
            if (ob.tag.Equals(_targetTag))
                items.Add(ob);
        }

        return items;
    }

    private void FindClosestItem(List<Collider2D> items)
    {
        if (_currentTarget == null && items.Count != 0)
            _currentTarget = items[0];

        if (items.Count <= 0 && _currentTarget != null)
        {
            _currentTarget.GetComponent<BackLight>().Select = false;
            _currentTarget = null;
        }

        foreach(var item in items)
        {
            var distanceToTarget = Vector3.Distance(transform.position, item.transform.position);
            var distanceToCurrentTarget = Vector3.Distance(transform.position, _currentTarget.transform.position);

            if (distanceToTarget < distanceToCurrentTarget)
                _currentTarget = item;
        }
    }

    private void BackLightClosestItem(List<Collider2D> items)
    {
        foreach(var item in items)
        {
            if (!item.Equals(_currentTarget))
                item.GetComponent<BackLight>().Select = false;
            else if (item.Equals(_currentTarget))
                item.GetComponent<BackLight>().Select = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _degudColor;

        var pos = _targetZone;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        Gizmos.DrawWireSphere(pos, _collisionRadius);
    }
}
