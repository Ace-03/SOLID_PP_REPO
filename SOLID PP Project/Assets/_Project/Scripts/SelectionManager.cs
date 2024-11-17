﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour
{
    private IRayProvider _rayProvider;
    private ISelector _selector;
    private ISelectionResponse _selectionRespones;

    private Transform _currentSelection;
    

    private void Awake()
    {
        SceneManager.LoadScene("Environment", LoadSceneMode.Additive);
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);

        _rayProvider = GetComponent<IRayProvider>();
        _selector = GetComponent<ISelector>();
        _selectionRespones = GetComponent<ISelectionResponse>();
    }

    private void Update()
    {
        if (_currentSelection != null) _selectionRespones.OnDeselect(_currentSelection);

        _selector.Check(_rayProvider.CreateRay());
        _currentSelection = _selector.GetSelection();

        if (_currentSelection != null)  _selectionRespones.OnSelect(_currentSelection);
        
    }
}







