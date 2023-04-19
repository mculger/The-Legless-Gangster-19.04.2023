using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class slimeController : MonoBehaviour
{
    public float hareketHizi;

    public Transform solHedef, sagHedef;

    bool sagTarafta;

    Rigidbody2D rb;

    public float hareketSuresi,beklemeSuresi;
    float hareketSayaci,beklemeSayaci;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        solHedef.parent = null;
        sagHedef.parent = null;


        sagTarafta = true;

        hareketSayaci = hareketSuresi;

    }

    private void Update()
    {
        if (hareketSayaci > 0)
        {
            hareketSayaci -= Time.deltaTime;



            if (sagTarafta)
            {
                rb.velocity = new Vector2(hareketHizi, rb.velocity.y);

                if (transform.position.x > sagHedef.position.x)
                {
                    sagTarafta = false;
                }

            }
            else
            {
                rb.velocity = new Vector2(-hareketHizi, rb.velocity.y); // hareket hýzýný negatif yöne çektik.

                if (transform.position.x < solHedef.position.x)
                {
                    sagTarafta = true;
                }
            }

            if(beklemeSayaci<=0)
            {
                beklemeSayaci = beklemeSuresi;
            }
        } else if (beklemeSayaci > 0)
        {
            beklemeSayaci -= Time.deltaTime;
            rb.velocity = new Vector2(0, rb.velocity.y);

            if(beklemeSayaci <= 0)
            {
                hareketSayaci = hareketSuresi;
            }
        }
    }


}
