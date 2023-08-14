using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator PlayerAnimator;
    Rigidbody2D rb;

  
    [SerializeField] 
    float jumpForce = 200f; //fuerza aplicada en el salto
    bool isDead;
    
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();  
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //si presionamos el click izquierdo del mouse y no estamos muertos ..
        if (Input.GetMouseButtonDown(0) && !isDead) 
        {
            Flap();
        }
    }

    void Flap()
    {
        rb.velocity = Vector2.zero; //reseteamos la velocidad al cero
        rb.AddForce(Vector2.up * jumpForce); //fuerza de salto multiplicada con el vector 2.up (0,1)
        PlayerAnimator.SetTrigger("Flap"); //Activar animacion de vuelo o aleateo
    }

    private void OnCollisionEnter2D()
    {
        isDead = true;
        PlayerAnimator.SetTrigger("Die"); //activar animacion de muerte
        GameManager.Instance.GameOver();
    }
}
