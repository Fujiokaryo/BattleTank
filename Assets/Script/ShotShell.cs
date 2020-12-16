using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotShell : MonoBehaviour
{
    public float shotSpeed;

    //privateの状態でもInspector上から設定できるようにする
    [SerializeField]
    private GameObject shellPrefab;

    [SerializeField]
    private AudioClip shotSound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //砲弾のプレハブを実体化（インスタンス化）する
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);

            //砲弾についているrigidbodyにアクセスする
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();

            //forward(青軸=Z軸)の方向に力を加える
            shellRb.AddForce(transform.forward * shotSpeed);

            //発射した砲弾を3秒後に破壊する（不要になった砲弾はメモリ上から削除すること
            Destroy(shell, 3.0f);

            //砲弾の発射音をだす
            AudioSource.PlayClipAtPoint(shotSound, transform.position);
        }
    }
}
