using UnityEngine;
using UnityEngine.SceneManagement;

public class Resetcene : MonoBehaviour
{
    public void ResetScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
