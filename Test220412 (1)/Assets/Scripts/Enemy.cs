using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //적! : 체력이 있고, 그체력에 따라 생사가 갈림!
    //총알을 맞았다 -> 체력이 깎인다
    //체력이 음의수가 된다 -> 죽는다!

    public int hp;
    public List<Transform> desTrs;
    public NavMeshAgent _navMeshAgent;
    public float timer;
    private void Start()
    {
        hp = 100;
        //_navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1f)
        {
            timer = 0;
            if (desTrs.Count == 0) return;
            if (_navMeshAgent == null) return;
            //플레이어가 1명이 아니라 2명일 때는 누굴 따라가야하는가?
            //플레이어들간의 거리를 비교하여, 가까운 플레이어에게 간다!
            Transform mydesTr = null;
            float mylength = 99999999f;
            for(int i = 0; i < desTrs.Count; i++)
            {
                //desTrs들과 이 스크립트가 들어있는 게임오브젝트간의 거리를 비교를 하여,
                //가장 가까운 거리의 Transform을 도출!
                //1. 특정 트랜스폼과 내 오브젝트간의 거리를 잰다,
                //2. 만일, 이 거리가 더 짧다면, 그 정보를 기억을 해서, 활용한다!
                float length = Vector3.Distance(transform.position, desTrs[i].position);
                if(length < mylength)
                {
                    mylength = length;
                    mydesTr = desTrs[i];
                }
            }
            _navMeshAgent.SetDestination(mydesTr.position);
        }
    }
    //navmesh를 사용할 때 주의할점 2가지!
    //1. NavMesh를 통해 이동하는 오브젝트들은, 오직 NavMesh로서만 움직여야 한다!
    //2. NavMeshAgent들은, NavMesh의 이동 가능한 영역에서 가까운 위치에 있어야 한다!

    //1. 수많은 Enemy가 나올텐데, 그 적들이 전부 update로 목적지를 받아와서 지정하면 메모리상의 문제가 생길것이다! => 일정 시간마다 설정하는것으로 조정!
    //2. desTr이 비어있는 상태에서 실행하면 오류가 날것이다 => desTr이 비어있을 때를 방지하는 코드를 넣자!

    public void Damage()
    {
        //데미지를 입으면, 일정량의 체력이 깎임!(30!)
        //체력이 음이 되면, 사망!(Destory)

        hp = hp - 30;
        //hp -= 30;
        if(hp < 0)
        {

            //FindObjectOfType<GameManagerAI>().monsterNum = FindObjectOfType<GameManagerAI>().monsterNum - 1;
            //FindObjectOfType<GameManagerAI>().monsterNum -= 1;
            FindObjectOfType<GameManagerAI>().monsterNum--;

            CountScore();

            Destroy(this.gameObject);
        }
    }

    public void SetDestination(List<Transform> trs)
    {
        desTrs = trs;
    }

    void CountScore()
    {
        FindObjectOfType<GameManagerAI>().CountScore();
    }




}
