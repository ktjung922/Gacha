using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardGrade {One, Two, Tree}

[System.Serializable]
public class Card
{
    public string sCardName;
    public Sprite spCardImg;
    public CardGrade cardGrade;
    public int nWeight;

    public Card(Card card) {
        this.sCardName = card.sCardName;
        this.spCardImg = card.spCardImg;
        this.cardGrade = card.cardGrade;
        this.nWeight = card.nWeight;
    }
}
