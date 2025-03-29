using UnityEngine;

public class RandomActivation : MonoBehaviour
{
    [SerializeField] private int percent = 50;

    private void Awake()
    {
        int rnd = Random.Range(0, 100);

        if (rnd < percent)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
