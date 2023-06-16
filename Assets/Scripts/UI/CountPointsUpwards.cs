using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountPointsUpwards : MonoBehaviour
{
    [SerializeField] private PointsController _pointsController;
    [SerializeField] private TextMeshProUGUI _pointsShowText;
    [SerializeField] private float _waitTime;

    private float _countUpwardsLerp = 0;

    private void Start()
    {
        StartCoroutine(CountText());
    }


    private IEnumerator CountText()
    {
        while(_countUpwardsLerp < _waitTime)
        {
            _countUpwardsLerp += Time.deltaTime;
            _pointsShowText.text = Mathf.Lerp(0, _pointsController.totalPoints, _countUpwardsLerp/ _waitTime).ToString("00000");
            yield return null;
        }
        yield return null;
    }
}
