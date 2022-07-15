using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoOnTriggerEnterActions : MonoBehaviour
{
    [SerializeField] private int _points;

    private ScoreCounter _score;

    public void DestroyUFO(int points)
    {
        gameObject.SetActive(false);
        _score.AddPoints(_points);
    }

    private void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.CompareTag("Bound")) 
        { 
            return;
        }
        else if(hitInfo.CompareTag("ShipBullet"))
        {
            DestroyUFO(_points);
        }
        else
        {
            DestroyUFO(0);
        }
    }

    private void Start()
    {
        _score = ScoreCounter.Instance;
    }
}
