using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardOpen : MonoBehaviour
{
    public Image img;
    public Sprite spFront;
    public Sprite[] spBack;
    public Material eff;
    public CardGrade enumCardGrade;
    private bool isOpen;
    public GameObject goLook;
    public string sName;
    public GameObject goManager;

    void Start()
    {
        isOpen = false;
        img = gameObject.GetComponent<Image>();
        img.sprite = spBack[0];
        goManager = GameObject.Find("GameManager");
    }
    void Update()
    {
        
    }

    public void setData(Sprite sprite, CardGrade cardGrade, string name) {
        spFront = sprite;
        enumCardGrade = cardGrade;
        sName = name;
    }

    public void EnterMouse()
    {
        if (!isOpen)
        {
            if (enumCardGrade == CardGrade.One)
            {

            }
            else if (enumCardGrade == CardGrade.Two)
            {
                img.sprite = spBack[1];
            }
            else
            {
                img.sprite = spBack[1];
                img.material = eff;
            }
        }
        else {
           
        }
    }
    public void ClickMouse() {
        if (isOpen) {
            goLook.SetActive(true);
            Transform trTemp = goLook.transform.GetChild(0).transform;
            trTemp.GetChild(0).GetComponent<Image>().sprite = spFront;
            trTemp.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = sName;
            if (enumCardGrade == CardGrade.Tree)
            {
                trTemp.GetChild(3).gameObject.SetActive(true);
                trTemp.GetChild(4).gameObject.SetActive(true);
            }
            else if (enumCardGrade == CardGrade.Two)
            {
                trTemp.GetChild(3).gameObject.SetActive(true);
            }
        }
        else {
            img.raycastTarget = false;
            Opening();
        }
    }
    public void Opening() {
        if (transform.localEulerAngles.y > 90 && !isOpen) {
            isOpen = true;
            img.sprite = spFront;
            goManager.GetComponent<RandomSellect>().nCount++;
            if (img.material != null) {
                img.material = null;
            }
        }
        if (transform.localEulerAngles.y > 180)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            img.raycastTarget = true;
        }
        else {
            transform.Rotate(0f, 1f, 0f);
            Invoke("Opening", 0.01f);
        }
    }
    public void Reseting()
    {
        isOpen = false;
        img.sprite = spBack[0];
        img.material = null;
    }

    /* 업데이트 전버전
    public Image img;
    private float timedelta;
    public Sprite[] sprites;
    private int fSpriteNum;
    private bool ch;
    private bool opening;
    public int num;

    // Start is called before the first frame update
    void Start()
    {
        fSpriteNum = 0;
        timedelta = 2;
        ch = false;
        opening = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ch)
        {
            if (timedelta > 0)
            {
                img.color = new Color(timedelta / 2, timedelta / 2, timedelta / 2);
                timedelta -= Time.deltaTime;
            }
            else
            {
                timedelta = 0;
            }
        }
        else {
            if (timedelta < 2f)
            {
                img.color = new Color(timedelta / 2, timedelta / 2, timedelta / 2);
                timedelta += Time.deltaTime;
            }
            else
            {
                timedelta = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            click();
        }

        if (opening) {
            img.fillAmount -= Time.deltaTime;
            if (img.fillAmount == 0) {
                opening = false;
                img.raycastTarget = true;
            }
        }
    }
    public void Chage() {
        ch = true;
        Invoke("Open", 2);
    }
    public void Open() {
        img.sprite = sprites[fSpriteNum];
        ch = false;
        Invoke("click", 2);
    }
    public void click() {
        img.raycastTarget = false;
        if (fSpriteNum < num) {
            fSpriteNum++;
            if (fSpriteNum > sprites.Length - 1)
            {
                fSpriteNum = 0;
            }
            Chage();
        }
        else if (fSpriteNum == num){
            opening = true;
        }
    }
    public void OverMouse() {

        img.sprite = sprites[1];
    }
    */
}
