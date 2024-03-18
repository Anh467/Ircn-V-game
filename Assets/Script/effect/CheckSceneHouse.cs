using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckSceneHouse : MonoBehaviour
{
    // Start is called before the first frame update

    void ActivateRecursively(GameObject obj)
    {
        obj.SetActive(true);

        foreach (Transform child in obj.transform)
        {
            ActivateRecursively(child.gameObject);
            if (child.gameObject.tag == "inventoryBg")
            {
                child.gameObject.SetActive(false);
            }
        }
    }


    void OnSceneLoaded()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex != 0)
        {
            GameObject[] activeObjects = Resources.FindObjectsOfTypeAll<GameObject>();
            Debug.Log(activeObjects.Length);

            Scene sceneHome = SceneManager.GetSceneByBuildIndex(1);

            foreach (GameObject gameObject in activeObjects)
            {
                if (gameObject.name == "Player" || gameObject.name == "Main Camera" ||
                   gameObject.name == "GameMannager" || gameObject.name == "UI" ||
                   gameObject.name == "Contain_Plant" || gameObject.name == "Canvas")
                {
                    ActivateRecursively(gameObject);
                }
                else
                {
                    gameObject.SetActive(false);

                }
                GameObject[] rootGameObjects = sceneHome.GetRootGameObjects();

                foreach (GameObject g in rootGameObjects)
                {
                    if (gameObject.name == g.name)
                    {
                        ActivateRecursively(gameObject);


                    }

                }
            }
        }
        else
        {
            GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
            Debug.Log(allObjects.Length);

            Scene sceneHome = SceneManager.GetSceneByBuildIndex(0);

            foreach (GameObject gameObject in allObjects)
            {

                ActivateRecursively(gameObject);
            }
        }
        
    }

    // Update is called once per frame
    void Start()
    {
        OnSceneLoaded();

    }
}
