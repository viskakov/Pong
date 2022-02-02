using UnityEngine;

public class ColorPickerManager : MonoBehaviour
{
    [SerializeField] private GameObject _colorPickerPanel;

    private bool _windowState;

    private void Awake()
    {
        _windowState = _colorPickerPanel.activeSelf;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;

        SwitchPanel();
    }
    
    private void SwitchPanel()
    {
        _windowState = !_windowState;
        _colorPickerPanel.SetActive(_windowState);
    }
}
