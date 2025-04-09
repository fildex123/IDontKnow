using UnityEngine;

public class GamePause : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject ZpetDoLobby;
    public GameObject PlayAgain;
    public GameObject Resume;
    private void Start()
    {
        Resume.SetActive(false);
    }
    public void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            ZpetDoLobby.SetActive(false);
            PlayAgain.SetActive(false);
            Resume.SetActive(false);

        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
            ZpetDoLobby.SetActive(true);
            PlayAgain.SetActive(true);
            Resume.SetActive(true);
        }
    }
}