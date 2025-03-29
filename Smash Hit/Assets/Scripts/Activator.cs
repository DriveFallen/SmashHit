using UnityEngine;
using UnityEngine.Events;

public class Activator : MonoBehaviour
{
    public UnityEvent OnActivate;

    public bool Activated = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            Activated = true;

            OnActivate.Invoke();
        }
    }
}
