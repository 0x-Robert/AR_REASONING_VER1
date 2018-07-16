
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConTower : MonoBehaviour
{

    public float latitude = 0;
    public float longitude = 0;



    public GoogleMap googleMap = null;//위치 주소값 



    void Start()
    {
        StartCoroutine("ConTowerPos");
    }


    public IEnumerator ConTowerPos()
    {




        yield return new WaitForSeconds(1);
        float slatitude = googleMap.centerLocation.latitude; //자신의 위치를 구글맵으로 불러오는 공식 위도
        float slongitude = googleMap.centerLocation.longitude;  //자신의 위치를 구글맵으로 불러오는 공식 경도
        double distance = DistanceManager.Distance(slatitude, slongitude, latitude, longitude, 'K') * 1000;

        if (distance < 1)
        {

        }
        if (distance > 1)
        {

        }

    }









}
