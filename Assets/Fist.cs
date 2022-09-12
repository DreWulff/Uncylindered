using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float ttl;
    private GameObject fist;
    // Start is called before the first frame update
    void Start()
    {
        ttl = 0.5f;
        fist = this.gameObject;
        rb.velocity = transform.up * -1 * speed;
    }

    // Update is called once per frame
    void Update()
    {
        ttl -= Time.deltaTime;
        if (ttl < 0)
        {
            Destroy(fist);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.gameObject.CompareTag("Treant"))
        {
            FindObjectOfType<Manager>().DeleteTreant(other.gameObject);
        }
    }
}
