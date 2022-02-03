using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private ColorPicker _colorPicker;
    [SerializeField] private Button _menuButton;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        _menuButton.onClick.AddListener(_colorPicker.SwitchPanel);
    }

    private void OnDestroy()
    {
        _menuButton.onClick.RemoveListener(_colorPicker.SwitchPanel);
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;

        _colorPicker.SwitchPanel();
    }
}
