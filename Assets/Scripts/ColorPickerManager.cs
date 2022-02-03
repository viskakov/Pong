using UnityEngine;
using UnityEngine.UI;

public class ColorPickerManager : MonoBehaviour
{
    [SerializeField] private GameObject _colorPickerPanel;
    [SerializeField] private Button _menuButton;

    private bool _windowState;

    private void Awake()
    {
        _windowState = _colorPickerPanel.activeSelf;
        _menuButton.onClick.AddListener(SwitchPanel);
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
