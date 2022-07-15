using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ShipOnTriggerEnterActions : MonoBehaviour
{
    [SerializeField] private List<GameObject> _lives;

    private const int _gameScene = 0;

    private int _livesCounter = 2;

    private ObjectSpawner _objectSpawner;

    private Renderer _myRenderer;
    private Collider _myCollider;

    private void OnDisabled()
    {
        StopAllCoroutines();
    }

    private void Start()
    {
        _objectSpawner = ObjectSpawner.Instance;
        _myRenderer = gameObject.GetComponent<Renderer>();
        _myCollider = gameObject.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.CompareTag("Bound")) { return; }

        if (hitInfo.CompareTag("SmallAsteroid"))
        {
            _objectSpawner.SmallAsteroidsCounter--;
        }

        TakeDamage();
    }

    private void SetDefaultPosition()
    {
        transform.position = Vector3.zero;
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    private void Die()
    {
        SceneManager.LoadScene(_gameScene);
        ObjectSpawner.ClearDictionary();
    }

    private void TakeDamage()
    {
        _lives[_livesCounter].SetActive(false);

        if (_livesCounter == 0)
        {
            Die();
        }
        
        SetDefaultPosition();
        ShipMovementKeyboard.SetForceToZero();
        ShipMovementMouse.SetForceToZero();
        StartCoroutine(Flicker());
    }

    private IEnumerator Flicker()
    {
        _myCollider.enabled = !_myCollider.enabled;
        _livesCounter--;

        for (int i = 0; i < 6; i++)
        {
            _myRenderer.material.color = new Color(255, 255, 255, 0);
            yield return new WaitForSeconds(0.25f);
            _myRenderer.material.color = new Color(255, 255, 255, 255);
            yield return new WaitForSeconds(0.25f);
        }
        _myCollider.enabled = !_myCollider.enabled;
    }
}
