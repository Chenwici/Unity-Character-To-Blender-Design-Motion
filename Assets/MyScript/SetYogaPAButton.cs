using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetYogaPAButton : MonoBehaviour
{
    public GameObject DollAnimator, AllPAButton, VIVE_Detecting;
    public bool PA_Detect_flag = true;
    public bool VIVE_DetectOK = false;
    public void Awake()
    {
        DollAnimator    = GameObject.Find("LiamAnim");
        AllPAButton     = GameObject.Find("AllPAButton");
        VIVE_Detecting  = GameObject.Find("VIVE_Detecting");
        VIVE_Detecting.SetActive(false);
    }
    public void StartRunPA()
    {
        AllPAButton.SetActive(false);
        StartCoroutine(PA_Detect(3));//執行趴下引導+循環確認是否有跟上動作
    }

    IEnumerator PA_Detect(int Cycle)
    {
        DollAnimator.GetComponent<Animator>().SetInteger("YogaPA", 1);//執行側姿
        yield return new WaitForSeconds(1);
        VIVE_Detecting.SetActive(true);//定位開啟圖示
        //▼▼▼▼▼定位檢測▼▼▼▼▼
        PA_Detect_flag = true;
        VIVE_DetectOK = false;
        yield return new WaitForSeconds(1);
        while (PA_Detect_flag)
        {
            if (VIVE_DetectOK == false)
            {
                print("VIVE檢測定位中...");
                yield return new WaitForSeconds(1);
            }
            else
            {
                print("VIVE定位完成!!!");
                VIVE_Detecting.SetActive(false);//定位關閉圖示
                PA_Detect_flag = false;
                yield return new WaitForSeconds(1);
            }
        }
        //▲▲▲▲▲定位檢測▲▲▲▲▲
        for (int i = 0; i < Cycle; i++)
        {
            DollAnimator.GetComponent<Animator>().SetInteger("YogaPA", 11);
            yield return new WaitForSeconds(2);
            DollAnimator.GetComponent<Animator>().SetInteger("YogaPA", 12);
            yield return new WaitForSeconds(2);
        }
        yield return new WaitForSeconds(1);
        DollAnimator.GetComponent<Animator>().SetInteger("YogaPA", 13);//換弓右腳+側姿
        yield return new WaitForSeconds(1);
        for (int i = 0; i < Cycle; i++)
        {
            DollAnimator.GetComponent<Animator>().SetInteger("YogaPA", 14);
            yield return new WaitForSeconds(2);
            DollAnimator.GetComponent<Animator>().SetInteger("YogaPA", 15);
            yield return new WaitForSeconds(2);
        }
        yield return new WaitForSeconds(1);
        DollAnimator.GetComponent<Animator>().SetInteger("YogaPA", 2);//換趴姿
        yield return new WaitForSeconds(1);
        //▼▼▼▼▼定位檢測▼▼▼▼▼
        VIVE_Detecting.SetActive(true);//定位開啟圖示
        PA_Detect_flag = true;
        VIVE_DetectOK = false;
        while (PA_Detect_flag)
        {
            if (VIVE_DetectOK == false)
            {
                print("VIVE檢測定位中...");
                yield return new WaitForSeconds(1);
            }
            else
            {
                print("VIVE定位完成!!!");
                VIVE_Detecting.SetActive(false);//定位關閉圖示
                PA_Detect_flag = false;
                yield return new WaitForSeconds(1);
            }
        }
        //▲▲▲▲▲定位檢測▲▲▲▲▲
        for (int i = 0; i < Cycle; i++)
        {
            DollAnimator.GetComponent<Animator>().SetInteger("YogaPA", 21);
            yield return new WaitForSeconds(2);
            DollAnimator.GetComponent<Animator>().SetInteger("YogaPA", 22);
            yield return new WaitForSeconds(2);
        }
        yield return new WaitForSeconds(2);
        for (int i = 0; i < Cycle; i++)
        {
            DollAnimator.GetComponent<Animator>().SetInteger("YogaPA", 23);
            yield return new WaitForSeconds(2);
            DollAnimator.GetComponent<Animator>().SetInteger("YogaPA", 24);
            yield return new WaitForSeconds(2);
        }
        yield return new WaitForSeconds(1);
        DollAnimator.GetComponent<Animator>().SetInteger("YogaPA", 3);//換趴姿2(揚頭版)
        yield return new WaitForSeconds(1);
        //▼▼▼▼▼定位檢測▼▼▼▼▼
        VIVE_Detecting.SetActive(true);//定位開啟圖示
        PA_Detect_flag = true;
        VIVE_DetectOK = false;
        while (PA_Detect_flag)
        {
            if (VIVE_DetectOK == false)
            {
                print("VIVE檢測定位中...");
                yield return new WaitForSeconds(1);
            }
            else
            {
                print("VIVE定位完成!!!");
                VIVE_Detecting.SetActive(false);//定位關閉圖示
                PA_Detect_flag = false;
                yield return new WaitForSeconds(1);
            }
        }
        //▲▲▲▲▲定位檢測▲▲▲▲▲
        for (int i = 0; i < (Cycle*3/2); i++)
        {
            DollAnimator.GetComponent<Animator>().SetInteger("YogaPA", 31);
            yield return new WaitForSeconds(2);
            DollAnimator.GetComponent<Animator>().SetInteger("YogaPA", 32);
            yield return new WaitForSeconds(2);
        }
        yield return new WaitForSeconds(1);
        AllPAButton.SetActive(true);
    }
}
