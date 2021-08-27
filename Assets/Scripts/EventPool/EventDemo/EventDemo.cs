using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CFramework.EventUni;
using UniRx;

public enum HeroEventType
{
    NONE,
    SPAWN,
    DEAD
}

[EventID(Identifier = "10002")]
public class HeroEvent
{
    public HeroEventType type;
    public string eventType;
    public string testStr;
}

public enum HeroCmdType
{
    NONE,
    ATTACK,
    BEATTACKED
}

[EventID(Identifier = "10001")]
public class HeroCommand:ICommand<GameObject>
{
    public GameObject Result { get; set; }
    public HeroCmdType type;
}

/// <summary>
/// 事件系统的具体使用demo
/// </summary>
public class EventDemo : MonoBehaviour
{
    public ReactiveProperty<int> p = new ReactiveProperty<int>();
    // Start is called before the first frame update
    void Start()
    {
        //订阅属性
        p.Subscribe(x => { print("p=" + x); });
        //订阅hero事件
        this.OnEvent<HeroEvent>().Subscribe(OnHeroEvent);
        //订阅hero死亡状态事件
        this.OnEvent<HeroEvent>().Where(e => e.type == HeroEventType.DEAD).Subscribe(OnHerDead);
        //订阅hero生成状态事件
        this.OnEvent<HeroEvent>().Where(e => e.type == HeroEventType.SPAWN).Subscribe(OnHerSpawn);
        //订阅hero命令
        this.OnEvent<HeroCommand>().Subscribe(OnHerCommand);

        //属性值的改变
        //p.Value = 1;
        //发布hero事件
        this.Publish(new HeroEvent());
        //发布hero死亡事件
        this.Publish(new HeroEvent() { type = HeroEventType.DEAD });
        //发布hero生成事件
        this.Publish(new HeroEvent() { type = HeroEventType.SPAWN });
        //命令事件
        var result = this.Execute<HeroCommand, GameObject>(new HeroCommand() { type = HeroCmdType.ATTACK });

        print(result);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnHeroEvent(HeroEvent evt)
    {
        print("OnHeroEvent");
    }

    public void OnHerDead(HeroEvent evt)
    {
        Debug.Log("OnHerDeadEvent");
    }

    public void OnHerSpawn(HeroEvent evt)
    {
        Debug.Log("OnHerSpawnEvent");
    }

    public void OnHerCommand(HeroCommand evt)
    {
        Debug.Log("OnHerSpawnEvent"+ evt.type);
        evt.Result = new GameObject("Result" + evt.type);
    }
}
