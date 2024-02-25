using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldierBehavior : MonoBehaviour
{
    private Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = Manager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.getKill() == 10) {
            Debug.Log("change pic 1");
        }
    }
}
