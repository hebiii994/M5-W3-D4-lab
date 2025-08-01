using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [SerializeField] private TimerManager _timeManager;
    [SerializeField] private TextMeshProUGUI _countDownText;
    [SerializeField] private float _countDownTime = 3f;

    private Renderer _renderer;
    private bool _isChanging = false;
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _countDownText.gameObject.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !_isChanging)
        {
            StartCoroutine(ChangeColorAfterDelay());
        }
    }

    private IEnumerator ChangeColorAfterDelay()
    {
        _isChanging = true;
        Debug.Log("inizio conto alla rovescia");
        yield return _timeManager.CountdownCoroutine(_countDownTime, _countDownText);
        _renderer.material.color = Random.ColorHSV();
        Debug.Log($"cambiato colore in {_renderer.material.color.ToString()}");
        _isChanging = false;
    }
}
