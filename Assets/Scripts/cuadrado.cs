using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class cuadrado : MonoBehaviour
{
    [SerializeField] private InputActionAsset _ActionInput;
    public delegate void a(int a);
    [SerializeField] AudioManager am;
    public event a delegado;
    public InputActionAsset input;
    private InputAction mousePosition;
    private InputAction GamePad;
    public Controls controls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = Instantiate(_ActionInput);

        input.FindActionMap("Player").Enable();
        if (UnityEngine.InputSystem.Gyroscope.current != null)
{
       InputSystem.EnableDevice(UnityEngine.InputSystem.Gyroscope.current);
}
if (AttitudeSensor.current != null)
{
        InputSystem.EnableDevice(AttitudeSensor.current);
}
    }
    private void Update()
    {
        movement();
    }

    public void movement()
    {
        if (!controls.gyroscope)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(input.FindActionMap("Player").FindAction("AccelerometerTeclado").ReadValue<Vector3>().x * 3.5f, 0);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-input.FindActionMap("Player").FindAction("Accelerometer").ReadValue<Vector3>().z * 3.5f, 0);
        };
        Debug.Log("Accelerometer 1: " + input.FindActionMap("Player").FindAction("Accelerometer").ReadValue<Vector3>());
        Debug.Log("Accelerometer 2: " + input.FindActionMap("Player").FindAction("AccelerometerTeclado").ReadValue<Vector3>());
    }

    public void movementRight(InputAction.CallbackContext context)
    {
        if (controls.gyroscope)
        {
            if (context.started)
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(3.5f, 0);
            else if (context.canceled)
                this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else
        {
            if (context.started)
                this.GetComponent<Rigidbody2D>().velocity = UnityEngine.InputSystem.Gyroscope.current.angularVelocity.ReadValue();
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        print(context);
    }

    public void movementLeft(InputAction.CallbackContext context)
    {
        if (controls.gyroscope)
        {
            if (context.started)
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-3.5f, 0);
            else if (context.canceled)
                this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else
        {
            if (context.started)
                this.GetComponent<Rigidbody2D>().velocity = UnityEngine.InputSystem.Gyroscope.current.angularVelocity.ReadValue();
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        print(context);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Manzana")
        {
            delegado.Invoke(collision.gameObject.GetComponent<OBjeto>().manzanas.punts);
            if(collision.gameObject.GetComponent<OBjeto>().manzanas.sr.name != "black_apple_0")
                am.a2();
            else 
                am.a3();
            collision.gameObject.SetActive(false);
        }
    }
    private void OnDestroy()
    {
        if (input)
        {
            input.FindActionMap("Player").FindAction("AccelerometerTeclado").started -= movementRight;
            input.FindActionMap("Player").FindAction("AccelerometerTeclado").canceled -= movementRight;
            input.FindActionMap("Player").FindAction("Accelerometer").started -= movementLeft;
            input.FindActionMap("Player").FindAction("Accelerometer").canceled -= movementLeft;
        }
    }
}
