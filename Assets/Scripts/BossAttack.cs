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
    BossHealthbar healthbar;
    Animator anim;


    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        healthbar = FindObjectOfType<BossHealthbar>();
        maxHP = GetComponent<enemy>().health;
        circleAttack = GetComponent<CircleShoot>();
        UpdateBossPhase(bossPhases[0]);
        StartCoroutine(AttackLoop());

        float step = maxHP / bossPhases.Length;
        for (int i = 0; i < bossPhases.Length; i++)
        {
            Debug.Log("Phase " + i + " at " + (maxHP - step * i));
        }
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
        anim.SetTrigger("CircleAttack");
        circleAttack.SpawnCircleAttack();
        yield return new WaitForSeconds(attackFrequency);
        StartCoroutine(AttackLoop());

    }
    public void CheckForPhaseUpdate() {
        CheckForPhaseUpdate(GetComponent<enemy>().health);
    }
    

    public void CheckForPhaseUpdate(float hp)
    {
        UpdateHealthBar(hp);
        float step = maxHP / bossPhases.Length;
        for(int i = 0; i < bossPhases.Length; i++)
        {
            Debug.Log("Check " + hp + " < " + (maxHP - step * i));
            if (hp > maxHP- step*(i+1))
            {
                if (phaseID != i)
                {
                    phaseID = i;
                    Debug.Log("Phase ID " + phaseID);
                    UpdateBossPhase(bossPhases[i]);
                    Debug.Log("Phase " + (i)+" hp "+hp);
                }
                break;
            }
        }
    }

    void UpdateHealthBar(float hp)
    {
        healthbar.UpdateHP(hp / maxHP);
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
