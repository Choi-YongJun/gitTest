using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformAbout : MonoBehaviour
{
    //Transform
    //오브젝트의 이동과 회전, 크기, 부모를 관리하는 요소
    public Transform tr;

    private void Start()
    {
        dir = 1;
        tr = transform;
    }

    //position
    //X , Y , Z로 구성되어, 씬 안에 있는 게임오브젝트의 위치를 정해주는 값.
    //변수 : Vector3 (Vecter2 - z값을 0으로 생략하면 가능)
    //Vector3 : Float값 3개를 묶어서 활용할 수 있는 자료형.

    private void Update()
    {
        //MoveRepeat();
        RotationTest();
    }

    //변수 만들 목록
    //1. 이 친구가 양의 방향으로 이동하는중인지, 음의 방향으로 이동하는 중인지 기억해 놓을 변수(방향)
    //2. 속도는 얼마나 움직일 것인지
    int dir;
    public float speed;


    public void MoveRepeat()
    {
        //해당 스크립트가 들어간 오브젝트가 원점을 기준으로, x값이 5에서 -5만큼 반복하여 움직이는 코드
        //1. 해당 스크립트가 들어간 오브젝트를 접근
        //2. 오브젝트의 움직임을 관리할 수 있는 transform에 접근
        //3. transform을 통해서 position값의 x값을 이동
        //4. position의 x값이 5보다 크거나 -5보다 작다면 반대 방향으로 이동.

        this.gameObject.transform.position
            = new Vector3(
                this.gameObject.transform.position.x + dir * speed * Time.deltaTime,
            this.gameObject.transform.position.y,
            this.gameObject.transform.position.z - dir * speed * Time.deltaTime);

        if (this.gameObject.transform.position.x > 5)
        {
            this.gameObject.transform.position 
                = new Vector3(5, transform.position.y, -5);
            dir = -dir;
        }
        else if (this.gameObject.transform.position.x < -5)
        {
            this.gameObject.transform.position 
                = new Vector3(-5, transform.position.y, 5);
            dir = -dir;
        }

    }

    public Transform rotateTr;

    public void RotationTest()
    {
        //Rotation : 오브젝트의 회전을 담당!
        //변수형 : Quaternion! (x,y,z,w) : 짐벌락 때문! - 유니티는 씬에서 연산을 통해 짐벌락이 없게끔 조정해준다!
        //짐벌락 : 회전을 3가지 요소(Vecter3)로만 구성하여 회전하면, 회전에 관여하지 않는 요소가 생기거나, 또는 결과값은 같은데, 좌표가 다른 상황이 생길 수 있다!

        //Euler(오일러) : Quaternion형을 써야 하지만, 유니티 씬은 3요소를 통해 회전값을 지정하기 때문에, 유니티 내부에서 3요소를 통해 회전을 정할 수 있도록 만들어준 함수!
        //오일러의 용법!
        //rotateTr.rotation = Quaternion.Euler(0, 0, 0);

        //z방향 한방향으로 뱅글뱅글 도는 원통을 만들어 봅시다!
        rotateTr.rotation
            = Quaternion.Euler(rotateTr.rotation.eulerAngles.x,
            rotateTr.rotation.eulerAngles.y,
            rotateTr.rotation.eulerAngles.z + speed * Time.deltaTime);
    }

}
