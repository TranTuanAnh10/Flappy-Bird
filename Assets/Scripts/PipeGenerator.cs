using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PipeGenerator : MonoBehaviour
{
    public GameObject pipePrefab;
    private float countDown;
    public float timeDuration;
    public bool enanelPipe = false;

    private void Awake()
    {
        countDown = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        if(enanelPipe == true)
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0)
            {
                Instantiate(pipePrefab, new Vector3(1, Random.Range(-1.2f, 2.1f), 0), Quaternion.identity);
                countDown = timeDuration;
            }
        }
    }
    
}
