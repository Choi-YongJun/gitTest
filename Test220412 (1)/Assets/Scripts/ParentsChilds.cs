using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentsChilds : MonoBehaviour
{
    //Parents : 부모
    //Child : 자식
    //transfrom적으로 Child는 Parent에 귀속된다!
    //Parent의 transform적 요소(position , rotation , scale)에
    //Child는 영향을 받습니다!

    //Child의 좌표의 원점은 부모의 좌표가 된다!
    //Child를 스크립트나 하이라키에서 수동으로 뺀다면, 원래 존재하던 좌표에서 이동한 부모의 좌표에 따라서 계산되서 적용됨

    private void Start()
    {
        
    }
    //이 스크립트가 들어있는 오브젝트의 parent를 없애버리는 / 밖에서 받아온 오브젝트로 지정하는 스크립트를 생성!
    //버튼을 누를때 마다 parent가 바뀜!

    public Transform tr;

    public void OnClickParent()
    {
        //1. 밖에서 트랜스폼 변수를 통해 트랜스폼을 받아온다!
        //2. 받아온 트랜스폼을 부모로 지정한다
        //3. 받아온 트랜스폼이 비어있을때, 부모를 비운다!
        if(tr != null)
        {
            this.gameObject.transform.parent = tr;
        }
        else if(tr == null)
        {
            this.gameObject.transform.parent = null;
        }
    }


}
