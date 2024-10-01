using TMPro;
using UnityEngine;

public class PuntuacioController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    static int punts = 0;
    public Puntos puntos;
    public cuadrado c;
    void Start()
    {
        punts = 0;
        c.GetComponent<cuadrado>().delegado += asignarPunt;
        this.GetComponent<TextMeshProUGUI>().text = "Puntuacio: 0";
    }

    // Update is called once per frame
    void Update()
    {

    }
    void asignarPunt(int punt)
    {
        punts += punt;
        puntos.punts = punts;
        this.GetComponent<TextMeshProUGUI>().text = "Puntuacio: " + punts;
    }
    private void OnDestroy()
    {
        c.GetComponent<cuadrado>().delegado -= asignarPunt;
    }
}
