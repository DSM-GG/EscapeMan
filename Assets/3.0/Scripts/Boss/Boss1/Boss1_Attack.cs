using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_Attack : MonoBehaviour {

    public int fire_missile_number;
    public int fire_bomb_number;

    public float cannonDelay;   // 포 발사 쿨타임
    public float launcherDelay; // 발사기 쿨타임
    public float cannonCool;      // 폭탄 발사 쿨타임
    public float launcherCool;   // 미사일 발사 쿨타임

    private Boss_Cannon[] cannon;
    private Boss_Launcher launcher;
    private Boss1 boss;

    private WaitForSeconds wfs_cannon;
    private WaitForSeconds wfs_launcher;

    // Use this for initialization
    void Awake()
    {
        boss = GetComponent<Boss1>();
        cannon = new Boss_Cannon[2];
        cannon[0] = transform.Find("Cannon_L").GetComponent<Boss_Cannon>();
        cannon[0].SetDelay(cannonDelay);
        cannon[1] = transform.Find("Cannon_R").GetComponent<Boss_Cannon>();
        cannon[1].SetDelay(cannonDelay);
        launcher = transform.Find("Launcher").GetComponent<Boss_Launcher>();
        launcher.SetMissileDelay(launcherDelay);
        launcher.SetMissileAmount(fire_missile_number);

        wfs_cannon = new WaitForSeconds(cannonCool);
        wfs_launcher = new WaitForSeconds(launcherCool);
    }

    private void Start()
    {
        Active();
    }

    IEnumerator Pattern()
    {
        //StartCoroutine("BombCool");
        yield return new WaitForSeconds(3.0f);
        Active();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void Active()
    {
        StartCoroutine("CannonCool");
        StartCoroutine("LauncherCool");
    }

    void Deactive()
    {
        StopAllCoroutines();
    }

    void SetCannonCool(float cool)
    {
        cannonCool = cool;
        wfs_cannon = new WaitForSeconds(cool);
    }

    void SetLauncherCool(float cool)
    {
        launcherCool = cool;
        wfs_launcher = new WaitForSeconds(cool);
    }

    IEnumerator CannonCool()
    {
        for (int i = 0; i < 2; ++i)
            cannon[i].Fire(fire_bomb_number, boss.GetDir());
        yield return wfs_cannon;
        StartCoroutine("CannonCool");
    }

    IEnumerator LauncherCool()
    {
        launcher.Fire(fire_missile_number, boss.GetDir());
        yield return wfs_launcher;
        StartCoroutine("LauncherCool");
    }
}
