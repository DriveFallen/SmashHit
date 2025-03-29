using UnityEngine;

public class Ball : MonoBehaviour
{
    private float timeToDestroy = 5f;

    private void FixedUpdate()
    {
        timeToDestroy -= Time.fixedDeltaTime;
        if (timeToDestroy <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ConnectedGlass"))
        {
            other.transform.parent = other.transform.root;

            if (other.gameObject.GetComponent<Rigidbody>() == null)
            {
                other.gameObject.AddComponent<Rigidbody>();
            }
        }
    }
}
