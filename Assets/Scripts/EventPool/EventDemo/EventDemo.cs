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
/// �¼�ϵͳ�ľ���ʹ��demo
/// </summary>
public class EventDemo : MonoBehaviour
{
    public ReactiveProperty<int> p = new ReactiveProperty<int>();
    // Start is called before the first frame update
    void Start()
    {
        //��������
        p.Subscribe(x => { print("p=" + x); });
        //����hero�¼�
        this.OnEvent<HeroEvent>().Subscribe(OnHeroEvent);
        //����hero����״̬�¼�
        this.OnEvent<HeroEvent>().Where(e => e.type == HeroEventType.DEAD).Subscribe(OnHerDead);
        //����hero����״̬�¼�
        this.OnEvent<HeroEvent>().Where(e => e.type == HeroEventType.SPAWN).Subscribe(OnHerSpawn);
        //����hero����
        this.OnEvent<HeroCommand>().Subscribe(OnHerCommand);

        //����ֵ�ĸı�
        //p.Value = 1;
        //����hero�¼�
        this.Publish(new HeroEvent());
        //����hero�����¼�
        this.Publish(new HeroEvent() { type = HeroEventType.DEAD });
        //����hero�����¼�
        this.Publish(new HeroEvent() { type = HeroEventType.SPAWN });
        //�����¼�
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
