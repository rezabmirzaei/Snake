using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputHandlerScript : MonoBehaviour
{

    public Button startButton;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene("Snake");
    }
}
