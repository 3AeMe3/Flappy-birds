using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    //Velocidad a la que se mover el objeto 
    [SerializeField] float speed;

    Rigidbody2D rb;
    void Start()
    {
        //Obtengo el componente Rigidbody2D adjunt al objeto
        rb = GetComponent<Rigidbody2D>();

        //Configura la velocidad inicial del objeto , moviendolo hacia la
        //izquierda(eje X) con la velocidad especificada
        rb.velocity = Vector2.left * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //Verifica si el juego ha terminado(segun el estado del GameManager)
        if (GameManager.Instance.isGameOver)
        {
            //si el juego ha terminado , detener el moviemiento del objeto
            //estableciendo su velocidad a cero
            rb.velocity = Vector2.zero;
        }
    }
}
