using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public GameObject fist;
    public Transform tf;
    public Manager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Punch();
        }
    }

    void Punch()
    {
        if (manager.stamina > 5)
        {
            Instantiate(fist, tf.position, tf.rotation);
            manager.ReduceStamina(5f);
        }
    }
}
