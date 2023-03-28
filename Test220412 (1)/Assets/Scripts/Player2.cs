using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    //1. 이동기능
    //2. 점프기능 ctrl
    //3. 총알쏘기 기능 shift
    //4. 체력을 맞았을 때, 체력이 닳는 기능

    public float speed;
    public float anglespeed;
    public GameObject prefabbullet;
    public int hp;
    private void Start()
    {
        hp = 100;
        if (_gameManager == null)
        {
            _gameManager = FindObjectOfType<GameManager>(); //씬 상에서 존재하는 컴포넌트에 접근하여 그 컴포넌트를 받아오는 함수 : 굉장히 무겁다!
        }
        if (_gameManagerAI == null)
        {
            _gameManagerAI = FindObjectOfType<GameManagerAI>(); //씬 상에서 존재하는 컴포넌트에 접근하여 그 컴포넌트를 받아오는 함수 : 굉장히 무겁다!
        }
    }

    public GameManager _gameManager;
    public GameManagerAI _gameManagerAI;

    private void Update()
    {

        if (_gameManagerAI.isGame == false) return;
        PlayerMove();

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Shoot();
        }
        //넘어짐 방지 코드 작성
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);


    }

    public void PlayerMove()
    {
        //이동과 회전 : 화살표!

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-transform.forward * Time.deltaTime * speed, Space.World);
        }

        //회전
        //둘 다 누르면 회전 안함
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            //회전 안함
        }
        else if (Input.GetKey(KeyCode.LeftArrow))//좌회전 , 음의 y rotate값
        {
            //rotate : 이 함수가 호출 될 때마다 정해진 Vecter3값을 Rotation X,Y,Z에 더해준다!
            transform.Rotate(new Vector3(0, -anglespeed * Time.deltaTime, 0));

        }
        else if (Input.GetKey(KeyCode.RightArrow))//우회전 , 양의 y rotate값
        {
            transform.Rotate(new Vector3(0, anglespeed * Time.deltaTime, 0));
        }
    }

    void Jump()
    {
        Rigidbody rg = this.gameObject.GetComponent<Rigidbody>();
        rg.AddForce(transform.up * 800f);

        //N단점프 막는방법이 뭔가요?
        //1. 바닥에 닿아있을때 True/False가 나오는 변수를 생성한다 (OnCollisionEnter/Stay , Jump)
        //2. 특정 고도 미만(Y좌표)일때만 Jump가 실행이 되도록 세팅!(transform.Position.y)
    }

    void Shoot()
    {
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
            _gameManager.GameEnd("player1");
            Destroy(this.gameObject);
        }
    }
}
