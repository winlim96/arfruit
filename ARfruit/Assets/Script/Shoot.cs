using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public GameObject camera;
    public GameObject prefab;
    public Text scoreText;
    private int score = 0;
    public GameObject Clear;
    public GameObject gameover;
    public GameObject SpawnManager;
    public GameObject replay;
    // Start is called before the first frame update
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        Clear.SetActive(false);
        gameover.SetActive(false);
        replay.SetActive(false);
    }

    public void Fire()
    {
        RaycastHit hit;

        //raycast는 physics클래스 안에 들어있는 함수
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {                   //카메라 시작점	                카메라 보는방향            //out은 결과값을 돌려받을때 쓰는 키워드// hit가 충돌한 결과값을 담고있다
            if(hit.transform.tag == "Sweet" || hit.transform.tag == "Donut")
            {
                Destroy(hit.transform.gameObject);
                Instantiate(prefab, hit.point, Quaternion.LookRotation(hit.normal));
                                                                                //그 벡터방향으로 회전하라 
                audio.Play();

                if (hit.transform.tag == "Donut")
                {
                    score -= 2;
                    scoreText.text = "Point : " + score.ToString();
                }
                else if (hit.transform.tag == "Sweet")
                {
                    score += 5;
                    scoreText.text = "Point : " + score.ToString();
                }
            }
        }

        if (score > 50)
        {
            Clear.SetActive(true);
            SpawnManager.SetActive(false);
            replay.SetActive(true);
        }
        else if (score <= 0) 
        {
            gameover.SetActive(true);
            SpawnManager.SetActive(false);
            replay.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
