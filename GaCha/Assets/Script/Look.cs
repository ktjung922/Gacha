using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        closeLook();
    }
    public void closeLook()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(0).transform.GetChild(4).gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

    }

}
