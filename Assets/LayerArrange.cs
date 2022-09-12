using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerArrange : MonoBehaviour
{
    public SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        render.sortingOrder = other.gameObject.GetComponent<SpriteRenderer>().sortingOrder - 1;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        render.sortingOrder = 3;
    }
}
