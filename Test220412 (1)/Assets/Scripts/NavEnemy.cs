using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavEnemy : MonoBehaviour
{
    //NavMesh : Unity에서 땅 , 지형 , 높낮이 , 장애물등을 설정 하여, 거기서 나오는 경로대로 자동으로 움직이게 만들어주는 시스템
    //NavMeshAgent : 경로에 따라 자동으로 움직이도록 설정 가능하도록 만들어주는 컴포넌트
    //NavMeshObstacle : 경로 상에서 장애물을 두고 싶을때, 사용 가능한 컴포넌트
    //t:*** : 하이라키 검색창에 사용 가능한 약어 (해당 씬(들)에서, *** 컴포넌트를 가지고 있는 오브젝트만 검색해서 보여주세요!)

    //NavMesh 설정 하는 법!
    //0. navigation 창을 통해서 모든 렌더링들에 Navigation Static을 설정해주고 원하는 조건으로 Bake해준다!
    //1. 유니티 창에서 Window - Navigation을 통해 Navigation 창을 만들어준다.
    //2. Navigation창 - Object - 씬에 있는 렌더링 요소들을 추합 하여 Navigation Static을 걸어준다!
    //3. Bake - 본인 씬의 정보들을 설정하고, Bake 실행
    //4. 씬 상의 푸른 영역을 보며, 본인이 지정한 영역과 같은지 비교!
    //4-1. 본인이 지정한 영역이 적용이 안되었거나, 새로이 세팅한 정보들을 적용시키고 싶을땐, 2번부터 진행!

    public NavMeshAgent _navMeshAgent;
    public GameObject playerOBJ;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    //NavMeshAgent.Destination
    //1. Vector3값으로만 지정이 가능합니다 (Localposition이 아닌 World좌표를 통해서 다루어야 한다!)
    //2. 목적지에 도달하면? : 멈춘다! 하지만 다른 좌표로 이동되면, 다시 목적지를 향해 이동한다!

    //Q : 목적지가 좌표가 아니라 이동하는 물체라면? (플레이어) - 실시간 좌표값을 고쳐줘야함!
    private void Start()
    {
        _navMeshAgent.destination = Vector3.zero;
    }


    private void Update()
    {
        TrackingPlayer();
    }

    //Enemy가 실시간으로 Player를 따라오게 만들어보자!
    void TrackingPlayer()
    {
        Vector3 des = playerOBJ.transform.position;
        //목적지는 플레이어의 좌표!
        //실시간으로 NavMeshAgent의 목적지를 바꿔주면!
        _navMeshAgent.destination = des;
        //_navMeshAgent.destination = playerOBJ.transform.position;
    }
}
