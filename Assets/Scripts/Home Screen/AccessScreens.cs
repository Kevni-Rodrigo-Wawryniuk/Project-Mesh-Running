using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.ParticleSystemJobs;
using UnityEngine.Audio;
using TMPro;

public class AccessScreens : MonoBehaviour
{
    [SerializeField] public static AccessScreens accessScreens;

    [Header("Canvas Home Screen")]
    [SerializeField] int canvasHomeValue;
    [SerializeField] public bool homeScreen;
    [SerializeField] float speedBackground;
    [SerializeField] Canvas[] canvasHomeScreen;
    [SerializeField] GameObject[] bottonHomeScreen, botonLevelsScreen;
    [SerializeField] GameObject[] imageBackGrounds, cloudsArray, treesArray;
    [SerializeField] GameObject playerHomeScreen;
    
    [Header("Listas De Objetos")]
    [SerializeField] List<GameObject> imageBackgroundsList;
    [SerializeField] List<GameObject> cloudsList;
    [SerializeField] List<GameObject> treesList;

    [Header("Canvas Setting Screen")]
    [SerializeField] int canvasSettingValue;
    [SerializeField] public bool settingScreen;
    [SerializeField] GameObject[] bottonSettingScreen;

    [Header("Puntos Maximos")]
    [SerializeField] int point;
    [SerializeField] TextMeshProUGUI textPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (accessScreens == null)
        {
            accessScreens = this;
        }
        // Estado inicial
        StartPlayGame();
    }

    // Update is called once per frame
    void Update()
    {
        // Mover y colocar Fondo De Pantalla
        CanvasBackgrounds();
        // Controla todo lo de la pantalla inicial
        CanvasHomeScreen();
        // Controla todo lo de la pantalla de configuraciones
        CanvasSettingScreen();
    }

    // Esto es para cuando se inicia el programa
    public void StartPlayGame()
    {
        // El puntaje meximo del jugador
        point = PlayerPrefs.GetInt("puntos", 0);

        textPoint.text = "Top Score: " + point;

        // Activar Menu primcipal
        homeScreen = true;
        settingScreen = false;

        Time.timeScale = 1;
        // Instanciar Suelo
        for (int i = 0; i < 24; i++)
        {
            imageBackgroundsList.Add(Instantiate(imageBackGrounds[1], new Vector2(6 - i, -3), Quaternion.identity));
        }

        // Instanciar Suelo
        playerHomeScreen.transform.position = playerHomeScreen.transform.position = new Vector3(-6, -2.3f, 0);

        //Instanciar Nubes
        for (int i = 0; i < 4; i++)
        {
            cloudsList.Add(Instantiate(cloudsArray[0], new Vector3(Random.Range(6, 40), Random.Range(3, -1)), Quaternion.identity));
            cloudsList.Add(Instantiate(cloudsArray[1], new Vector3(Random.Range(6, 40), Random.Range(3, -1)), Quaternion.identity));
            cloudsList.Add(Instantiate(cloudsArray[2], new Vector3(Random.Range(6, 40), Random.Range(3, -1)), Quaternion.identity));
            cloudsList.Add(Instantiate(cloudsArray[3], new Vector3(Random.Range(6, 40), Random.Range(3, -1)), Quaternion.identity));
        }

        // Instanciar los arboles
        for (int i = 0; i < 5; i ++)
        {
            treesList.Add(Instantiate(treesArray[0], new Vector2(Random.Range(7, 35), -1.5f), Quaternion.identity));
            treesList.Add(Instantiate(treesArray[1], new Vector2(Random.Range(7, 35), -1.5f), Quaternion.identity));
            treesList.Add(Instantiate(treesArray[2], new Vector2(Random.Range(7, 35), -1.5f), Quaternion.identity));
            treesList.Add(Instantiate(treesArray[3], new Vector2(Random.Range(7, 35), -1.5f), Quaternion.identity));
            treesList.Add(Instantiate(treesArray[4], new Vector2(Random.Range(7, 35), -1.5f), Quaternion.identity));
        }
    }

    // Esto es para el fondo de pantalla
    public void CanvasBackgrounds()
    {

        //Enlace de los canvas
        canvasHomeScreen[0].enabled = homeScreen;
        canvasHomeScreen[1].enabled = settingScreen;
        
        //mover El fondo
        imageBackGrounds[0].GetComponent<MeshRenderer>().material.mainTextureOffset += new Vector2(speedBackground, 0) * Time.deltaTime;
        
        // Mover el suelo
        for (int i = 0; i < imageBackgroundsList.Count; i++)
        {
            if (imageBackgroundsList[i].transform.position.x <= -6)
            {
                imageBackgroundsList[i].transform.position = new Vector3(6, -3, 0);
            }

            imageBackgroundsList[i].transform.position = imageBackgroundsList[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime;
        }

        // mover las nubes
        for (int i = 0; i< cloudsList.Count; i++)
        {
           if (cloudsList[i].transform.position.x <= -6)
            {
                cloudsList[i].transform.position = new Vector3(Random.Range(6, 40), Random.Range(3, -1));
            }

           cloudsList[i].transform.position = cloudsList[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime;
        }


        //Mover Jugador por el menu 
        if (homeScreen == true)
        {
            if (playerHomeScreen.transform.position.x < -3)
            {
                playerHomeScreen.transform.position = playerHomeScreen.transform.position + new Vector3(1, 0, 0) * Time.deltaTime;
            }

            if (playerHomeScreen.transform.position.x > -3)
            {
                playerHomeScreen.transform.position = playerHomeScreen.transform.position + new Vector3(-1, 0, 0) * Time.deltaTime;
            }
        }

        if (settingScreen == true)
        {
            if (playerHomeScreen.transform.position.x < 1)
            {
                playerHomeScreen.transform.position = playerHomeScreen.transform.position + new Vector3(1, 0, 0) * Time.deltaTime;
            }

            if (playerHomeScreen.transform.position.x > 1)
            {
                playerHomeScreen.transform.position = playerHomeScreen.transform.position + new Vector3(-1, 0, 0) * Time.deltaTime;
            }
        }

        // Mover los arboles
        for (int i = 0; i < treesList.Count; i++)
        {
            if (treesList[i].transform.position.x <= -7)
            {
                treesList[i].transform.position = new Vector2(Random.Range(7, 30), -1.5f);
            }
            treesList[i].transform.position = treesList[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime;
        }
    }
    // Esto es para controlar lo que puede hacerce en el menu principal
    public void CanvasHomeScreen()
    {
        if (homeScreen == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                canvasHomeValue--;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                canvasHomeValue++;
            }

            switch(canvasHomeValue)
            {
                case 0:

                    bottonHomeScreen[0].GetComponent<Animator>().SetBool("BottonGameScreen", true);
                    bottonHomeScreen[1].GetComponent<Animator>().SetBool("BottonSettingScreen", false);
                    bottonHomeScreen[2].GetComponent<Animator>().SetBool("BottonQuitScreen", false);

                    if (Input.GetKeyDown(KeyCode.KeypadEnter))
                    {
                        LoadScene.loadScene.ThePlayGame();
                    }
                    break;
                case 1:

                    bottonHomeScreen[0].GetComponent<Animator>().SetBool("BottonGameScreen", false);
                    bottonHomeScreen[1].GetComponent<Animator>().SetBool("BottonSettingScreen", true);
                    bottonHomeScreen[2].GetComponent<Animator>().SetBool("BottonQuitScreen", false);

                    if (Input.GetKeyDown(KeyCode.KeypadEnter))
                    {
                        LoadScene.loadScene.SettingScreen();
                        canvasHomeValue = 1;
                        canvasSettingValue = 0;
                    }

                    break;
                case 2:

                    bottonHomeScreen[0].GetComponent<Animator>().SetBool("BottonGameScreen", false);
                    bottonHomeScreen[1].GetComponent<Animator>().SetBool("BottonSettingScreen", false);
                    bottonHomeScreen[2].GetComponent<Animator>().SetBool("BottonQuitScreen", true);

                    if (Input.GetKeyDown(KeyCode.KeypadEnter))
                    {
                        LoadScene.loadScene.QuitApplication();
                    }

                    break;
                default:
                    if (canvasHomeValue < 0)
                    {
                        canvasHomeValue = 2;
                    }
                    else if (canvasHomeValue > 2)
                    {
                        canvasHomeValue = 0;
                    }
                    break;
            }
        }
    }
    // Esto es para controlar lo que se puede hacer en el menu de configuraciones
    public void CanvasSettingScreen()
    {
        if (settingScreen == true)
        {
        
            if (Input.GetKeyDown(KeyCode.W))
            {
                canvasSettingValue--;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                canvasSettingValue++;
            }

            switch(canvasSettingValue)
            {
                case 0:
                    bottonSettingScreen[0].GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1);
                    bottonSettingScreen[1].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[2].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[3].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[4].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[5].GetComponent<Animator>().SetBool("BottonBack", false);

                    Sound.sound.ChangerSliderForKey();
                    break;
                case 1:
                    bottonSettingScreen[0].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[1].GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1);
                    bottonSettingScreen[2].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[3].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[4].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[5].GetComponent<Animator>().SetBool("BottonBack", false);

                    Glow.glow.ChangerGlowForKey();
                    break;
                case 2:
                    bottonSettingScreen[0].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[1].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[2].GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1);
                    bottonSettingScreen[3].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[4].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[5].GetComponent<Animator>().SetBool("BottonBack", false);

                    FullScreen.fullScreen.ChangerFullScreenForKey();
                    break;
                case 3:
                    bottonSettingScreen[0].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[1].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[2].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[3].GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1);
                    bottonSettingScreen[4].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[5].GetComponent<Animator>().SetBool("BottonBack", false);

                    Resolutions.resolutions.ChangerResolutionForTheKey();
                    break;
                case 4:
                    bottonSettingScreen[0].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[1].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[2].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[3].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[4].GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1);
                    bottonSettingScreen[5].GetComponent<Animator>().SetBool("BottonBack", false);

                    ImageQuality.imageQuality.ChangerImageQualityForKey();
                    break;
                case 5:
                    bottonSettingScreen[0].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[1].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[2].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[3].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[4].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    bottonSettingScreen[5].GetComponent<Animator>().SetBool("BottonBack", true);

                    if (Input.GetKeyDown(KeyCode.KeypadEnter))
                    {
                        LoadScene.loadScene.SettingScreen();
                        canvasSettingValue = 0;
                        canvasHomeValue = 1;
                    }
                    break;
                default:
                    if (canvasSettingValue < 0)
                    {
                        canvasSettingValue = 5;
                    }
                    else if (canvasSettingValue > 5)
                    {
                        canvasSettingValue = 0;
                    }
                    break;
            }
        }
    }
}
