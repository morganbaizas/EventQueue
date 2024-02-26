using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Manager : MonoBehaviour {
    private static Manager _instance;
    public GameObject zombie;
    public Transform zombieSpawnPos;
    private EventQueue eq;

    public static Manager Instance { get { return _instance; } }
    private int kills;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    void Start() 
    {
        eq = GameObject.Find("EventQueue").GetComponent<EventQueue>();
        InvokeRepeating(nameof(spawnZombies), 0.3f, 1.5f);
        //InvokeRepeating("MainApp.Main()", 0.3f, 1.5f);
        CheckKills();
    }

    public EventQueue getEventQueue()
    {
        return eq;
    }

    public int getKill()
    {
        return kills;
    }

    public void setKill() 
    {
        kills++;
    }

    public void spawnZombies()
    {
        Instantiate(zombie, zombieSpawnPos.position, Quaternion.identity);
        Debug.Log("zombies spawning");
        // MainApp.Main();
    }

    private void CheckKills()
    {
        if (getKill() == 15)
        {
            // Quit the application if kills equals 15
            UnityEditor.EditorApplication.isPlaying = false;
            Debug.Log("doing ur mom!");
        }
        StartCoroutine(DelayedFunctionCall(1.0f, CheckKills));
    }
    public IEnumerator DelayedFunctionCall(float delayInSeconds, System.Action func)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayInSeconds);

        // Call your function here
        getEventQueue().EnqueueEvent(func);
    }
}
