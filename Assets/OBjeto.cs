using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OBjeto : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public ManzanasSO manzanas;
    void Start()
    {
        this.name = "Manzana";
        this.transform.position = new Vector3(UnityEngine.Random.Range(-2.46f, 2.52f), 5.4f, 0); 
        this.GetComponent<SpriteRenderer>().sprite = manzanas.sr;
        this.GetComponent<Rigidbody2D>().velocity=manzanas.velocity;
        this.GetComponent<CircleCollider2D>().radius = manzanas.RadiusCollider;
        this.transform.localScale = manzanas.Scale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setManzana(ManzanasSO m)
    {
        manzanas = m;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "GameOver" && this.manzanas.sr.name != "black_apple_0")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
