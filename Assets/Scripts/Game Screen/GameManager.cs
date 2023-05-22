using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public static GameManager gameManager;
    [SerializeField] public string scene;
    
    [Header("Canvas Control")]
    [SerializeField] Canvas[] canvaControl;
    [SerializeField] public bool pause, playGame;

    [Header("Control Points")]
    [SerializeField] TextMeshProUGUI textPoint;
    [SerializeField] public int actualityPoints;
    [SerializeField] GameObject pointImage;

    [Header("Levels")]
    [SerializeField] int Levels;

    [Header("Player")]
    [SerializeField] GameObject playerManager;

    [Header("Level 1")]
    [SerializeField] MeshRenderer meshLevel1;
    [SerializeField] GameObject[] groundLevel1;
    [SerializeField] List<GameObject> groundListLevel1;
    [SerializeField] GameObject[] treeLevel1;
    [SerializeField] List<GameObject> treeListLevel1;
    [SerializeField] GameObject[] cloudLevel1;
    [SerializeField] List<GameObject> cloudListLevel1;
    [SerializeField] GameObject[] points;
    [SerializeField] List<GameObject> pointsList;
    [SerializeField] GameObject[] obstacle;
    [SerializeField] List<GameObject> obstacleList;



    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }

        pause = false;

        StartTheProgram();
    }

    // Update is called once per frame
    void Update()
    {
        canvaControl[0].enabled = !pause;
        canvaControl[1].enabled = pause;

        if (pause == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        PointsControl();

        Level1();
    }

    // Puntos Adquiridos
    public void StartTheProgram()
    {
         Levels = PlayerPrefs.GetInt("Level", 0);

        actualityPoints = PlayerPrefs.GetInt("puntos", 0);

        if (Levels == 1)
        {
            // Esto es cuando se empieaza a jugar 
            playGame = true;

            // Posiciona al jugador
            Instantiate(playerManager, new Vector3(0, 0, 0), Quaternion.identity);
            // Activa el fondo de pantalla
            meshLevel1.enabled = true;

            // posiciona las nubes
            for (int i = 0; i < 4; i++)
            {
                cloudListLevel1.Add(Instantiate(cloudLevel1[0], new Vector2(Random.Range(6, 40), Random.Range(3, -1)), Quaternion.identity));
                cloudListLevel1.Add(Instantiate(cloudLevel1[1], new Vector2(Random.Range(6, 40), Random.Range(3, -1)), Quaternion.identity));
                cloudListLevel1.Add(Instantiate(cloudLevel1[2], new Vector2(Random.Range(6, 40), Random.Range(3, -1)), Quaternion.identity));
                cloudListLevel1.Add(Instantiate(cloudLevel1[3], new Vector2(Random.Range(6, 40), Random.Range(3, -1)), Quaternion.identity));
            }

            //posiciona los arboles
            for (int i = 0; i < 5; i++)
            {
                groundListLevel1.Add(Instantiate(treeLevel1[0], new Vector2(Random.Range(7, 35), -1.5f), Quaternion.identity));
                groundListLevel1.Add(Instantiate(treeLevel1[1], new Vector2(Random.Range(7, 35), -1.5f), Quaternion.identity));
                groundListLevel1.Add(Instantiate(treeLevel1[2], new Vector2(Random.Range(7, 35), -1.5f), Quaternion.identity));
                groundListLevel1.Add(Instantiate(treeLevel1[3], new Vector2(Random.Range(7, 35), -1.5f), Quaternion.identity));
                groundListLevel1.Add(Instantiate(treeLevel1[4], new Vector2(Random.Range(7, 35), -1.5f), Quaternion.identity));
            }

            // Posicionar el Suelo
            for (int i = 0; i < 24; i++)
            {
                groundListLevel1.Add(Instantiate(groundLevel1[0], new Vector2(6 - i, -3), Quaternion.identity));
            }

            // Puntos
            for (int i = 0; i < 4; i++)
            {
                pointsList.Add(Instantiate(points[0], new Vector2(Random.Range(20, 80), Random.Range(0, -2.3f)), Quaternion.identity));
            }

            // Obstaculos
            for (int i = 0; i < 8; i++)
            {
                obstacleList.Add(Instantiate(obstacle[0], new Vector2(Random.Range(20, 80), Random.Range(0, -2.3f)), Quaternion.identity));
                obstacleList.Add(Instantiate(obstacle[1], new Vector2(Random.Range(30, 90), -2.3f), Quaternion.identity));
            }
        }
    }

    // Esto controla el texto con los puntos
    public void PointsControl()
    {
        textPoint.text = " " + MainPlayer.mainPlayer.Points;
    }
    //Pausar
    public void PausePlay()
    {
        pause = !pause;
    }
    // Level 1
    public void Level1()
    {
        if (Levels == 1 && playGame == true)
        {
            canvaControl[2].enabled = false;
            // mueve el fondo
            meshLevel1.material.mainTextureOffset = meshLevel1.material.mainTextureOffset += new Vector2(1 * Time.deltaTime, 0);

            // mover el suelo
            for(int i = 0; i < groundListLevel1.Count; i++)
            {
                if (groundListLevel1[i].transform.position.x < -7)
                {
                    groundListLevel1[i].transform.position = new Vector3(7, -3, 0);
                }
                groundListLevel1[i].transform.position = groundListLevel1[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime;
            }

            // mover los arboles
            for (int i = 0; i < treeListLevel1.Count; i++)
            {
                if(treeListLevel1[i].transform.position.x < -7)
                {
                    treeListLevel1[i].transform.position = new Vector3(Random.Range(8, 35), -2, 0);
                }

                treeListLevel1[i].transform.position = treeListLevel1[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime;
            }

            // mover las nubes
            for (int i = 0; i < cloudListLevel1.Count; i++)
            {
                if (cloudListLevel1[i].transform.position.x < -7)
                 {
                    cloudListLevel1[i].transform.position = new Vector3(Random.Range(7, 45), Random.Range(3, -1), 0);
                 }
                cloudListLevel1[i].transform.position = cloudListLevel1[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime;
            }

            // mover puntos
            for(int i = 0; i < pointsList.Count; i++)
            {
                if (pointsList[i].transform.position.x < -7)
                {
                    pointsList[i].transform.position = new Vector3(Random.Range(10, 80), Random.Range(0, -2.3f));
                }

                pointsList[i].transform.position = pointsList[i].transform.position + new Vector3(-2, 0, 0) * Time.deltaTime;
            }

            // mover obstaculos
            for (int i = 0; i < obstacleList.Count; i++)
            {
                if (obstacleList[i].transform.position.x < -7)
                {
                    obstacleList[0].transform.position = new Vector3(Random.Range(10, 80), Random.Range(0, -2.3f), 0);
                    obstacleList[1].transform.position = new Vector3(Random.Range(10, 80), 0, 0);
                }

                obstacleList[i].transform.position = obstacleList[i].transform.position + new Vector3(-2, 0, 0) * Time.deltaTime;
            }
        }

        if (playGame == false)
        {
            canvaControl[0].enabled = false;
            canvaControl[1].enabled = false;
            canvaControl[2].enabled = true;
        }
    }

    public void BackHomeScreen(string name)
    {
        SceneManager.LoadScene(name);
        PlayerPrefs.SetInt("Escena", 0);
    }

    public void RestartGame(string name)
    {
        SceneManager.LoadScene(name);
        PlayerPrefs.SetInt("Escena", 2);
        PlayerPrefs.SetInt("Level", 1);
    }

}
