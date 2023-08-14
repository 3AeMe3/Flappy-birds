using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRepet : MonoBehaviour
{
    //Variable para almacenar el ancho del sprite (se utiliza para determinar 
    //cuando repetir la imagen)
    float spriteWidth;
    
    void Start()
    {
        //Obtiene el componente BoxCollider2D adjunto al objeto
        BoxCollider2D groundCollider = GetComponent<BoxCollider2D>();

        //Calcula el ancho del sprite utilizando el tamaño del boxCollider2D
        spriteWidth = groundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Verifica si la posicion en el eje X del objeto es menor que el ancho del prite 
        //en valor negativo
        if(transform.position.x < -spriteWidth)
        {
            //Si se cumple la condicion, repetir la imagen moviendo el objeto hacia
            //la derecha(eje X)
            ResetPosition();
        }
    }

    /// <summary>
    /// Reinicia la posicion del objeto y repite la imagen
    /// </summary>
    void ResetPosition()
    {
        //Mueve el objeto hacia la derecha (eje X) para repetir la imagen
        //Se multiplica el ancho del sprite por 2 para asegurarse de que el objeto se coloque
        //justo despues del anterior
        transform.Translate(new Vector2(spriteWidth * 2 ,0));
    }
}
