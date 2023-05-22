using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScenery : MonoBehaviour
{
    [SerializeField] public static LoadingScenery loadingScenery;

    [SerializeField] Slider loadBar;
    [SerializeField] public string scene;
    [SerializeField] public int escena;

    [SerializeField] Image rotatorCircle;
    [SerializeField] Image circlePassNextScreen;

    // Start is called before the first frame update
    void Start()
    {
        if (loadingScenery == null)
        {
            loadingScenery = this;
        }

       escena = PlayerPrefs.GetInt("Escena", 0);

        if (escena == 2)
        {
            scene = "GameScreen";
        }
        else if (escena == 0)
        {
            scene = "HomeScreen";
        }


        StartCoroutine(Loadscenery(scene));

        circlePassNextScreen.color = Color.black;
    }

     void FixedUpdate()
    {
        rotatorCircle.rectTransform.Rotate(new Vector3(0, 0, 100) * Time.deltaTime);        
    }

    IEnumerator Loadscenery(string name)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        operation.allowSceneActivation = false;

        while(!operation.isDone)
        {
            loadBar.value = operation.progress;

            if (operation.progress >= 0.9f)
            {
                circlePassNextScreen.color = Color.red;

                if (Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    operation.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
}
