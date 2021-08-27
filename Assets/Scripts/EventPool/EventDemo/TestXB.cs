using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CFramework.EventUni;

//泛型接口间的协变
public interface XieBianInterface<out T>
{
    T GetT();
}

class XieBianClass<T>: XieBianInterface<T>
{
    public T[] items { get; set; }
    public T GetT()
    {
        return items[0];
    }
}

public class TestXB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //EventHandle<Animal> xieBian = new EventHandle<Animal>(ShowLegs);

        //EventHandle<Dog> xieBDog = xieBian;
        //xieBDog(new Dog() { legs = 8 });
        Publish publish = new Publish();
        publish.XKEvent += new Publish.XKEventHandle(Claa1End);
        publish.XKEvent += new Publish.XKEventHandle(Claa2End);
        publish.CallEnd("123");
    }

    [EventID("123")]
    public void ShowLegs(Animal animal)
    {
        Debug.LogError(animal.legs);
    }

    void Claa1End(string time)
    {
        Debug.Log("Claa1End");
    }

    void Claa2End(string time)
    {
        Debug.Log("Claa2End");
    }
}

public class Animal
{
    public int legs { get; set; } = 4;
}

public class Dog:Animal
{

}

//泛型委托间的逆变
//委托
public delegate void EventHandle<in T>(T t);

//发布
public class Publish
{
    public delegate void XKEventHandle(string times);
    public event XKEventHandle XKEvent;

    public void EndClass(string time)
    {
        CallEnd(time);
    }

    public void CallEnd(string time)
    {
        XKEvent(time);
    }
}
