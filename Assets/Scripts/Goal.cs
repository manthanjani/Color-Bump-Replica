using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        BallFollow ball = other.GetComponent<BallFollow>();

        if (!ball || GameManager.singleton.GameEnded)
            return;
        GameManager.singleton.EndGame(true);
    }
}
