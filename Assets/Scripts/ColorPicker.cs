using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Image _pickerImage;
    [SerializeField] private Image _colorPreview;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private ColorEvent _onColorPreviewEvent;
    [SerializeField] private ColorEvent _onColorSelectedEvent;

    private bool _windowState;
    private Texture2D _texture2D;
    private Color _selectedColor;

    private void Awake()
    {
        _texture2D = _pickerImage.mainTexture as Texture2D;
        _windowState = transform.parent.gameObject.activeSelf;
        _resumeButton.onClick.AddListener(SwitchPanel);
    }

    private void OnDestroy()
    {
        _resumeButton.onClick.RemoveAllListeners();
    }

    private void Update()
    {
        if (!RectTransformUtility.RectangleContainsScreenPoint(_rectTransform, Input.mousePosition))
        {
            _colorPreview.color = _selectedColor;
            return;
        }

        RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTransform, 
            Input.mousePosition, null, out var localPoint);

        var rect = _rectTransform.rect;
        var rectWidth = rect.width;
        var rectHeight = rect.height;

        localPoint += new Vector2(rectWidth * 0.5f, rectHeight * 0.5f);
        var x = Mathf.Clamp01(localPoint.x / rectWidth);
        var y = Mathf.Clamp01(localPoint.y / rectHeight);
        
        var textureX = Mathf.RoundToInt(x * _texture2D.width);
        var textureY = Mathf.RoundToInt(y * _texture2D.height);

        _selectedColor = _texture2D.GetPixel(textureX, textureY);

        _onColorPreviewEvent?.Invoke(_selectedColor);

        if (Input.GetMouseButtonDown(0))
        {
            _onColorSelectedEvent?.Invoke(_selectedColor);
            SaveColor(_selectedColor);
        }
    }

    public void SwitchPanel()
    {
        _windowState = !_windowState;
        gameObject.SetActive(_windowState);
    }

    private void SaveColor(Color color)
    {
        var stringColor = ColorUtility.ToHtmlStringRGB(color);
        PlayerPrefs.SetString("BallColor", stringColor);
        PlayerPrefs.Save();
    }
}
