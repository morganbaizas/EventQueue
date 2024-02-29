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

        Zombie p1 = new Zombie("I");
        Zombie c1 = (Zombie)p1.Clone();
        Debug.Log("Cloned: {0}" + c1.Id);
    }
}

abstract class Actor
{
    string id;
    public Actor(string id)
    {
        this.id = id;
    }
    public string Id
    {
        get { return id; }
    }
    public abstract Actor Clone();
}

class Zombie : Actor
{
    public Zombie(string id)
        : base(id)
    {
        //Instantiate(Manager.Instance.zombie, Manager.Instance.zombieSpawnPos.position, Quaternion.identity);
        //Manager.Instance.spawnZombies();
    }

    public override Actor Clone()
    {
        return (Actor)this.MemberwiseClone();
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
        return new Zombie("zomb");
    }
}
