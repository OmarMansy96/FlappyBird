using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position - new Vector3(3 * Time.deltaTime, 0, 0);

        if(transform.position.x <=-17)
        {
            Destroy(gameObject);
        }
    }
    
}
