using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
