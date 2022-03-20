using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public void StartSnake()
    {
        SceneManager.LoadScene("Snake");
    }

}
