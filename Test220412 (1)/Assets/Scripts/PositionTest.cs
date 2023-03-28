using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTest : MonoBehaviour
{
    //이 스크립트가 들어있는 오브젝트가 외부에서 지정해준 좌표대로 일정 거리만큼 번갈아가면서 이동하는 스크립트

    public enum XYZ
    {
        x,
        y,
        z    
    }
    public XYZ xyz;
    int dir = 1;
    public float maxdistance;

    private void Update()
    {
        PositionMove();
    }

    void PositionMove()
    {
        //1. 이 스크립트가 들어있는 오브젝트를 움직이기 위해서 트랜스폼에 접근할 수 있는 변수만들기!
        //2. 외부에서 지정해준 좌표를 받아온다!(x,y,z);
        //2-1. 외부에서 지정된 좌표만 받아올 수 있는 형식을 만들어 준다!
        //3. 어느정도의 거리까지 왕복 운동 할것인지 정하기 위해 외부에서 값을 받아온다!
        //4. 받아온 축에 따라 받아온 거리만큼 왕복 운동!

        Transform tr = this.gameObject.transform;

        switch (xyz)
        {
            case XYZ.x:
                {
                    if(tr.position.x > maxdistance)
                    {
                        tr.position = new Vector3(maxdistance, tr.position.y, tr.position.z);
                        dir = -dir;                        
                    }
                    else if(tr.position.x < -maxdistance)
                    {
                        tr.position = new Vector3(-maxdistance, tr.position.y, tr.position.z);
                        dir = -dir;
                    }
                    else
                    {
                        tr.position = new Vector3(tr.position.x + dir * Time.deltaTime, tr.position.y, tr.position.z);
                    }
                    break;
                }
            case XYZ.y:
                {
                    if (tr.position.y > maxdistance)
                    {
                        tr.position = new Vector3(tr.position.x, maxdistance, tr.position.z);
                        dir = -dir;
                    }
                    else if(tr.position.y < -maxdistance)
                    {
                        tr.position = new Vector3(tr.position.x, -maxdistance, tr.position.z);
                        dir = -dir;
                    }
                    else
                    {
                        tr.position = new Vector3(tr.position.x , tr.position.y + dir * Time.deltaTime, tr.position.z);
                    }
                    break;
                }
            case XYZ.z:
                {
                    if (tr.position.z > maxdistance)
                    {
                        tr.position = new Vector3(tr.position.x, tr.position.y, maxdistance);
                        dir = -dir;
                    }
                    else if(tr.position.z < -maxdistance)
                    {
                        tr.position = new Vector3(tr.position.y, tr.position.y, - maxdistance);
                        dir = -dir;
                    }
                    else
                    {
                        tr.position = new Vector3(tr.position.x , tr.position.y, tr.position.z + dir * Time.deltaTime);
                    }
                    break;
                }
        }




    }

}
