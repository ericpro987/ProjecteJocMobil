using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ManzanasSO[] m;
    [SerializeField] Puntos p;
    [SerializeField] List<OBjeto> list;
    int min;
    int max;
    void Start()
    {
        min = 3;
        max = 5;
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Spawn() {
        while (true)
        {
                if (p.punts >= 10)
                {
                    min = 1;
                    max = 3;
                }
                else if (p.punts >= 20)
                {
                    min = 1;
                    max = 2;
                }

                yield return new WaitForSeconds(Random.Range(min, max));
                int sObj = Random.Range(0, 3);
                OBjeto m3 = null;

            foreach (OBjeto o in list)
            {
                if (!o.isActiveAndEnabled)
                    m3 = o;
            }
            m3.transform.position = new UnityEngine.Vector3(UnityEngine.Random.Range(-2.46f, 2.52f), 5.4f, 0);

            switch (sObj)
                {

                    case 0:
                        m3.setManzana(m[0]);
                        m3.GetComponent<Rigidbody2D>().velocity = m[0].velocity;
                    break;
                    case 1:
                        m3.setManzana(m[1]);
                        m3.GetComponent<Rigidbody2D>().velocity = m[1].velocity;
                    break;
                    case 2:
                        m3.setManzana(m[2]);
                        m3.GetComponent<Rigidbody2D>().velocity = m[2].velocity;
                    break;
                }
            m3.gameObject.SetActive(true);
            }
    }
}
