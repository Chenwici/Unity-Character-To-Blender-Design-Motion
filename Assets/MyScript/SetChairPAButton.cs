using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChairPAButton : MonoBehaviour
{
    public GameObject DollAnimator, AllPAButton, VIVE_Detecting, ChairObj, DollCameraObj;
    public bool PA_Detect_flag = true;
    public bool VIVE_DetectOK = false;
    public void Awake()
    {
        DollCameraObj = GameObject.Find("DollCamera");
        ChairObj      = GameObject.Find("ChairMod");
        DollAnimator = GameObject.Find("LiamAnim");
        AllPAButton  = GameObject.Find("AllPAButton");
        //VIVE_Detecting = GameObject.Find("VIVE_Detecting");
        //VIVE_Detecting.SetActive(false);
        ChairObj.SetActive(false);
    }
    public void StartRunPA()
    {
        AllPAButton.SetActive(false);
        StartCoroutine(PA_Detect(3));//執行趴下引導+循環確認是否有跟上動作
    }
    IEnumerator PA_Detect(int Cycle)
    {
        //▼▼轉攝影機視角▼▼
        for (int i = 0; i > -56; i--)
        {
            DollCameraObj.transform.eulerAngles = new Vector3(0, i, 0);
            yield return new WaitForSeconds(0.02f);
        }
        //▲▲轉攝影機視角▲▲
        ChairObj.SetActive(true);//開啟椅子
        yield return new WaitForSeconds(1);
        DollAnimator.GetComponent<Animator>().SetInteger("ChairPA", 1);//執行第一動作-墊腳肩起始動作
        yield return new WaitForSeconds(1);

        //▼▼▼▼▼定位檢測▼▼▼▼▼
        PA_Detect_flag = true;
        VIVE_DetectOK = false;
        VIVE_Detecting.SetActive(true);//定位關閉圖示
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
            DollAnimator.GetComponent<Animator>().SetInteger("ChairPA", 11);
            yield return new WaitForSeconds(4);
            DollAnimator.GetComponent<Animator>().SetInteger("ChairPA", 12);
            yield return new WaitForSeconds(2);
        }
        yield return new WaitForSeconds(1);
        DollAnimator.GetComponent<Animator>().SetInteger("ChairPA", 2);//恢復最初動作
        yield return new WaitForSeconds(1);
        DollAnimator.GetComponent<Animator>().SetInteger("ChairPA", 21);//換坐站動作(定位點為坐姿)
        ChairObj.GetComponent<Animation>().Play("ChairAnim1");

        //▼▼▼▼▼定位檢測▼▼▼▼▼
        PA_Detect_flag = true;
        VIVE_DetectOK = false;
        VIVE_Detecting.SetActive(true);//定位關閉圖示
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
            DollAnimator.GetComponent<Animator>().SetInteger("ChairPA", 21);
            yield return new WaitForSeconds(2);
            DollAnimator.GetComponent<Animator>().SetInteger("ChairPA", 22);
            yield return new WaitForSeconds(2);
        }
        yield return new WaitForSeconds(1);
        DollAnimator.GetComponent<Animator>().SetInteger("ChairPA", 3);//恢復最初動作
        yield return new WaitForSeconds(1);
        DollAnimator.GetComponent<Animator>().SetInteger("ChairPA", 30);//換坐姿的抬腿運動

        //▼▼▼▼▼定位檢測▼▼▼▼▼
        PA_Detect_flag = true;
        VIVE_DetectOK = false;
        VIVE_Detecting.SetActive(true);//定位關閉圖示
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
        for (int i = 0; i < Cycle; i++)//
        {
            DollAnimator.GetComponent<Animator>().SetInteger("ChairPA", 31);
            yield return new WaitForSeconds(2);
            DollAnimator.GetComponent<Animator>().SetInteger("ChairPA", 32);
            yield return new WaitForSeconds(2);
            DollAnimator.GetComponent<Animator>().SetInteger("ChairPA", 33);
            yield return new WaitForSeconds(2);
            DollAnimator.GetComponent<Animator>().SetInteger("ChairPA", 34);
            yield return new WaitForSeconds(2);
        }
        yield return new WaitForSeconds(1);
        DollAnimator.GetComponent<Animator>().SetInteger("ChairPA", 0);//恢復站力動作(結束)
        ChairObj.GetComponent<Animation>().Play("ChairAnim2");//椅子縮小並返回原點
        //▼▼轉回攝影機視角▼▼
        for (int i = -55; i < 1; i++)
        {
            DollCameraObj.transform.eulerAngles = new Vector3(0, i, 0);
            yield return new WaitForSeconds(0.02f);
        }
        //▲▲轉回攝影機視角▲▲
        ChairObj.SetActive(false);//關閉椅子
        AllPAButton.SetActive(true);
    }
}
