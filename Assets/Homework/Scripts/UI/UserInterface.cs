using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class UserInterface : MonoBehaviour
{
    [SerializeField] private PanelOne _panelOne;
    [SerializeField] private PanelTwo _panelTwo;
    private readonly Stack<StateUI> _stateUI = new Stack<StateUI>();
    private BaseUI _currentWindow;

    private void Start()
    {
        _panelOne.Cancel();
        _panelTwo.Cancel();
    }

    private void Execute(StateUI stateUI, bool isSave = true)
    {
        if(_currentWindow != null)
        {
            _currentWindow.Cancel();
        }
        switch (stateUI)
        {
            case StateUI.PanelOne:
                _currentWindow = _panelOne;
                break;

            case StateUI.PanelTwo:
                _currentWindow = _panelTwo;
                break;

            default:
                break;
                
        }

        _currentWindow.Execute();
        if (isSave)
        {
            _stateUI.Push(stateUI);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Execute(StateUI.PanelOne);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Execute(StateUI.PanelTwo);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(_stateUI.Count > 0)
            {
                Execute(_stateUI.Pop(), false);
            }
        }
    }
}
