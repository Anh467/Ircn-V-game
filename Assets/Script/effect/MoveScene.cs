using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    // Start is called before the first frame update
    public int sceneBuildIndex;

    // Level move zoned enter, if collider is a player
    // Move game to another scene
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.tag == "player" && !other.isTrigger) {

            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }

}
