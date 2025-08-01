using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public IEnumerator CountdownCoroutine(float duration, TextMeshProUGUI timerText)
    {
        timerText.gameObject.SetActive(true);
        float timer = duration;

        while (timer > 0 )
        {
            timerText.text = timer.ToString("0");
            yield return new WaitForSeconds(1f);
            timer--;
        }

        timerText.text = "0";
        yield return new WaitForSeconds(0.5f);
        timerText.gameObject.SetActive(false);
    }
}
