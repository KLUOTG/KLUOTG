using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KediKontrol : MonoBehaviour
{
    [SerializeField]
    [Range(0,20)]
    private float hiz;
    [SerializeField]
    [Range(0, 20)]
    private float ziplamaHiz;


    float horizontal;
    float hareket;
    Vector2 vek;
    Animator anim;
    Rigidbody2D rb;
    public bool yerdeMi;
    public LayerMask zeminLayer;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        yerdeMi = isYerdemi();

        horizontal = Input.GetAxis("Horizontal");
        hareket += horizontal * hiz * Time.deltaTime;
        vek = new Vector2(hareket, transform.position.y);
        transform.position = vek;

        if (Input.GetButton("Jump"))
        {
            if (isYerdemi()==true)
            {
                KarakterZipla();
            }
            
        }

        if (horizontal < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (horizontal > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (horizontal != 0)
        {
            anim.SetBool("yuruyorMu", true);
        }
        else
        {
            anim.SetBool("yuruyorMu", false);
        }

    }
    bool isYerdemi()
    {
        Vector2 karakterPozisyon = transform.position;
        Vector2 yon = Vector2.down;
        float distance = 0.5f;
        RaycastHit2D hit = Physics2D.Raycast(karakterPozisyon, yon, distance,zeminLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }
    void KarakterZipla()
    {
        rb.AddForce(Vector2.up*ziplamaHiz);
    }
}
