using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPool : MonoBehaviour
{
    //Referencia a los objetos que serán utilizados para crear obstáculos
    [SerializeField] GameObject obstaclesPrefab;
    //tamaño del pool de obstáculos
    [SerializeField] int poolSize = 5;
    //Timpo entre cada spawn de obstáculos
    [SerializeField] float spawnTime = 2.5f;
    //Posición en el eje X donde se generarán los obstáculos
    [SerializeField]float xSpawnPosition = 12f;
    //Posiciones mínima y máxima en el eje Y donde se generarán los obstáculos de forma aleatoria
    [SerializeField]float minYPosition = -2f,maxYPosition = 3f;


    //Variables para el control del tiempo y el contador de obstaculos
    float timeElapsed;
    int obstacleCount;

    //Array para almacenar los obstaculos creados y reutilizarlos
    [SerializeField] GameObject[] obstacles;


    void Start()
    {
        //Inicializador el array de obstaculos con el tamaño del pool
        obstacles = new GameObject[poolSize];

        //Instanciar los obstáculos y desactivarlos para que no sean visibles o interactivos
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
            //Generar un nuevo obstáculo
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

        //Generar una posición aleatoria en el eje Y para el nuevo obstaculo
        float ySpawnPosition = Random.Range(minYPosition, maxYPosition);

        //Vector2 con la posicion de spawn ( fija en el eje X y aleatoria en el eje Y)
        Vector2 spawnPosition = new Vector2(xSpawnPosition, ySpawnPosition);

        //Establece la posicion del obstaculo en el arreglo en funcion de la variable obstacleCount
        obstacles[obstacleCount].transform.position = spawnPosition;

        //Verifivar si el obstáculo en la posición actual esta desactivado (no visibe o interactivo)
        if (!obstacles[obstacleCount].activeSelf)
        {
            //Activa el obstáculo
            obstacles[obstacleCount].SetActive(true);
        }

        //Incrementar el contador de obstáculo
        obstacleCount++;

        //verificar si el contador ha alcanzado el tamaño del pool y si es así,reiniciarlo
        //para reutilizar los obstáculos
        if(obstacleCount == poolSize)
        {
            obstacleCount = 0;
        }
    }
}
