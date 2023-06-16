using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdTrigger : MonoBehaviour
{
    public float birdForce = 5f; // Сила, с которой голуби разлетаются
    public GameObject[] birds; // Массив объектов голубей

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character")) // Проверяем, если объект, соприкасающийся с триггером, имеет тег "Character"
        {
            if (SceneManager.GetActiveScene().buildIndex == 16) 
            {
                ProgressManager.Instance.setStateQuest(3, 1, Quest.state.Completed);
            }

            foreach (GameObject bird in birds)
            {
                Bird birdScript = bird.GetComponent<Bird>(); // Получаем компонент Bird из объекта голубя
                if (birdScript != null)
                {
                    birdScript.FlyUpward(birdForce); // Вызываем метод FlyUpward для каждого голубя с передачей силы разлета
                    bird.GetComponent<Animator>().SetBool("birdFly", true);
                }
            }
        }
    }
}
