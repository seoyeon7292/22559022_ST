using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    public float spd = 1.0f;
    Vector3 direct = Vector3.down;

    public GameObject prefabsExplosion;

    private void Start()
    {
        int rndNum = Random.Range(0, 10);

        //==============
        //30퍼 확률
        //==============
        if(rndNum % 3 == 0)
        {
            GameObject target = GameObject.Find("Player");
            direct = target.transform.position - transform.position;
            direct.Normalize();
        }
    }

    private void Update()
    {
        transform.position = transform.position + direct * spd * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        // 몬스터끼리 겹치면 서로 터지며 연쇄 폭발함 → 다른 Monster 충돌은 무시
        if (collision.gameObject.GetComponent<Monster>() != null)
            return;

        GameObject other = collision.gameObject;
        Transform otherRoot = other.transform.root;

        if (prefabsExplosion != null)
        {
            GameObject explosionObj = Instantiate(prefabsExplosion);
            explosionObj.transform.position = transform.position;
        }

        // 벽·환경 등은 파괴하지 않음 (이전에는 Destroy(collision.gameObject)로 벽까지 삭제됨)
        Bullet bullet = other.GetComponentInParent<Bullet>();
        if (bullet != null)
            Destroy(bullet.gameObject);
        else if (otherRoot.name == "Player")
            Destroy(otherRoot.gameObject);

        Destroy(gameObject);
    }

}
