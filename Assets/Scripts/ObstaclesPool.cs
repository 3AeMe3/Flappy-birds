using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPool : MonoBehaviour
{
    //Referencia a los objetos que ser�n utilizados para crear obst�culos
    [SerializeField] GameObject obstaclesPrefab;
    //tama�o del pool de obst�culos
    [SerializeField] int poolSize = 5;
    //Timpo entre cada spawn de obst�culos
    [SerializeField] float spawnTime = 2.5f;
    //Posici�n en el eje X donde se generar�n los obst�culos
    [SerializeField]float xSpawnPosition = 12f;
    //Posiciones m�nima y m�xima en el eje Y donde se generar�n los obst�culos de forma aleatoria
    [SerializeField]float minYPosition = -2f,maxYPosition = 3f;


    //Variables para el control del tiempo y el contador de obstaculos
    float timeElapsed;
    int obstacleCount;

    //Array para almacenar los obstaculos creados y reutilizarlos
    [SerializeField] GameObject[] obstacles;


    void Start()
    {
        //Inicializador el array de obstaculos con el tama�o del pool
        obstacles = new GameObject[poolSize];

        //Instanciar los obst�culos y desactivarlos para que no sean visibles o interactivos
        for(int i = 0; i < poolSize; i++)
        {
            obstacles[i] = Instantiate(obstaclesPrefab);
            obstacles[i].SetActive(false); 
        }
    }

    void Update()
    {
        //Actualizar el tiempo transcurrido
        timeElapsed += Time.deltaTime;
        //Verifica si es tiempo de generar un nuevo obstaculo y que el juego no haya terminado
        if (timeElapsed > spawnTime && !GameManager.Instance.isGameOver) 
        {
            //Generar un nuevo obst�culo
            SpawnObstacle();
        }
    }
    /// <summary>
    /// Metodo para generar un nuevo obstaculo
    /// </summary>
    void SpawnObstacle()
    {
        //reiniciar el tiempo transcurrido
        timeElapsed = 0;

        //Generar una posici�n aleatoria en el eje Y para el nuevo obstaculo
        float ySpawnPosition = Random.Range(minYPosition, maxYPosition);

        //Vector2 con la posicion de spawn ( fija en el eje X y aleatoria en el eje Y)
        Vector2 spawnPosition = new Vector2(xSpawnPosition, ySpawnPosition);

        //Establece la posicion del obstaculo en el arreglo en funcion de la variable obstacleCount
        obstacles[obstacleCount].transform.position = spawnPosition;

        //Verifivar si el obst�culo en la posici�n actual esta desactivado (no visibe o interactivo)
        if (!obstacles[obstacleCount].activeSelf)
        {
            //Activa el obst�culo
            obstacles[obstacleCount].SetActive(true);
        }

        //Incrementar el contador de obst�culo
        obstacleCount++;

        //verificar si el contador ha alcanzado el tama�o del pool y si es as�,reiniciarlo
        //para reutilizar los obst�culos
        if(obstacleCount == poolSize)
        {
            obstacleCount = 0;
        }
    }
}
