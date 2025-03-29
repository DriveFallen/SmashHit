using UnityEngine;
using UnityEngine.Events;

public class TakingDamage : MonoBehaviour
{
    public UnityEvent OnDamage;

    [SerializeField] private int damage = 10;
    [SerializeField] private string[] dangerousTags;

    private ThrowObject throwObj;

    private void Awake()
    {
        throwObj = GameObject.FindObjectOfType<ThrowObject>();
    }


    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < dangerousTags.Length; i++)
        {
            if (other.CompareTag(dangerousTags[i]))
            {
                GameManager.TakeDamage(damage);

                throwObj.ThrowAway(damage);

                OnDamage.Invoke();
            }
        }
    }
}
