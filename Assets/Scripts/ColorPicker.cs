using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    [SerializeField] private Image _colorPreview;
    [SerializeField] private ColorEvent _onColorPreviewEvent;
    [SerializeField] private ColorEvent _onColorSelectedEvent;
    
    private RectTransform _rectTransform;
    private Texture2D _texture2D;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _texture2D = GetComponent<Image>().mainTexture as Texture2D;
    }

    private void Update()
    {
        if (!RectTransformUtility.RectangleContainsScreenPoint(_rectTransform, Input.mousePosition))
        {
            _colorPreview.color = Color.white;
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

        var newColor = _texture2D.GetPixel(textureX, textureY);

        _onColorPreviewEvent?.Invoke(newColor);

        if (Input.GetMouseButtonDown(0))
        {
            _onColorSelectedEvent?.Invoke(newColor);
        }
    }
}
