using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private bool _isGamePaused = true;
    [SerializeField] private GameObject _pauseMenuUI;

    public void Pause()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _isGamePaused = true;
        StopMoving();
    }

    public void Resume()
    {
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _isGamePaused = false;
    }

    private void StopMoving()
    {
        ShipMovementKeyboard.SetForceToZero();
        ShipMovementMouse.SetForceToZero();
    }

    private void OnDisabled()
    {
        StopAllCoroutines();
    }

    private void Start()
    {
        StartCoroutine(EscapeTracker());
    }

    private IEnumerator EscapeTracker()
    {
        for (; ; )
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_isGamePaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
            yield return null;
        }
    }
}
