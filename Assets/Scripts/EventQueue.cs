using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventQueue : MonoBehaviour
{
    private Queue<System.Action> eventQueue = new Queue<System.Action>();
    public void Start () 
    {
        // EventManager.OnMouseDown += OnMouseDown;
    }

    public void Update() 
    {
        ProcessEvents();
    }
    public void EnqueueEvent(System.Action action)
    {
        eventQueue.Enqueue(action);
    }

    public void ProcessEvents()
    {
        while (eventQueue.Count > 0)
        {
            System.Action action = eventQueue.Dequeue();
            action();
        }
    }

//     public static class EventManager
// {
//     public static event Action OnMouseDown;

//     public static void NotifyMouseDown()
//     {
//         OnMouseDown?.Invoke();
//     }
// }
}
