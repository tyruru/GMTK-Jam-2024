using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSize : AbstractBehaviour
{
    private FindItems _findItems;
    private Size _characterSize;
    private Size _itemSize;

    [SerializeField] private float _coef = 0.05f;
    [SerializeField] private float _minSize = 0.4f;

    private void Start()
    {
        _findItems = GetComponent<FindItems>();
        _characterSize = GetComponent<Size>();
    }

    private void Update()
    {
        var giveSize = inputState.GetButtonValue(inputButtons[0]);
        var takeSize = inputState.GetButtonValue(inputButtons[1]);

        if (giveSize)
            GiveSize();
        if (takeSize)
            TakeSize();

    }

    public void GiveSize()
    {
        if (_findItems.CurrentTarget != null)
        {
            _itemSize = _findItems.CurrentTarget.GetComponent<Size>();

            if (_characterSize.GetSize > _minSize)
            {
                _characterSize.SetSize = _characterSize.GetSize - _coef;

                _itemSize.SetSize = _itemSize.GetSize + _coef;
                SizeUpdate();
            }
        }
    }

    public void TakeSize()
    {
        if (_findItems.CurrentTarget != null)
        {
            _itemSize = _findItems.CurrentTarget.GetComponent<Size>();

            if (_itemSize.GetSize > _minSize)
            { 
                _characterSize.SetSize = _characterSize.GetSize + _coef;

                _itemSize.SetSize = _itemSize.GetSize - _coef;
                SizeUpdate();
            }
        }
    }

    private void SizeUpdate()
    {
        _itemSize.UpdateSize();
        _characterSize.UpdateSize();
    }



}
