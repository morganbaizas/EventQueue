using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieBehavior : MonoBehaviour
{

    int CPZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (CPZ == 7) {
            Destroy(gameObject);
        }
        // transform.position = new Vector2(10, 0);
    }

    void OnMouseDown() {
        CPZ++;
        Debug.Log(CPZ);
    }
}
