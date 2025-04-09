using UnityEngine;

public class BackToGame : MonoBehaviour
{
    public GameObject Pause; 
    public GameObject vipni1;
    public GameObject vipni2;
    public void TogglePause()
    {
        Time.timeScale = 1;
        Pause.GetComponent<GamePause>().isPaused = false;
        vipni1.SetActive(false);
        vipni2.SetActive(false);
        gameObject.SetActive(false);
    }
}
