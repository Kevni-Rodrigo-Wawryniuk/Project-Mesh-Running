using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CameraMainPlayer : MonoBehaviour
{
    [SerializeField] public static CameraMainPlayer cameraMainPlayer;

    [Header("Follow A Player")]
    [SerializeField] GameObject player;
    [SerializeField] Vector3 offSet;
    [SerializeField] float smoothness;

    // Start is called before the first frame update
    void Start()
    {
      if (cameraMainPlayer == null)
        {
            cameraMainPlayer = this;
        }

        StarTheProgram();
    }

    // Update is called once per frame
    void Update()
    {
        // Primera forma de seguir al jugador esta es muy presisa
        //  FollowPresisPlayer();

        // Segunda forma de seguir al jugador con esta se le puede dar unn movimiento mas suave a la camara
        FollowSmoothnessPlayer();
    }

    // Esta funcion se encarga de las funciones iniciales
    public void StarTheProgram()
    {
        offSet = this.transform.position - offSet;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Esta funcion es para segur al jugador de manera presisa
    public void FollowPresisPlayer()
    {
        transform.position = player.transform.position + offSet;
    }

    // Esta funcion es para seguir al jugador de manera mas suave
    public void  FollowSmoothnessPlayer()
    {
        if (GameManager.gameManager.playGame == true)
        {
            Vector3 posicion0 = player.transform.position + offSet;

            transform.position = Vector3.Lerp(transform.position, posicion0, smoothness * Time.deltaTime);
        }
    }
}
