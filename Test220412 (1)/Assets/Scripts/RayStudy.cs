using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayStudy : MonoBehaviour
{
    //Ray : (RayCastHit을 통해서 선에 맞닿은 정보들을 받아올 수 있는)선
    //Ray의 필요성분 : 시작점 , 진행방향(Vector3)

    //이 스크립트가 들어있는 오브젝트의 앞쪽 방향으로 나아가는 Ray를 만들고
    //이를 DrawRay를 통해 그려보자!
    //1. 이 스크립트가 들어있는 오브젝트의 위치를 가져온다!
    //2. 이 스크립트가 들어있는 오브젝트의 앞쪽방향을 가져온다!
    //3. 1과 2를 통해서 Ray를 만든다!
    //4. DrawRay를 통해서 직접 그려보자!
    void RayTest()
    {
        Vector3 orig = transform.position;
        Vector3 dir = transform.forward;

        Ray ray = new Ray(orig, dir * 20f);
        //print("");
        //Debug.Log("");
        Debug.DrawRay(ray.origin, ray.direction * 20f);

        RaycastHit raycastHit;

        //Raycast : Ray를 유니티 공간안에 던지는것!
        //if를 왜 쓰는가? : 던진 Ray가 콜라이더에 닿았는지, 안닿았는지, 확인이 필요하기 때문에, 쓰인다!
        //out raycastHit : 던진 Ray에 콜라이더가 닿았다면, 그 콜라이더에 대한 정보를 raycastHit으로 받아와야 하기 때문에 쓰인다!
        if (Physics.Raycast(ray, out raycastHit))
        {
            Debug.Log(raycastHit.collider.name);
        }
    }

    //RayCast의 특징이자 단점 : Ray의 시작점에서부터 Ray의 방향으로 발사한 Ray를통해
    //Raycasthit을 받아오는것이 raycast! -> 발사한 Ray의 처음 맞닿는 물체만 Raycasthit으로 받아옴!

    //RaycastAll : 발사한 Ray에 닿는 모든 Collider를 받아옴!

    void RayCastAllTest()
    {
        Vector3 orig = transform.position;
        Vector3 dir = transform.forward;

        Ray ray = new Ray(orig, dir * 20f);
        //print("");
        //Debug.Log("");
        Debug.DrawRay(ray.origin, ray.direction * 20f);

        RaycastHit[] hits =  Physics.RaycastAll(ray , 20f);
        if(hits.Length != 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                Debug.Log(hits[i].collider.name);
            }
        }
    }

    private void Update()
    {
        //RayTest();
        RayCastAllTest();
    }

}
