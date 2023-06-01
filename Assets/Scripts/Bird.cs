using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool isFlying = false; // Флаг, указывающий, летит ли голубь в данный момент
    private float flyForce; // Сила разлета голубя
    public float flySpeed = 5f; // Скорость разлета голубя

    public void FlyUpward(float force)
    {
        if (!isFlying)
        {
            isFlying = true;
            flyForce = force;

            // Запускаем корутину для разлета голубя
            StartCoroutine(FlyRoutine());
        }
    }

    private System.Collections.IEnumerator FlyRoutine()
    {
        // Вычисляем случайное направление вектора для разлета голубя
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(0.5f, 1f), 0f).normalized;

        while (transform.position.y < 10f) // Меняйте значение 10f на необходимую высоту, на которой голуби должны разлетаться
        {
            // Изменяем позицию голубя на основе случайного направления, силы и скорости
            transform.position += randomDirection * flyForce * flySpeed * Time.deltaTime;

            yield return null;
        }

        isFlying = false; // Голубь перестал лететь
    }
}
