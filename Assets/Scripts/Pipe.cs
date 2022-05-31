using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            Move();
            if (transform.position.x <= -8)
            {
                Destroy(gameObject);
            }
    }
    private void Move()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
   
}
