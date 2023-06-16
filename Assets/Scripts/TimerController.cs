using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private Slider _timerSlider;
    [SerializeField] private Image _sliderImage;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _endColor;

    private float _currentTime = 120;
    public bool _startCountdown = false;

    void Update()
    {
        if (_startCountdown)
        {
            _currentTime -= Time.deltaTime;
            //If currentTime < 30, change to show seconds
            _timerText.text = _currentTime < 30 ? _currentTime.ToString("0.0") : _currentTime.ToString("0");
            _timerText.color = Color.Lerp(_startColor, _endColor, 1 - (_currentTime / 120));
            _sliderImage.color = Color.Lerp(_startColor, _endColor, 1 - (_currentTime / 120));
            _timerSlider.value = _currentTime / 120;
            if (_currentTime <= 0)
            {
                _startCountdown = false;
                _timerText.color = _endColor;
                _timerSlider.value = 0;
                _gameManager.EndGame();
            }
        }
    }
}
