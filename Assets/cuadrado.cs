using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class cuadrado : MonoBehaviour
{
    [SerializeField] private InputActionAsset _ActionInput;
    public delegate void a(int a);
    public event a delegado;
    InputActionAsset input;
    private InputAction mousePosition;
    private InputAction GamePad;
    public Controls controls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {

    }
    void Start()
    {
        input = Instantiate(_ActionInput);

        input.FindActionMap("Player").Enable();
    }
    private void Update()
    {
        if (!controls.gyroscope)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(input.FindActionMap("Player").FindAction("AccelerometerTeclado").ReadValue<Vector3>().x * 3.5f, 0);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(input.FindActionMap("Player").FindAction("Accelerometer").ReadValue<Vector3>().x * 3.5f, 0);
        }
        Debug.Log("Accelerometer 1: "+input.FindActionMap("Player").FindAction("Accelerometer").ReadValue<Vector3>());
        Debug.Log("Accelerometer 2: "+input.FindActionMap("Player").FindAction("AccelerometerTeclado").ReadValue<Vector3>());
    }

    public void movementRight(InputAction.CallbackContext context)
    {
        if(context.started)
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(3.5f, 0);
        else if(context.canceled)
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        print(context);
    }

    public void movementLeft(InputAction.CallbackContext context)
    {
        if (context.started)
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-3.5f, 0);
        else if (context.canceled)
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        print(context);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Manzana")
        {
            //   AudioSource cl = new AudioSource();
            // cl.clip = collision.GetComponent<OBjeto>().manzanas.audio;
            //cl.Play();
            delegado.Invoke(collision.GetComponent<OBjeto>().manzanas.punts);
            Destroy(collision.gameObject);
        }
    }
    private void OnDestroy()
    {
        input.FindActionMap("Player").FindAction("Right").started  -= movementRight;
        input.FindActionMap("Player").FindAction("Right").canceled -= movementRight;
        input.FindActionMap("Player").FindAction("Left").started   -= movementLeft;
        input.FindActionMap("Player").FindAction("Left").canceled  -= movementLeft;
    }
}
