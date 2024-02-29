using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEditor;

public class SpriteController : SpriteControllerAbstract
{
    public int clicks = 5;
    private int currentClicks = 0;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += transform.right * 0.5f * Time.deltaTime;
        if (transform.position.x > 0.65)
        {
            Manager.Instance.getEventQueue().EnqueueEvent(EndGame);
        }
    }

    public override void OnMouseDown()
    {
        currentClicks++;
        Debug.Log("CURRENT CLICKS: " + currentClicks);

        if (currentClicks % clicks == 0)
        {
            Destroy(gameObject);
            Manager.Instance.setKill();
            Debug.Log("KILLS: " + Manager.Instance.getKill());

            currentClicks = 0;
        }
    }

    public void EndGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;    
    }
}