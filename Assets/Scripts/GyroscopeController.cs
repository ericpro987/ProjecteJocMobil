using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GyroscopeController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public InputAction InputAction;
    public Controls controls;
    public Toggle Toggle;
    private void Start()
    {
        Toggle.isOn = controls.gyroscope;
    }
    private void OnEnable()
    {
        Toggle.isOn = controls.gyroscope;
    }
    public void CambiarBool()
    {
        controls.gyroscope = Toggle.isOn;
    }
}
