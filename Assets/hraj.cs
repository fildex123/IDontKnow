using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void OnButtonClick(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
