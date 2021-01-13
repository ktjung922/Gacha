using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSellect : MonoBehaviour
{
    public CardDB cardDB;
    public int nTotal = 0;
    public int nDeckCount = 0;
    public GameObject goCanvas;
    public GameObject goGabage;
    public Card[] scCards;
    public CardOpen[] scCardOpens;

    public GameObject goLook;

    public int nCount;

    // Start is called before the first frame update
    void Start()
    {
        nCount = 0;
        scCards = new Card[10];
        scCardOpens = goCanvas.GetComponentsInChildren<CardOpen>();
        cardDB = GameObject.Find("CardDataBaseNomal").GetComponent<CardDB>();
        nDeckCount = cardDB.deck.Count;
        for (int i = 0; i < nDeckCount; i++)
        {
            nTotal += cardDB.deck[i].nWeight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (goLook.activeSelf)
            {
                closeLook();
            }
            else {
                SceneManager.LoadScene("StartScene");
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (nCount == 10 && !goLook.activeSelf && goCanvas.activeSelf) {
                ChageCanvas();
            }
        }
    }
    public Card RandomCard() {
        int nWeightTemp = 0;
        int nSelectNum = 0;
        nSelectNum = Mathf.RoundToInt(nTotal * Random.Range(0.0f, 1.0f));

        for (int i = 0; i < nDeckCount; i++)
        {
            nWeightTemp += cardDB.deck[i].nWeight;
            if (nSelectNum <= nWeightTemp) {
                Card Temp = new Card(cardDB.deck[i]);
                return Temp;
            }
        }
        return null;
    }
    public void setCard() {
        for (int i = 0; i < 10; i++) {
            scCards[i] = RandomCard();
            scCardOpens[i].setData(scCards[i].spCardImg, scCards[i].cardGrade,scCards[i].sCardName);
        }
    }
    public void ChageCanvas() {
        if (goCanvas.activeSelf)
        {
            for (int i = 0; i < 10; i++) {
                scCardOpens[i].Reseting();
            }
            goCanvas.SetActive(false);
            goGabage.SetActive(true);
        }
        else {
            nCount = 0;
            goCanvas.SetActive(true);
            goGabage.SetActive(false);
        }
    }
    public void closeLook() {
        goLook.transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(false);
        goLook.transform.GetChild(0).transform.GetChild(4).gameObject.SetActive(false);
        goLook.SetActive(false);
    }
}
