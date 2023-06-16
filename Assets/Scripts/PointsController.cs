using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsController : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI _pointsText;

    private int _totalPoints;
    public int totalPoints
    {
        get { return _totalPoints; }
        set
        {
            _totalPoints = value;
            if(_totalPoints < 0)
               _totalPoints = 0;
            UpdatePointsUI();
        }
    }

    private void UpdatePointsUI()
    {
        _pointsText.text = _totalPoints.ToString();
    }
}
