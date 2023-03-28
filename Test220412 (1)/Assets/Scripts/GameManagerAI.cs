using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameManagerAI : MonoBehaviour
{
    //나오는 몬스터들을 잡아서 점수를 올리는 게임!
    //0. 게임 시작과 종료를 관리!(시작 전 타이머, 타임 체크 , 종료 시 메시지 띄우기)
    //1. 몬스터들을 나오게 한다!
    //2. 몬스터들이 잡힐 때 점수가 집계된다!

    //1p와 2p를 선택에 따라서 구현이 되어야 한다!
    //지금이 1p만 되어있는데, 이 상황에서 2p까지 구현을 하려면, 무엇을 고려해야 할까?
    //1. 선택에 따라서 1p오브젝트 만 있느냐, 2p의 오브젝트까지 있느냐에 대한 구현!
    //2. 만일 적을 죽였을 때, 누구의 스코어가 될것이냐? (기획! - 막타 친 사람!)
    //3. 양 플레이어가, 각자의 총알로 서로가 피해를 입지 않도록!
    //3-1. 1p / 2p 플레이어들과 각자의 총알과, Enemy들의 외형 간단하게 꾸미기!(Material)

    public float timer;
    public float leftTime = 30f;
    public float spawnTimer;
    public int score;
    int scorePer;

    public int monsterNum;
    public int monsterMaxnum;

    public Text showText;
    public Text endText;
    public Text leftTimeText;
    public Text scoreText;

    public bool isStart;
    public GameObject startPanal;
    public bool isGame;
    public List<Transform> playerTrList;

    public GameObject monsterPrefab;
    public Transform[] spawnSpots;

    public GameObject p1prefab;
    public GameObject p2prefab;
    public Transform p1spot;
    public Transform p2spot;

    private void Start()
    {
        playerTrList.Clear();
        leftTime = 50f;
        isGame = false;
        isStart = false;
        score = 0;
        scorePer = 10;
        monsterNum = 0;
        monsterMaxnum = 10;
        startPanal.SetActive(true);
    }


    private void Update()
    {
        //유저가 원하는 시점에 게임을 시작할 수 있도록, 막아주는 가림판를 제작!
        if (!isStart) return;
        //if (isStart == false) return;
        TimerCheck();
        SpawnMonster();
    }


    //선택에 따라서 1p오브젝트 만 있느냐, 2p의 오브젝트까지 있느냐에 대한 구현!
    //0. 플레이만 하면 자동으로 게임이 시작되도록 만들어져 있음! -> 게임 시작 기능!
    //1. 1p / 2p 시작에 따른 구분 및 각개 다르도록 구현!
    //2. 1에 따른 자잘자잘한, 기능들 손보기!
    public void GameStart(int playerNum)
    {
        //이 함수가 진행 되기 전에는, 게임이 시작되지 않으며,
        //함수가 최초 1회 실행 되었을때 게임 시작!
        //해당 함수가 제한적으로 불러와질 수 있도록, 갈무리!
        isStart = true;
        //버튼을 통하여 기능 구현 : 게임 시작 버튼!
        startPanal.SetActive(false);
        //1p와 2p간을 구분하는 과정!
        // - 게임 시작할때, 플레이어가 한명만 있냐, 둘 다 있냐.
        //1. 1pMode일땐 2p오브젝트를 소환 안하고, 2pMode일땐, 2p오브젝트를 소환한다!
        //2. 1pMode일땐 2p오브젝트를 파괴하고, 2pMode일땐, 2p오브젝트를 파괴하지 않는다!
        //3. 그냥 둘 다 소환하던지, 하나만 소환하던지 하자! << 
        //준비물 : 1p 2p 프리펩, 1p2p를 소환할 장소!

        switch (playerNum)
        {
            case 1:
                {
                    GameObject p1 = Instantiate(p1prefab, p1spot.position, p1spot.rotation);//p1
                    playerTrList.Add(p1.transform);
                    break;
                }
            case 2:
                {
                    GameObject p1 = Instantiate(p1prefab, p1spot.position, p1spot.rotation);//p1
                    GameObject p2 = Instantiate(p2prefab, p2spot.position, p2spot.rotation);//p2
                    playerTrList.Add(p1.transform);
                    playerTrList.Add(p2.transform);
                    break;
                }
        }
    }


    void TimerCheck()
    {
        //시작 전 타이머, 타임 체크!
        //1. 게임 시작시, 3, 2, 1초 사출 후 시작! 텍스트 띄우기!
        //2. 제한시간 관리 하기! (30초 -> 0초)
        //3. 시간이 끝났을 때 끝남을 알리기!

        timer += Time.deltaTime;
        //3 : 0~1초
        //2 : 1~2초
        //1 : 2~3초
        //게임시작 : 3~4초
        //4~ : 텍스트 없앰!
        if (timer < 1)
        {
            showText.text = "3";
        }
        else if (timer < 2)
        {
            showText.text = "2";
        }
        else if (timer < 3)
        {
            showText.text = "1";
        }
        else if (timer < 4)
        {
            showText.text = "시작!";
            isGame = true;
        }
        else
        {
            showText.text = "";
        }

        if (isGame == false) return;

        leftTimeText.text = leftTime.ToString("00.00");
        scoreText.text = score.ToString();
        //제한시간 관리 하기! (30초 -> 0초)
        //처음 시작할 때 제한 시간만큼 변수값을 지정 해 놓고, 게임이 시작이 되었을 때, 제한 시간에서 흐르는 시간을 빼준다!
        if (timer >= 3)
        {
            //시간이 흐르는 것을 관리!
            leftTime = leftTime - Time.deltaTime;
            if(leftTime <= 0)
            {
                leftTime = 0f;
                isGame = false;
                EndGame();
            }
        }
    }

    void SpawnMonster()
    {
        if (isGame == false) return;
        //일정 시간마다, 몬스터를 소환하며, 필드에 있는 몬스터가 일정 이상이 되었을 시에, 몬스터 생성을 막음!
        //1. 일정 시간마다 몬스터를 소환할 타이머

        //2. 몬스터 갯수 체크
        //몬스터 갯수를 체크하는 방법
        //1. 씬 상의 몬스터 갯수를 실시간으로 추적 : FindObjectsOfType => 무거움!
        //2. 생성 및 삭제가 진행 될때만, 몬스터의 수를 추적! => 가벼움!

        //일정 시간(1초)마다 몬스터를 소환할 타이머 : 전용 타이머 , if문을 통한 몬스터 생성 및 타이머 초기화
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= 1f)
        {
            //몬스터 소환!
            //몬스터가 특정 위치에 나오는게 아닌, 지정해 둔 랜덤한 위치에 몬스터를 소환!
            //몬스터 원본 프리펩이 필요할 것이며, 랜덤한 위치를 잡아둔 오브젝트(트랜스폼)가 필요!!

            spawnTimer = 0f;

            if (monsterNum >= monsterMaxnum) return;

            int num = Random.Range(0, spawnSpots.Length);//(x,y) : x ~ y-1의 정수중에 하나의 정수를 랜덤하게 받아옴!
            var monclone = Instantiate(monsterPrefab, spawnSpots[num].position, spawnSpots[num].rotation);
            monclone.GetComponent<Enemy>().SetDestination(playerTrList);
            //monsterNum = monsterNum + 1;
            //monsterNum += 1;
            monsterNum++;
        }
    }

    void EndGame()
    {
        //남은시간이 0이 되었을 때, 실행!
        //1. 유저가 움직이면 안된다! <- 처음 시작 카운트 할때 움직임 막을 때 같이 구현!
        //2. 게임 종료 메시지가 나오며, 1초 뒤에 점수가 나온다! <- 점수는 점수책정코드를 구현 전까진 0으로 적어둔다!
        //3. Enemy들의 움직임을 멈춘다! : NavMeshAgent / 그냥 삭제! / . . . . .

        endText.text = "게임 종료!";
        //유니티 상에서 시간 지연을 구현할 수 있는 방법 3가지 : update , 코루틴 , [Invoke]
        Invoke("ShowScore", 1f);


        //Enemy들의 움직임을 멈춘다!
        //1.모든 Enemy들에게 접근!
        //2.접근한 Enemy들에서 NavMeshAgent컴포넌트에 접근 - 삭제!
        Enemy[] enemys = FindObjectsOfType<Enemy>();
        foreach(Enemy e in enemys)
        {
            e.GetComponent<NavMeshAgent>().enabled = false;
            Destroy(e.GetComponent<NavMeshAgent>().gameObject);
        }


        Bullet[] bullets = FindObjectsOfType<Bullet>();
        foreach (Bullet b in bullets)
        {
            Destroy(b.gameObject);
        }
    }

    void ShowScore()
    {
        //endText.text = "최종 점수는 0점입니다!";
        //endText.text = "최종 점수는" + score + "점입니다!";
        endText.text = $"최종 점수는 {score}점입니다!";
    }

    public void CountScore()
    {
        score += scorePer; 
    }

}

