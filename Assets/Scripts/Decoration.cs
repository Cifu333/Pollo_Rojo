using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoration : MonoBehaviour
{
    SpriteRenderer sr;
    public List<Sprite> sprites;
    CapsuleCollider2D capsule;
    private int random;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = -0.5f;
        sr = GetComponent<SpriteRenderer>();
        capsule = GetComponent<CapsuleCollider2D>();
        sr.sprite = sprites[Random.Range(0, sprites.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0) * Time.deltaTime;
        if (transform.position.x < -18)
        {
            Destroy(gameObject);
        }
    }
}
