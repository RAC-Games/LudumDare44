using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField]
    BossPhaseSO[] bossPhases;
    int phaseID;
    float maxHP = 100;
    CircleShoot circleAttack;
    float attackFrequency;
    //int hp = 100;
    public BossPhaseSO curPhase;


    private void Start()
    {
        maxHP = GetComponent<enemy>().health;
        circleAttack = GetComponent<CircleShoot>();
        UpdateBossPhase(bossPhases[0]);
        StartCoroutine(AttackLoop());
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //hp--;
            //Debug.Log(hp);
            //CheckForPhaseUpdate(hp);
        }
    }

    IEnumerator AttackLoop()
    { 
        circleAttack.SpawnCircleAttack();
        yield return new WaitForSeconds(attackFrequency);
        StartCoroutine(AttackLoop());

    }
    public void CheckForPhaseUpdate() {
        CheckForPhaseUpdate(GetComponent<enemy>().health);
    }
    

    public void CheckForPhaseUpdate(float hp)
    {
        float step = maxHP / bossPhases.Length;
        for(int i = 1; i < bossPhases.Length; i++)
        {
            Debug.Log("Check " + hp + " < " + (maxHP - step * i));
            if (hp > maxHP- step*i)
            {
                if (phaseID != i - 1)
                {
                    phaseID = i - 1;
                    Debug.Log("Phase ID " + phaseID);
                    UpdateBossPhase(bossPhases[i - 1]);
                    Debug.Log("Phase " + (i - 1)+" hp "+hp);
                }
                break;
            }
        }
    }

    void UpdateBossPhase(BossPhaseSO phase)
    {
        curPhase = phase;
        circleAttack.count = phase.count;
        circleAttack.splitTime = phase.splitTime;
        circleAttack.recursive = phase.recursion;
        attackFrequency = circleAttack.getCooldownDuration() * phase.attackFrequency;
    }
}
