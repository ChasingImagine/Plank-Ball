using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class MovePathManuel : MonoBehaviour
{

    [SerializeField] SpriteShapeController spriteShapeController;
    [SerializeField] float moveSpeed = 5f;

    private int currentIndex = 0;
    private bool movingForward = true;

    void Start()
    {
        // Ba�lang��ta nesneyi ilk noktaya yerle�tir
        transform.position = spriteShapeController.spline.GetPosition(currentIndex) + spriteShapeController.transform.position;
    }

    void Update()
    {
        MoveAlongSpline();
    }

    void MoveAlongSpline()
    {
        float y = Input.GetAxisRaw("Vertical");

        if (y < 0)
        {
            if (movingForward)
            {
                currentIndex--;
                movingForward = false;
            }
        }
        else if (y > 0)
        {
            if (!movingForward)
            {
                currentIndex++;
                movingForward = true;
            }
        }
        else
        {
            return;
        }

        if (currentIndex >= spriteShapeController.spline.GetPointCount())
        {
            currentIndex = spriteShapeController.spline.GetPointCount() - 1;
        }
        else if (currentIndex < 0)
        {
            currentIndex = 0;
        }

        // Hedef noktaya do�ru hareket et
        Vector3 targetPosition = spriteShapeController.spline.GetPosition(currentIndex) + spriteShapeController.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Kontrol, ge�erli indeksin s�n�r de�erlerini a�mad���ndan emin olmal�d�r
        if (currentIndex >= spriteShapeController.spline.GetPointCount())
        {
            currentIndex = spriteShapeController.spline.GetPointCount() - 1;
        }
        else if (currentIndex < 0)
        {
            currentIndex = 0;
        }

        // Hedef noktaya ula��ld���nda, hareket y�n�n� de�i�tir
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            if (movingForward)
            {
                currentIndex++;
            }
            else
            {
                currentIndex--;
            }
        }
    }

}
