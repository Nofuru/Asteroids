using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipBulletPooler : ObjectPooler
{
    public bool isKeyBoardOnly = false;

    public Transform trans;

    [SerializeField] private float _rateOfFire = 0.3f;

    public void SetKeyBoardOnly()
    {
        isKeyBoardOnly = true;
    }

    public void SetKeyBoardAndMouse()
    {
        isKeyBoardOnly = false;
    }

    private void OnEnable()
    {
        StartCoroutine(ShootWithDelay());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator ShootWithDelay()
    {
        for (; ; )
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && isKeyBoardOnly == false)
            {
                SpawnFromPool(4, trans.transform.position, trans.transform.up, poolDictionary);
                yield return new WaitForSeconds(_rateOfFire);
            }
            else if(Input.GetKeyDown(KeyCode.Space))
            {
                SpawnFromPool(4, trans.transform.position, trans.transform.up, poolDictionary);
                yield return new WaitForSeconds(_rateOfFire);
            }
            yield return null;
        }
    }
}


