using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField] private Image fillbarProgress;
    private float lastvalue;

    private void Update()
    {
        if (!GameManager.singleton.GameStarted)
            return;
        float TravelledDistance = GameManager.singleton.enitreDistance - GameManager.singleton.distnaceleft;
        float value = TravelledDistance / GameManager.singleton.enitreDistance;
        if (GameManager.singleton.gameObject && value < lastvalue)
            return;

            fillbarProgress.fillAmount = Mathf.Lerp(fillbarProgress.fillAmount, value, 5 * Time.deltaTime);
        lastvalue = value;
    }
}
