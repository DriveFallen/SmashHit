using UnityEngine;
using UnityEngine.Events;

public class Pause : MonoBehaviour
{
    public UnityEvent OnPauseEnable;
    public UnityEvent OnPauseDisable;

    public static bool IsActive;

    private void Awake()
    {
        PauseOFF();
    }

#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_STANDALONE_OSX

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (!IsActive)
        {
            PauseON();
        }
        else if (IsActive)
        {
            PauseOFF();
        }
    }

#endif

    public void PauseON()
    {
        Time.timeScale = 0;
        IsActive = true;
        OnPauseEnable.Invoke();
    }

    public void PauseOFF()
    {
        Time.timeScale = 1;
        IsActive = false;
        OnPauseDisable.Invoke();
    }
}
