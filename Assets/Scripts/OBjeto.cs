using System;
using System.Collections;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OBjeto : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public ManzanasSO manzanas;
    private void OnEnable()
    {
        this.GetComponent<Rigidbody2D>().velocity = manzanas.velocity;
        this.GetComponent<SpriteRenderer>().sprite = manzanas.sr;
    }
    void Start()
    {
        this.name = "Manzana";
        //this.AddComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setManzana(ManzanasSO m)
    {
        manzanas = m;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "GameOver" && this.manzanas.sr.name != "black_apple_0")
        {
            Debug.Log("Sprite: "+this.manzanas.sr.name);
            StartCoroutine(particulasGameOver());
            
        }else if(collision.gameObject.name == "GameOver" && this.manzanas.sr.name == "black_apple_0")
        {
            this.gameObject.SetActive(false);
        }
    }
    IEnumerator particulasGameOver()
    {
        //this.manzanas.GameOver = true;
        ParticleSystem ps= Instantiate(this.manzanas.ParticleSystem);
        ps.transform.position = this.transform.position;
        ps.Play();
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        SceneManager.LoadScene("GameOver");
    }
}
