using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class tests : MonoBehaviour
{
    int num; 
    // Start is called before the first frame update
    void Start()
    {
        num = PlayerPrefs.GetInt("SelectedCharacterIndex");
        UpdateCharacterShow();
    }

    // Update is called once per frame
    void UpdateCharacterShow()
    {
        if(num == 1)
        {
            GameObject.FindGameObjectWithTag("Player").SetActive(false);
        }
        if(num == 2)
        {
            GameObject.FindGameObjectWithTag("player1").SetActive(false);
        }
}
}