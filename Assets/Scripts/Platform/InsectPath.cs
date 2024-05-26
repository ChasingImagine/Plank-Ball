using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class InsectPath : MonoBehaviour
{

    [SerializeField] SpriteShapeController spriteShapeController;
    [SerializeField] float moveSpeed = 5f;


    private int currentIndex = 0;
    private bool movingForward = true;

    void Start()
    {
        spriteShapeController.GetComponent<SpriteShapeRenderer>().color = new Color(0, 0, 0, 0);
        // Ba�lang��ta nesneyi ilk noktaya yerle�tir
        transform.position = spriteShapeController.spline.GetPosition(currentIndex) + spriteShapeController.transform.position;
    }

    void Update()
    {
        MoveAlongSpline();
    }

    void MoveAlongSpline()
    {
        // Hedef noktaya do�ru hareket et
        Vector3 targetPosition = spriteShapeController.spline.GetPosition(currentIndex) + spriteShapeController.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        
        // Hedef noktaya ula��ld���nda, hareket y�n�n� de�i�tir
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            if (movingForward)
            {
                currentIndex++;
                if (currentIndex >= spriteShapeController.spline.GetPointCount())
                {
                    currentIndex = spriteShapeController.spline.GetPointCount() - 2;
                    movingForward = false;
                }
            }
            else
            {
                currentIndex--;
                if (currentIndex < 0)
                {
                    currentIndex = 1;
                    movingForward = true;
                }
            }
        }
    }
}
