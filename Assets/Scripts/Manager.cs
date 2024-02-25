using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Manager : MonoBehaviour {
    private static Manager _instance;

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

    public int getKill()
    {
        return kills;
    }

    public void setKill() 
    {
        kills++;
    }
}
