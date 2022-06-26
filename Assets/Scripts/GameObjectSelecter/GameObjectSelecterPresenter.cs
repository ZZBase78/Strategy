using Abstractions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserControlSystem;

public class GameObjectSelecterPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectedValue;
    [SerializeField] private GameObject _prefab;

    private GameObject _currentSelect;
    private bool _isActive = false;

    void Start()
    {
        _selectedValue.OnSelected += OnSelected;
        OnSelected(_selectedValue.CurrentValue);
    }

    private void OnSelected(ISelectable selected)
    {
        DestroyView();
        if (selected != null) InstantiateView(selected);
    }

    private void DestroyView()
    {
        if (_isActive)
        {
            GameObject.Destroy(_currentSelect);
            _isActive = false;
        }
    }

    private void InstantiateView(ISelectable selected)
    {
        _currentSelect = Instantiate(_prefab, selected.GameObject.transform.position, Quaternion.identity);
        SelectedView selectedView = _currentSelect.GetComponent<SelectedView>();
        selectedView.Init(selected.ViewSelectSize * 0.75f, selected.ViewSelectSize);
        _isActive = true;
    }

    private void OnDestroy()
    {
        DestroyView();
    }
}
