using UnityEngine;
using TMPro;
using System.Linq;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _fpsCounterText;
    private int _lastFrameIndex;
    private float[] _deltaTimeArray = new float[60];

    private void Update()
    {
        UpdateDeltaTimeArray();
        UpdateText();
    }

    private void UpdateDeltaTimeArray()
    {
        _deltaTimeArray[_lastFrameIndex] = Time.unscaledDeltaTime;
        _lastFrameIndex = (_lastFrameIndex + 1) % _deltaTimeArray.Length;
    }

    private float CalculateAverageFPS() => _deltaTimeArray.Length / _deltaTimeArray.Sum();
    private void UpdateText() => _fpsCounterText.text = $"FPS: {Mathf.RoundToInt(CalculateAverageFPS())}";
}