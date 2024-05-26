using UnityEngine;

public class BalanceController : MonoBehaviour ,IBallTriger
{
    [SerializeField] Transform balanceTransform;
    [SerializeField] float maxRotationSpeed = 1f; // d�nme h�z�
    [SerializeField] float maxRotationAngle = 60f; // d�n�� a��s� s�n�r�

  

    private float currentRotationAngle = 0f;

    void Update()
    {
        Rotate();
    }


    void Rotate()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        float rotationAmount = direction * maxRotationSpeed * Time.deltaTime;

        // Hedef d�n�� a��s�n� hesapla ve s�n�rland�r
        float targetRotationAngle = currentRotationAngle + rotationAmount;
        targetRotationAngle = Mathf.Clamp(targetRotationAngle, -maxRotationAngle, maxRotationAngle);

        // Yeni d�n�� a��s�n� ayarla
        balanceTransform.localRotation = Quaternion.Euler(0f, 0f, -targetRotationAngle);

        // G�ncel d�n�� a��s�n� sakla
        currentRotationAngle = targetRotationAngle;
    }

}
