using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEditor;

public class SpriteController : MonoBehaviour
{
    private int clicks = 5;
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

    // Method to handle mouse click events
    private void OnMouseDown()
    {
        // Increment clicks and currentClicks
        currentClicks++;
        Debug.Log(currentClicks);

        // Check if 5 clicks have occurred
        if (currentClicks % 5 == 0)
        {
            // Increment kills
            Destroy(gameObject);
            Manager.Instance.setKill();
            Debug.Log(Manager.Instance.getKill());

            // Reset currentClicks
            currentClicks = 0;
        }
    }

    public void EndGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;    
    }
}