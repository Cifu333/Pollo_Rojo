using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    SpriteRenderer sr;
    public List<Sprite> sprites;
    CapsuleCollider2D capsule;
    private int random;
    private int speedY;
    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(0, sprites.Count);
        sr = GetComponent<SpriteRenderer>();
        capsule = GetComponent<CapsuleCollider2D>();
        sr.sprite = sprites[random];
        switch (random)
        {
            case 0:
                speedY = 1;
                capsule.size = new Vector2(1.25f, 1.25f);
                break;
            case 1:
                capsule.offset = new Vector2(-1.05f, -1);
                capsule.size = new Vector2(2.85f, 1.55f);
                transform.position = new Vector2(Random.Range(-2.35f, 10), 6.98f);
                break;
            case 2:
                break;
            case 3:
                capsule.size = new Vector2(2.9f, 1);
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        switch (random)
        {
            case 0:
                if (transform.position.y >= 4.35f && speedY > 0)
                    speedY = -speedY;
                if (transform.position.y <= -4.36f && speedY < 0)
                    speedY = -speedY;
                transform.position += new Vector3(-1, speedY) * Time.deltaTime;
                break;
            case 1:
                transform.position += new Vector3(-2, -2) * Time.deltaTime;
                break;
            case 2:
                transform.eulerAngles += new Vector3(0, 0, 30) * Time.deltaTime;
                transform.position += new Vector3(-1.5f,0) * Time.deltaTime;
                break;
            case 3:
                transform.eulerAngles += new Vector3(0, 0, 70) * Time.deltaTime; 
                break;
        }
        if (transform.position.x < -18)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Chicken")
        {
            collision.gameObject.GetComponent<Status>().hp--;
            Destroy(collision.gameObject);
        }
    }
}
