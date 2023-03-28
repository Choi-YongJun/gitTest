using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //매니저를 쓰면 어떤게 좋은가? : 정보가 정렬이 잘됩니다.  

    public Image p1hpbar;
    public Image p2hpbar;

    public Text showText;
    public Text endShowText;

    public bool isInit; //플레이 부터, 게임 시작 버튼을 누르기 전까지 update함수 실행을 막기 위해 사용!
    public bool isGame; //조작 가능하면 true , 조작 불가능할때 false!
    public float timer;

    public GameObject p1prefab;
    public GameObject p2prefab;

    public GameObject p1spot;
    public GameObject p2spot;

    public GameObject startButton;
    public GameObject reStartbutton;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        //DontDestroyOnLoad : 씬이 전환되도, 오브젝트가 파괴되지 않음! -> 오브젝트 안에 있는 정보들의 보존이 가능하다!
    }

    private void Start()
    {
        startButton.SetActive(true);
        reStartbutton.SetActive(false);
        isGame = false;
        isInit = false;
        timer = 0f;
    }

    private void Update()
    {
        if (isInit == false) return;   //해당 조건일 때, 함수를 끝내라!
        HPCheck();
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

    }
    //체력을 UI에 띄우는것!
    //1. update를 사용하여 실시간으로 받아온다!
    //2. 함수를 연결하여 체력이 깎일때만 받아온다!

    //게임 시작과, 게임 종료!
    //게임 시작
    // - 게임 시작 하면, 3,2,1 카운트 하는 기능 삽입
    // - 카운트가 끝나면 게임 시작 텍스트 보이고 1초뒤 삭제!
    // - 카운트 중엔 조작 불가!

    //게임 종료
    // - 특정 플레이어가 죽었을 때, 조작을 불허
    // - 게임 종료 메시지 띄움!
    // - 1초뒤에 어떤 플레이어가 이겼는지, 띄움!

    //게임 시작 버튼도 생성!


    //정보들 정리(심화과정)


    public Player _player;
    public Player2 _player2;

    void HPCheck()
    {
        //두 플레이어의 체력을 받아와서 UI에 이미지로 띄운다!
        //0. 이 함수는 반복함수(update / fixedupdate)에서 사용될 예정으로 제작!
        //1. player1과 player2의 스크립트(player , player2)를 받아온다!
        //2. 플레이어들의 스크립트에서 hp정보를 받아온다!
        //3. 받아온 정보를 바탕으로, 이미지의 fillamount(0이 최소 1이 최대)를 조절한다

        int p1hp = _player.hp;
        int p2hp = _player2.hp;

        p1hpbar.fillAmount = p1hp / 100f; //0과 1사이의 비율값으로 바꾸는 방법은 , 현재값/최대값을 한다!
        p2hpbar.fillAmount = p2hp / 100f;
    }

    //게임 종료 되었을 때, 실행할 함수
    //게임 종료 : 두 플레이어중 한명의 체력이 0이 되어 사라짐!
    //1. 게임 조작이 불허해야한다
    //2. 텍스트 : 게임 종료! -(1초)> 이긴 플레이어가 누군지 텍스트에 나오도록!

    //두 플레이어 중 한명의 체력이 0이 된것을 알 수 있는 3가지 방법
    //1. 두 플레이어의 체력을 모니터링 -> 한쪽이 0이 될 때 게임 종료 함수 실행
    //2. 두 플레이어의 스크립트/오브젝트 모니터링 -> 한쪽이 사라졌을때(null일때), 게임 종료 함수를 실행
    //3. 두 플레이어중 한명의 체력이 0이 되었을 때, 그 플레이어에서 게임 종료 함수를 실행 < 최적화 제일 좋음!
    public void GameEnd(string winPlayerName)
    {
        isGame = false;
        StartCoroutine(GameEndAsync(winPlayerName));
        return;
    }
    //유니티 스크립트에서 시간적 딜레이를 넣어줄 수 있는 3가지 방법
    //1. Update(fixedupdate / LateUpdate) : Time.DeltaTime
    //2. Coroutine : IEnumerator를 통해서 선언이 가능하며, 독자적인 진행을 맡는다.
    //(쓰기 편하지만 자주쓰면 안좋음! / 서버연결이나 다운로드)
    //3. Invoke : 함수를 일정 시간 뒤에 실행하도록 예약을 걸어둘 수 있는 기능
    //인자가 없어야 한다~!

    public IEnumerator GameEndAsync(string winPlayerName)
    {
        yield return 0;
        endShowText.text = "게임 종료!";

        //1초 딜레이
        yield return new WaitForSeconds(1f);

        //승자를 구분하여 알맞는 텍스트 출력
        if(winPlayerName == "player1")
        {
            endShowText.text = "플레이어 1 승리!";
        }
        else if(winPlayerName == "player2")
        {
            endShowText.text = "플레이어 2 승리!";
        }

        reStartbutton.SetActive(true);
    }
        
    //게임 시작
    //게임 종료 후 재시작

    public void StartGame()
    {
        endShowText.text = "";
        startButton.SetActive(false);
        reStartbutton.SetActive(false);
        //게임 시작 및 재시작에 활용할 함수
        //게임 시작 초기에 세팅해 줘야 할 정보들을 모두 세팅! (hp , 플레이어들 위치)
        isInit = true;
        timer = 0;
        //플레이어 재세팅! : Instantate!
        if (_player == null)//플레이어 1이 없다!
        {
            GameObject p = Instantiate(p1prefab, p1spot.transform.position , p1spot.transform.rotation);
            _player = p.GetComponent<Player>();
        }

        if (_player2 == null)//플레이어 2이 없다!
        {
            GameObject p = Instantiate(p2prefab, p2spot.transform.position, p2spot.transform.rotation);
            _player2 = p.GetComponent<Player2>();
        }

        _player.transform.position = p1spot.transform.position;
        _player.transform.rotation = p1spot.transform.rotation;
        _player2.transform.position = p2spot.transform.position;
        _player2.transform.rotation = p2spot.transform.rotation;


        _player.hp = 100;
        _player2.hp = 100;

    }
}
