using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float hareketHizi;

    Rigidbody2D rb;

    [SerializeField]
    float ziplamaGucu;

    private SpriteRenderer _sr;

    

    bool yerdemi; //karakterin sadece yere deðince tekrardan uçmasý için.
    public Transform zeminKnotrolNoktasi;
    public LayerMask zeminLayer;
    bool ikiKezZiplayabilirmi;
    Animator _animator;

    public float geriTepmeSuresi, geriTepmeGucu;
    float geriTepmeSayaci;
    
    public float ziplaZiplaGucu;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        if(geriTepmeSayaci <= 0)
        {
            HareketEttirFNC();
            ZiplaFNC();
        } else
        {
            geriTepmeSayaci -= Time.deltaTime;

            
        }
        

    

    }

    void HareketEttirFNC()// hareket ettirme
    {
        float h = Input.GetAxis("Horizontal");
        float hiz = h * hareketHizi;

        rb.velocity=new Vector2 (hiz,rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.D))
        {
            _animator.SetFloat("hiz", 1f);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetFloat("hiz", 0f);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            _animator.SetFloat("hiz", 1f);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _animator.SetFloat("hiz", 0f);
        }


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _animator.SetFloat("hiz", 1f);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _animator.SetFloat("hiz", 0f);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _animator.SetFloat("hiz", 1f);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _animator.SetFloat("hiz", 0f);
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetBool("yerdemi", true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _animator.SetBool("yerdemi", false);
        }

        if(h < 0) 
        {
            _sr.flipX = true; // unity'de sprie rendererde ki flip'e ulaþtýk.
        }else if(h > 0) 
        {
            _sr.flipX = false;
        }



    }

    void ZiplaFNC()
    {
        yerdemi = Physics2D.OverlapCircle(zeminKnotrolNoktasi.position, 0.2f, zeminLayer);
        
        if (yerdemi)
        {
            ikiKezZiplayabilirmi = true;
        }

        if (Input.GetButtonDown("Jump")) // button down basýlý demek.
        {
            if (yerdemi) 
            {
                rb.velocity = new Vector2(rb.velocity.x, ziplamaGucu);



            } else
            {
                if(ikiKezZiplayabilirmi)
                {
                    rb.velocity = new Vector2(rb.velocity.x, ziplamaGucu);
                    ikiKezZiplayabilirmi = false;
                }
                
            }
            
        }
    }

    public void GeriTepmeFNC()
    {
        geriTepmeSayaci = geriTepmeSuresi;
        rb.velocity = new Vector2(0, rb.velocity.y);
        _animator.SetTrigger("hasar");


    }


    public void ZiplaZipla()
    {
        rb.velocity = new Vector2(rb.velocity.x, ziplaZiplaGucu);
    }


}
