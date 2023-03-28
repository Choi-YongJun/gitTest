using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //1. 성능상의 이유가 있으니, 생성되고, 10초 뒤에 삭제되도록 설정!
    //2. 만일 충돌(Trigger)된 상대가 적이라면, 데미지를 가함!

    //외부에서 설정하여, 누구의 총알인지 알 수 있게 만드는 enum
    public enum OwnerEnum
    {
        p1,
        p2
    }
    public OwnerEnum _ownerEnum;

    public float timer;
    private void Update()
    {
        timer = timer + Time.deltaTime;
        //timer += Time.deltaTime;
        if (timer > 10f)
        {
            Destroy(this.gameObject);
        }
    }

    //콜라이더 충돌시, 충돌된 콜라이더를 판별하는 방법(이름, 태그 , 컴포넌트여부 , 부모가 무엇인지?) : 태그를 통해서 구분해준다!

    private void OnTriggerEnter(Collider other)
    {
        //switch (_ownerEnum)
        //{
        //    case OwnerEnum.p1:
        //        {
        //            if (other.CompareTag("player2"))
        //            {
        //                other.GetComponent<Player2>().Damage();
        //                Destroy(this.gameObject);
        //            }
        //            break;
        //        }
        //    case OwnerEnum.p2:
        //        {
        //            if (other.CompareTag("player1"))
        //            {
        //                other.GetComponent<Player>().Damage();
        //                Destroy(this.gameObject);
        //            }
        //            break;
        //        }
        //}


        if (other.tag == "enemy")
        {
            other.GetComponent<Enemy>().Damage();
            Destroy(this.gameObject);
        }
    }
}
