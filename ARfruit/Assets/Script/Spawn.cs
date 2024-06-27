using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform[] pos;
    public GameObject[] prefab;
    public Camera MainCamera;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(WaitAndSpawn());
        //coroutine은 IEnumerator와 같이 쓴다
        //coroutine은 동시에 돌아가게 한ㄷ
    }
    IEnumerator WaitAndSpawn()
    {   // 별도로 돌아가는 루틴
        while(true)
        {
            float waitTime = Random.Range(2.0f, 4.0f);
            yield return new WaitForSeconds(waitTime);
            //1초 있다가 waitTime을 수행해라// WaitForSeconds는 타

            for(int i = 0; i < 3; i++)
            {
                int iPrefab = Random.Range(0, prefab.Length);
                int iPos = Random.Range(0, pos.Length);

                GameObject o = Instantiate(prefab[iPrefab], pos[iPos].position, Quaternion.Euler(0, 180, 0));
            
                Destroy(o, 10f);

                Rigidbody rb = o.GetComponent<Rigidbody>();
                float power = 0.5f;
                //rb.AddForce(Vector3.up * Random.Range(4.0f, 10.0f), ForceMode.VelocityChange);
                rb.AddForce(Vector3.up * power, ForceMode.VelocityChange);
            }
            audio.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
