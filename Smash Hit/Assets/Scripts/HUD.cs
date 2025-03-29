using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Text ballCount;

    private void FixedUpdate()
    {
        ballCount.text = $"Ball count:{GameManager.BallCount}";
    }
}
