using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomPatrol11 : MonoBehaviour
{

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    Vector3 targetPosition = new Vector3();

    public float minSpeed;
    public float maxSpeed;

    float speed;

    public float secondsToMaxDifficulty;

    // Start is called before the first frame update
    void Start()
    {

        targetPosition = GetRandomPosition();

    }

    // Update is called once per frame
    void Update()
    {

        if ((Vector3)transform.position != targetPosition)
        {
            speed = Mathf.Lerp(minSpeed, maxSpeed, GetDifficultyPercent());

//            print(transform.position);
//            print(speed);
//            print(targetPosition);





            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        } else {
            targetPosition = GetRandomPosition();
        }

        
    }

    Vector2 GetRandomPosition() {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector3(randomX, randomY);
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "Planets")
        {
//          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Timer.stopTime = true;
            SceneManager.LoadScene(6);


        }

    }

    float GetDifficultyPercent() {
        print (Time.timeSinceLevelLoad);
        print (secondsToMaxDifficulty);
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);

    }

}
