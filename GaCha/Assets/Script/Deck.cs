using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    public Image img;
    public Sprite spFront;
    public Sprite spBack;
    public CardGrade enumCardGrade;
    public GameObject goLook;
    public string sName;

    void Start()
    {
    }
    void Update()
    {
    }

    public void setData(int nNum, Sprite sprite, CardGrade cardGrade, string name)
    {
        if (nNum == -1)
        {
            img.sprite = spBack;
            img.raycastTarget = false;
        }
        else
        {
            spFront = sprite;
            enumCardGrade = cardGrade;
            sName = name;
            img.sprite = spFront;
            img.raycastTarget = true;
        }
    }
    public void ClickMouse()
    {
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
}
