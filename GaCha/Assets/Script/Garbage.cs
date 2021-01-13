using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    public Animator anim;
    public RandomSellect scRandomSellect;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        scRandomSellect = GameObject.Find("GameManager").GetComponent<RandomSellect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        anim.SetBool("Open", true);
        Invoke("Chage",0.5f);

    }
    public void Chage() {
        scRandomSellect.ChageCanvas();
        scRandomSellect.setCard();
    }


}
