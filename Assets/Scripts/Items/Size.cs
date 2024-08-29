using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Size : MonoBehaviour
{
    [SerializeField] private float _sizePoints = 1f;

    private void Start()
    {
        UpdateSize();
    }

    public float GetSize
    {
        get { return _sizePoints; }
    }

    public float SetSize
    {
        set { _sizePoints = value; }
    }

    public void UpdateSize()
    {
       transform.localScale = new Vector3(_sizePoints, _sizePoints, 1);
    }
}
