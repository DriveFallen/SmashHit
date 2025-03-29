using UnityEngine;
using UnityEngine.Events;

public class ActivatorsConnection : MonoBehaviour
{
    public UnityEvent OnActivatorsContact;

    [SerializeField] private Activator[] activators;

    private void Awake()
    {
        for (int i = 0; i < activators.Length; i++)
        {
            activators[i].OnActivate.AddListener(CheckContact);
        }
    }

    public void CheckContact()
    {
        for (int i = 0; i < activators.Length; i++)
        {
            if (activators[i].gameObject.activeSelf == true && activators[i].Activated == false)
            {
                return;
            }
        }

        OnActivatorsContact.Invoke();
    }
}