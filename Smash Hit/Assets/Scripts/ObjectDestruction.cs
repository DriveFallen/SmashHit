using UnityEngine;
using UnityEngine.Events;

public class ObjectDestruction : MonoBehaviour
{
    public UnityEvent OnDestruction;

    [SerializeField] private int bonusBalls = 0;
    [SerializeField] private GameObject[] fragments;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            if(bonusBalls > 0)
            {
                GameManager.TakeBalls(bonusBalls);
            }

            if (fragments != null)
            {
                for (int i = 0; i < fragments.Length; i++)
                {
                    fragments[i].SetActive(true);
                    fragments[i].GetComponent<MeshRenderer>().enabled = true;

                    if (fragments[i].GetComponent<Rigidbody>())
                    {
                        fragments[i].GetComponent<Rigidbody>().useGravity = true;
                        fragments[i].GetComponent<Rigidbody>().isKinematic = false;
                    }
                }
            }

            OnDestruction.Invoke();
            gameObject.SetActive(false);
        }
    }
}
