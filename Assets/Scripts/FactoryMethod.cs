using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEditor;


public class MainApp
{
    public static void Main()
    {
        AbstractCreator[] creators = new AbstractCreator[1];
        creators[0] = new Creator();

        foreach (AbstractCreator creator in creators)
        {
            Actor actor = creator.FactoryMethod();
            Debug.Log("new zombie");
        }
    }
}

abstract class Actor
{
}

class Zombie : Actor
{
    public Zombie()
    {
        //Instantiate(Manager.Instance.zombie, Manager.Instance.zombieSpawnPos.position, Quaternion.identity);
        Manager.Instance.spawnZombies();
    }
}

abstract class AbstractCreator
{
    public abstract Actor FactoryMethod();
}

class Creator : AbstractCreator
{
    public override Actor FactoryMethod()
    {
        return new Zombie();
    }
}

