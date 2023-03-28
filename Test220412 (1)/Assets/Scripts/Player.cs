using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //TransForm을 통한 이동과 회전을 배웠다~ => 유저가 조작하여 이동이 되는 기능을 만들어 보자!


    public int hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        if(_gameManager == null)
        {
            _gameManager = FindObjectOfType<GameManager>(); //씬 상에서 존재하는 컴포넌트에 접근하여 그 컴포넌트를 받아오는 함수 : 굉장히 무겁다!
        }
        if (_gameManagerAI == null)
        {
            _gameManagerAI = FindObjectOfType<GameManagerAI>(); //씬 상에서 존재하는 컴포넌트에 접근하여 그 컴포넌트를 받아오는 함수 : 굉장히 무겁다!
        }
    }
    public float speed = 1f;
    public float anglespeed = 50f;
    public GameManager _gameManager;
    public GameManagerAI _gameManagerAI;
    // Update is called once per frame
    void Update()
    {
        //가림막!
        //if (_gameManager.isGame == false) return; //해당 조건일 때, 함수를 끝내라!
        if (_gameManagerAI.isGame == false) return;

        //PlayerMove();
        //PlayerRotateMove();
        PlayerRotateMoveV2();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Shoot();
        }
        //넘어짐 방지 코드 작성
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);


    }

    void PlayerMove()
    {
        //Input.GetKey : 특정 키를 누르고 있는 동안. 눌려있냐, 안눌려있냐.(ex) 이동)
        //Input.GetKeyDown : 특정 키가 눌린 순간. 딱 한번만 true를 반환.(ex)총알 발사.)
        //Input.GetKeyUp : 특정 키가 떼어진 순간. 딱 한번만 true를 반환.

        //오브젝트를 움직이는 4가지 방법
        //1. Transrate
        //2. MoveToward
        //3. Lerp , Slerp
        //4. NevMeshAgent의 목적지 설정

        //유저가 키(W,A,S,D)를 눌렀을 때, 어느 키느냐에 따라서 방향을 잡고 이동할 수 있는 스크립트!

        //전진! : W키를 누르고 있는 상태에서 진행!
        //1. W키를 눌렀는지 판단!(if ,switch 같은 조건문 사용)
        //2. 만약 W키를 누르고 있다면, 이 스크립트가 들어가 있는 오브젝트가 전진하도록 만든다!
        //2-1. 전진(앞으로 이동)은 이동이기 때문에 Transform이 필요.(이 스크립트가 들어있는 오브젝트의 트랜스폼에 접근이 필요!)
        //2-2. 트랜스폼을 통하여 특정 속도로! 앞쪽 방향으로 이동!

        if (Input.GetKey(KeyCode.W))//뜻 : 입력을 받아와서 키가 눌렸는지, 안눌렸는지 판단할건데, 그 키는 W키 입니다. 눌려져 있는 상태인가요?
        {
            Transform tr = this.gameObject.transform;
            //tr.position = new Vector3(tr.position.x + speed * Time.deltaTime , tr.position.y,tr.position.z);
            tr.Translate(tr.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))//왼쪽 : 오른쪽의 반대
        {
            Transform tr = this.gameObject.transform;
            tr.Translate(-tr.right * Time.deltaTime * speed);

        }
        if (Input.GetKey(KeyCode.S))//뒤쪽 : 앞쪽의 반대
        {
            Transform tr = this.gameObject.transform;
            tr.Translate(-tr.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Transform tr = this.gameObject.transform;
            tr.Translate(tr.right * Time.deltaTime * speed);
        }
    }

    void PlayerRotateMove()
    {
        //플레이어가 이동하고자 하는 방향으로 회전하면서 이동하는건, 두가지의 방법이 있다.
        //플레이어는 무조건 전진, 누른 방향키에 따라 회전.
        //1. 이동키가 눌린 상태에선 무조건 전진
        //2. 누른 방향키에 따라 맞는 방향으로 회전
        //Slerp / Lerp
        //선형보간 , 보간
        //부드러운 이동 및 회전에 쓰인다!(Quaternion , Vecter3)

        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), 0.01f);
            transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.A))//왼쪽 : 음의 y Rotate방향,
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, -90f, 0f), 0.01f);
            transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 180f, 0f), 0.01f);
            transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.D))//오른쪽 : 양의 y Rotate방향
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 90f, 0f), 0.01f);
            transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        }
    }

    void PlayerRotateMoveV2()
    {
        //1. 앞키와 뒤키는 전진과 후진
        //2. 좌우키는 좌우 방향으로 회전
        //여러 방향키를 눌렀을 때 어떻게 하는가?
        //전진과 후진은 둘 다 누르면 정지/후진우선/전진우선

        /* 둘 다 누르면 정지 코드
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        { 
            //정지
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(- transform.forward * Time.deltaTime * speed, Space.World);
        }
        */

        //후진우선
        /*
    if (Input.GetKey(KeyCode.S))
    {
        transform.Translate( - transform.forward * Time.deltaTime * speed, Space.World);
    }
    else if (Input.GetKey(KeyCode.W))
    {
        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
    }
        */

        //전진우선
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-transform.forward * Time.deltaTime * speed, Space.World);
        }

        //회전
        //둘 다 누르면 회전 안함
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            //회전 안함
        }
        else if (Input.GetKey(KeyCode.A))//좌회전 , 음의 y rotate값
        {
            //rotate : 이 함수가 호출 될 때마다 정해진 Vecter3값을 Rotation X,Y,Z에 더해준다!
            transform.Rotate(new Vector3(0, -anglespeed * Time.deltaTime, 0));

        }
        else if (Input.GetKey(KeyCode.D))//우회전 , 양의 y rotate값
        {
            transform.Rotate(new Vector3(0, anglespeed * Time.deltaTime, 0));
        }

    }

    void Jump()
    {
        //Rigidbody : 물체의 질량과 힘을 관리하는 컴포넌트
        //Rigidbody가 없다면, 중력도 받지 못하고, 힘도 받지 못한다!

        //Jump : 위로 약간 떠오른 다음에, 다시 내려오는 동작!
        //위로 약간 떠오른다 : 위로 힘을 받았다!
        //다시 내려온다 : 이 물체는 중력을 받는다!

        Rigidbody rg = this.gameObject.GetComponent<Rigidbody>();

        rg.AddForce(transform.up * 800f);
    }

    public GameObject prefabbullet;

    void Shoot()
    {
        //총알이 발사되는 과정
        //1. 총알이 만들어진다!
        //1-1. 총알이 만들어지는 위치가 발사하는 사람에서 발사 되어야 한다! - 총알의 생성 위치는 발사자.
        //2. 총알을 발사하고 싶은 방향을 받아온다!(플레이어의 전면부!)
        //3. 총알을 발사하고 싶은 방향으로 강한 힘을 준다!(RigidBody)

        //Prefab , Instantiate
        //Prefab : 거푸집 - 내가 만들 오브젝트의 원본!
        //Instantiate : Prefab을 기반으로 복제품을 만들어 Scene에 소환한다!
        GameObject bulletClone = Instantiate(prefabbullet);
        bulletClone.transform.position = transform.position;
        //transform.forward;
        Rigidbody rigidbody = bulletClone.GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * 600f);
    }

    public void Damage()
    {
        //데미지를 입으면, 일정량의 체력이 깎임!(30!)
        //체력이 음이 되면, 사망!(Destory)

        hp = hp - 30;
        //hp -= 30;
        if (hp < 0)
        {
            _gameManager.GameEnd("player2");
            Destroy(this.gameObject);
        }
    }
}
