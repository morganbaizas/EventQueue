using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class soldierBehavior : MonoBehaviour
{
    public Sprite sprite;
    private SpriteRenderer sr;
    private Manager manager;
    void Start()
    {
        manager = Manager.Instance;
        sr = GetComponent<SpriteRenderer>();
    }

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
