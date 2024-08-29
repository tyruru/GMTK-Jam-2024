using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackLight : MonoBehaviour
{
    [SerializeField] Color _selectedColor = Color.blue;
    [SerializeField] Color _unSelectedColor = Color.white;  

    private SpriteRenderer _spriteRenderer;


    public bool Select
    {
        get { return Select; }
        set
        {
            if (value == true)
                ChangeColor(_selectedColor);
            else
                ChangeColor(_unSelectedColor);    
        }
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void ChangeColor(Color color)
    {
        _spriteRenderer.color = color;
    }
}
