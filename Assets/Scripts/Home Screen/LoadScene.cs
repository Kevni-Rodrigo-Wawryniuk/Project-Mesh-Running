using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] public static LoadScene loadScene;

    // Start is called before the first frame update
    void Start()
    {
        if (loadScene == null)
        {
            loadScene = this;
        }

    }
    // Esto es para cargar las escenas por medio de los Botones desde el mouse
    public void LoadScenery(string name)
    {
        SceneManager.LoadScene(name);
    }
    // Esto modifica el string para que envie al jugador directo al juego
    public void ThePlayGame()
    {
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetInt("Escena", 2);
    }
    // Esto es para salir del juego
    public void QuitApplication()
    {
        Application.Quit();
        Debug.Log("Salir Del Juego");
    }
    // Esto es para cambiar la pantalla de inicio a la pantalla de configuracion
    public void SettingScreen()
    {
        AccessScreens.accessScreens.homeScreen = !AccessScreens.accessScreens.homeScreen;
        AccessScreens.accessScreens.settingScreen = !AccessScreens.accessScreens.settingScreen;
    }
}
