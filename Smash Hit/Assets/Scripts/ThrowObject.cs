using UnityEngine;
using UnityEngine.Events;

public class ThrowObject : MonoBehaviour
{
    public UnityEvent OnThrow;
    public UnityEvent OnEmpty;

    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float throwForce = 30f;

    private Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1") && ballPrefab != null)
        {
            Throw(throwForce);
        }
    }

    public void Throw(float force = 10f)
    {
        if (GameManager.BallCount <= 0)
        {
            OnEmpty.Invoke();
            return;
        }

        // Переводим координаты мыши в мировые координаты
        Ray mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 mousePosition = mouseRay.GetPoint(1f);

        // Рассчитываем направление для броска
        Vector3 throwDirection = (mousePosition - transform.position).normalized;

        // Создаем копию объекта, который бросим      
        GameObject newBall = Instantiate(ballPrefab);
        newBall.transform.position = transform.position;

        // Проверяем наличие физики на объекте
        if (newBall.GetComponent<Rigidbody>() != null)
        {
            // Бросаем шар
            Rigidbody rb = newBall.GetComponent<Rigidbody>();
            rb.AddForce(throwDirection * force, ForceMode.VelocityChange);
        }

        GameManager.BallCount--;
        OnThrow.Invoke();
    }

    public void ThrowAway(int number = 10, float force = 10f)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject newBall = Instantiate(ballPrefab);
            newBall.transform.position = transform.position;

            if (newBall.GetComponent<Rigidbody>() != null)
            {
                Rigidbody rb = newBall.GetComponent<Rigidbody>();
                rb.AddForce(Vector3.forward * force, ForceMode.VelocityChange);
            }
        }
    }
}
