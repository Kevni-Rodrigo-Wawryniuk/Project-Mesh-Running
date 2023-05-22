using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Sprites;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainPlayer : MonoBehaviour
{
    [SerializeField] public static MainPlayer mainPlayer;

    [Header("Player Components")]
    [SerializeField] Rigidbody2D rgbMP;
    [SerializeField] BoxCollider2D bcMP;
    [SerializeField] Animator animMP;
    [SerializeField] SpriteRenderer spRMP;

    [Header("Value Moviment")]
    [SerializeField] public bool moviment;
    // Saltos
    [SerializeField] RaycastHit2D rayOnGround;
    [SerializeField] LayerMask LayerMaskGround;
    [SerializeField] float jumpForce;
    [SerializeField] int amountJumps;

    [Header("Points")]
    [SerializeField] public int Points;

    // Start is called before the first frame update
    void Start()
    {
        // Esto permite el uso del programa en otros y permite que se modifiquen los valores de este y otros programas
        if (mainPlayer == null)
        {
            mainPlayer = this;
        }

        // En esta funcion se encuentran los componentes y demas funciones que requieren de 1 ejecucion al iniciar el programa
        StartProgram();
    }

    // Update is called once per frame
    void Update()
    {
        MovimentsAndJump();
        Pause();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Points"))
        {
            Points++;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            animMP.SetTrigger("Dead");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(0.35f,0.4f,0));
    }

    // Esto es para las funciones de inicio del programa no requiere que se vuelvan a cargar
    public void StartProgram()
    {
        // Estos son los componentes del jugador
        // Lo que maneja las fisicas, coliciones, animaciones, etc;
        rgbMP = GetComponent<Rigidbody2D>();
        bcMP = GetComponent<BoxCollider2D>();
        animMP = GetComponent<Animator>();
        spRMP = GetComponent<SpriteRenderer>();

        // Esto es para que cuando el programa se inicie el valor de los puntos sea 0
        Points = 0;
    }

    // Esta funcion es para los movimientos y los saltos del personaje
    public void MovimentsAndJump()
    {
        if (moviment == true)
        {
            // Esto es para que la cantidad de saltos vuelva a ser la inicial
            if (IsOnTheGround())
            {
                amountJumps = 0;
            }
            
            //saltos del personaje y cantidad de saltos que pueda dar
            if (Input.GetKeyDown(KeyCode.Space) && amountJumps < 2)
            {
                rgbMP.AddForce(new Vector2(rgbMP.velocity.x, jumpForce));
                amountJumps++;
                animMP.SetBool("Jumping", true);
            }
            
            // Esto es para detener la animacion de salto
            if (amountJumps == 0)
            {
                animMP.SetBool("Jumping", false);
            }
        }
    }    
    public bool IsOnTheGround()
    {
        rayOnGround = Physics2D.BoxCast(transform.position, new Vector3(0.35f,0.4f, 0), 0f , Vector2.down, 0f, LayerMaskGround);

        return rayOnGround.collider != null;
    }

    // Esto es para pausar el juego
    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.gameManager.PausePlay();
        }
    }

    // Esto es para la animacion de muerte
    public void IsDead()
    {
        GameManager.gameManager.playGame = false;

        if (Points > GameManager.gameManager.actualityPoints)
        {
           PlayerPrefs.SetInt("puntos", Points);
        }

        Time.timeScale = 0;

        Destroy(this.gameObject);
    }

}
