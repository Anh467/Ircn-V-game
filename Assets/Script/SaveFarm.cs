using Assets.Script;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveFarm : MonoBehaviour
{
    public static SaveFarm instance = null;
    public List<GameObject> gameObjects = new List<GameObject>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            OnDestroyGameObjectWhenLoadScene();

        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void Update()
    {
        OnDestroyGameObjectWhenLoadScene();
    }
    bool IsInDontDestroyOnLoad(GameObject go)
    {
        Scene[] scenes = SceneManager.GetAllScenes();
        foreach (var scene in scenes)
        {
            if (scene.isLoaded)
            {
                GameObject[] rootGameObjects = scene.GetRootGameObjects();
                foreach (var rootGO in rootGameObjects)
                {
                    if (rootGO == go)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public void OnDestroyGameObjectWhenLoadScene()
    {
        Scene sceneFarm = SceneManager.GetSceneByBuildIndex(0);
        if (sceneFarm.IsValid())
        {
            GameObject[] rootGameObjects = sceneFarm.GetRootGameObjects();

            if (rootGameObjects != null)
            {
                foreach (GameObject go in rootGameObjects)
                {
                    if (!IsInDontDestroyOnLoad(go) )
                    {
                        DontDestroyOnLoad(go);
                    }
                    else if (go.tag == DeclareVariable.TAG_PRODUCT)
                    {
                        DontDestroyOnLoad(go);
                    }
                    else
                    {
                            Destroy(go);   
                    }

                }
            }
        }
        else
        {
            Debug.LogWarning("The scene is invalid.");
        }
    }
}
