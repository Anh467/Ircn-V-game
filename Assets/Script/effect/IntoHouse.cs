using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntoHouse : MonoBehaviour
{
    // Start is called before the first frame update
    public int sceneBuildIndex;
    public Vector2 playerPosition;
    public VectorValue playerStore;

    // Level move zoned enter, if collider is a player
    // Move game to another scene
    private void OnTriggerEnter2D(Collider2D other) {
        // Could use other.GetComponent<Player>() to see if the game object has a Player component
        // Tags work too. Maybe some players have different script components?
        if (other.tag == "player" && !other.isTrigger) {
            // Player entered, so move level
            playerStore.initialValue = playerPosition;
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
