using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    SpriteRenderer sr;
    public List<Sprite> sprites;
    CapsuleCollider2D capsule;
    Generator generator;
    private int random;
    private int speedY;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        random = Random.Range(0, sprites.Count);
        generator = transform.parent.GetComponent<Generator>();
        sr = GetComponent<SpriteRenderer>();
        capsule = GetComponent<CapsuleCollider2D>();
        sr.sprite = sprites[random];
        switch (random)
        {
            case 0:
                speedY = 4;
                capsule.size = new Vector2(1.25f, 1.25f);
                break;
            case 1:
                capsule.offset = new Vector2(-1.05f, -1);
                capsule.size = new Vector2(2.85f, 1.55f);
                transform.position = new Vector2(Random.Range(-2.35f, 10), 6.98f);
                break;
            case 2:
                capsule.direction = CapsuleDirection2D.Horizontal;
                capsule.offset = new Vector2(0.04f, 0.07f);
                capsule.size = new Vector2(1f, 0.82f);
                break;
            case 3:
                speedY = 1;
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
                transform.position += new Vector3(-3.5f, speedY) * Time.deltaTime;
                break;
            case 1:
                transform.position += new Vector3(-3, -3) * Time.deltaTime;
                break;
            case 2:
                transform.eulerAngles += new Vector3(0, 0, 30) * Time.deltaTime;
                transform.position += new Vector3(-3f,0) * Time.deltaTime;
                break;
            case 3:
                transform.eulerAngles += new Vector3(0, 0, 70) * Time.deltaTime;
                transform.position += new Vector3(-3f, speedY) * Time.deltaTime;
                if (transform.position.y >= 3.35f && speedY > 0)
                    speedY = -speedY;
                if (transform.position.y <= -3.36f && speedY < 0)
                    speedY = -speedY;
                time += Time.deltaTime;
                if (time >= 2) {
                    if (Random.Range(1, 10) <= 2)
                        speedY = -speedY;
                    time = 0;
                }
                break;
        }
        if (transform.position.x < -18)
        {
            Destroy(gameObject);
            generator.enemyCount--;
        }
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
