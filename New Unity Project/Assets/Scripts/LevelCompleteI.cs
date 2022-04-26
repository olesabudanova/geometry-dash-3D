using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteI : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    

}
