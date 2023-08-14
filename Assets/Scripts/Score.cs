using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    /// <summary>
    /// Se ejecuta cuando el objeto con este script entra en colision con 
    /// otro objeto 
    /// </summary>
    private void OnTriggerEnter2D()
    { 
        //Aumenta la puntuacion utilizando el metodo "IncreaseScore" del GameManager
          GameManager.Instance.IncreaseScore();
    }
}
