using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public Sprite[] s;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    bool a = false;
    public void Pause()
    {
        if (a)
        {
            this.GetComponent<Button>().image.sprite = s[0];
            a = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            this.GetComponent<Button>().image.sprite = s[1];
            a = true;
            Time.timeScale = 0f;
        }
    }
}
