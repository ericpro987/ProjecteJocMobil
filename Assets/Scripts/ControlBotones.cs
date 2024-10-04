using UnityEngine;
using UnityEngine.InputSystem;

public class ControlBotones : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Controls Controls;

    private void Start()
    {
        if(Controls.gyroscope == true)
        {
          //  InputSystem.EnableDevice(UnityEngine.InputSystem.Gyroscope.current);
            this.gameObject.SetActive(false);
        }
        else
        {
            //InputSystem.DisableDevice(UnityEngine.InputSystem.Gyroscope.current);
            this.gameObject.SetActive(true);
        }
    }
}
