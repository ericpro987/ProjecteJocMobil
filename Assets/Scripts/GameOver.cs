using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Puntos punts;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GetComponent<TextMeshProUGUI>().text = "La teva puntuacio és: "+punts.punts;
        punts.punts = 0;
    }


    public void Reintentar()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
