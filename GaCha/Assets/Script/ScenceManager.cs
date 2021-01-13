using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceManager : MonoBehaviour
{
    public CardDB scDatabase;
    public Deck[] scDecks;
    public int nNum;
    public GameObject goDeck;
    public GameObject goCanvas;
    public GameObject goLook;

    // Start is called before the first frame update
    void Start()
    {
        nNum = 0;
        scDecks = goDeck.GetComponentsInChildren<Deck>();
        scDatabase = GameObject.Find("CardDataBaseNomal").GetComponent<CardDB>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && goDeck.activeSelf) {
            if (nNum < scDatabase.deck.Count % 10) {
                nNum++;
            }
            Setting();

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && goDeck.activeSelf) {
            if (nNum > 0) {
                nNum--;
            }
            Setting();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !goLook.activeSelf)
        {
            goCanvas.SetActive(true);
            goDeck.SetActive(false);
        }
    }
    public void StartBtn()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitBtn() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void DeckBtn() {
        goCanvas.SetActive(false);
        goDeck.SetActive(true);
        Setting();
    }
    public void Setting() {
        for (int i = 0; i < 10; i++) {
            if (i + (nNum * 10) < scDatabase.deck.Count)
            {
                scDecks[i].setData(i + (nNum * 10), scDatabase.deck[i + (nNum * 10)].spCardImg, scDatabase.deck[i + (nNum * 10)].cardGrade, scDatabase.deck[i + (nNum * 10)].sCardName);
            }
            else {
                scDecks[i].setData(-1, scDatabase.deck[0].spCardImg, CardGrade.One, "None");
            }
        }
    }
}