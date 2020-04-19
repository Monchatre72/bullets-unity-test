using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ammo : MonoBehaviour
{
    public float speed = 5f;
    Transform myTransform;
    public BoxCollider2D box;
    private void Start()
    {
        myTransform = GetComponent<Transform>();
    }
    void Update()
    {

        myTransform.Translate(Vector2.right *Time.deltaTime* speed);
    }

    private void OntriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ennemie")
        {
            Destroy(this.gameObject);
        }
    }
}
