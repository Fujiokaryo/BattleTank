using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    //エフェクトプレハブを入れるための箱を作る
    [SerializeField]
    private GameObject effectPrefab;

    [SerializeField]
    private GameObject effectPrefab2;
    public int objectHP;

    //ぶつかった瞬間に呼び出されるメソッド
    private void OnTriggerEnter(Collider other)
    {
        //ぶつかった相手のタグにShellという名前があったら（条件式
        if(other.CompareTag("Shell"))
        {
            //オブジェクトのHpを1ずつ減少させる
            objectHP -= 1;
            if(objectHP > 0)
            {
                //ぶつかってきたオブジェクトを破壊する
                Destroy(other.gameObject);

                //エフェクトを実体化（インスタンス化）する
                GameObject effect = Instantiate(effectPrefab, other.transform.position, Quaternion.identity);

                //エフェクトを2秒後に画面から消す
                Destroy(effect, 2.0f);
            }
            else
            {
                //ぶつかってきたオブジェクトを破壊する
                Destroy(other.gameObject);

                //もう1種類のエフェクトを発生させる
                GameObject effect2 = Instantiate(effectPrefab2, other.transform.position, Quaternion.identity);

                Destroy(effect2, 2.0f);

                //このスクリプトがついているオブジェクトを破壊する
                Destroy(this.gameObject);
            }
            

            
        }
    }

}
