using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEditor;

public class SpriteController : MonoBehaviour
{
    private int clicks = 5;
    private int kills = 0;
    private int currentClicks = 0;
    private Queue<Action> eventQueue = new Queue<Action>();

    void Start()
    {
        // Subscribe to mouse down events
        EventManager.OnMouseDown += OnMouseDown;

        // Check for kills event
        EnqueueEvent(CheckKills);
    }

    void OnDestroy()
    {
        // Unsubscribe from mouse click events
        EventManager.OnMouseDown -= OnMouseDown;
    }

    void Update()
    {
        // Process events in the queue
        ProcessEvents();
        CheckKills();
        transform.position += transform.right * 0.5f * Time.deltaTime;
    }

    // Method to enqueue events
    private void EnqueueEvent(Action action)
    {
        eventQueue.Enqueue(action);
    }

    // Method to process events in the queue
    private void ProcessEvents()
    {
        while (eventQueue.Count > 0)
        {
            Action action = eventQueue.Dequeue();
            action();
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
            kills++;
            Debug.Log(kills);

            // Reset currentClicks
            currentClicks = 0;

            // Add event to check for kills
            EnqueueEvent(CheckKills);
        }
    }

    // Method to check for kills
    private void CheckKills()
    {
        if (kills == 2)
        {
            // Quit the application if kills equals 15
            UnityEditor.EditorApplication.isPlaying = false;
            Debug.Log("doing ur mom!");
        }
    }
}

// Event manager to handle mouse click events
public static class EventManager
{
    public static event Action OnMouseDown;

    public static void NotifyMouseDown()
    {
        OnMouseDown?.Invoke();
    }
}