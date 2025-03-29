using UnityEngine;

public class InterfaceSwitch : MonoBehaviour
{
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject EndingWindow;

    private void Awake()
    {
        HUD.SetActive(true);
        EndingWindow.SetActive(false);

        GameManager.OnLoss.AddListener(Ending);
    }

    public void Ending()
    {
        HUD.SetActive(false);
        EndingWindow.SetActive(true);
    }
}
