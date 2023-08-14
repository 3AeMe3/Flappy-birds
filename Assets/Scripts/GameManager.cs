
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject gameOverText;
    [SerializeField] TextMeshProUGUI scoreText;
    
    //Variable para almacenar la instancia única del GameManager
    static GameManager instance;

    //Variable para controlar si el juego ha terminado
    public bool isGameOver;

    //Variable para almacenar la puntuación actual del jugador
    int score;

    //Porpiedad para acceder a la instancia única del GameManager desde otras clases
    public static GameManager Instance { get { return instance; } }

    //Awake se llama cuando se instancia el objeto antes de start 
    void Awake()
    {
        //Verificar si ya existe una instancia del GameManager
        if(instance == null)
        {
            //Si no existe, Asignar la instancia actual como la instancia única
            instance = this;
        }
        else
        {
            // si ya existe una instancia, destruir la nueva instancia para mantener solo una
            Destroy(gameObject);
        }
    }

    void Update()
    {
        //Verificar si se ha presionado el boton izquierdo del mouse y el juego ha terminado
        if(Input.GetMouseButtonDown(0) && isGameOver)
        {
            //Reinica el juego al presionar el boton izquierdo del mouse
            RestartGame();
        }
      
    }
    /// <summary>
    /// Indica que el juego ha terminado
    /// </summary>
    public void GameOver()
    {
        //Marcar el juego como terminado
        isGameOver=true;

        //Mostrar el texto de GameOver en la escena
        gameOverText.SetActive(true);
    }

    /// <summary>
    /// Reinica el juego
    /// </summary>
    void RestartGame()
    {
        //Carga nuevamente la escena principal ( escena con el indice 0 en el buildSetting)
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Metodo para aumentar la puntuacion del jugador
    /// </summary>
    public void IncreaseScore()
    {
        //Incrementa la puntuacion en 1
        score++;
       
        //Actualiza el texto de puntuación en la interfaz de usuario
        scoreText.text =  score.ToString();
    }
}
