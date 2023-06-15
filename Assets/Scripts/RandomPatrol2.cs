using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomPatrol2 : MonoBehaviour
{

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

            targetPosition = GetRandomPosition();


        } else {
            targetPosition = GetRandomPosition();
        }

        
    }

/////////////////////////////



    Vector2 GetRandomPosition() {
        GameObject objetoDesejado = GameObject.Find("Circle_2");
        Vector3 posicaoObjeto = objetoDesejado.transform.position;
        float x = posicaoObjeto.x;
        float y = posicaoObjeto.y;
//         print (objetoDesejado);
//         print (posicaoObjeto.x);
//         print (posicaoObjeto.y);

       return new Vector3(posicaoObjeto.x, posicaoObjeto.y);
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "Planets")
        {
//          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Timer.stopTime = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);

        }

    }

    float GetDifficultyPercent() {
//        print (Time.timeSinceLevelLoad);
//        print (secondsToMaxDifficulty);
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);

    }

}
