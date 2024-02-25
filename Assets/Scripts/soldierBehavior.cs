using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class soldierBehavior : MonoBehaviour
{
    public Sprite sprite;
    private SpriteRenderer sr;
    private Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = Manager.Instance;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.getKill() == 2) {
            Manager.Instance.getEventQueue().EnqueueEvent(ChangeSoldier);
        }
    }

    public void ChangeSoldier() {
        sr.sprite = sprite;
    }
}
