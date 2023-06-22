using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerselect : MonoBehaviour
{
    // Start is called before the first frame update
    //角色
    int num;
    void Start()
    {
        //角色產生
        num = PlayerPrefs.GetInt("SelectedCharacterIndex");
        Debug.Log(num);
        UpdateCharacterShow();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCharacterShow()
    {
        if(num == 0)
        {
            GameObject.FindGameObjectWithTag("player1").SetActive(false);
            GameObject.FindGameObjectWithTag("player2").SetActive(false);
            GameObject.FindGameObjectWithTag("Player").SetActive(false);
        }
        if(num == 1)
        {
            GameObject.FindGameObjectWithTag("player1").SetActive(false);
            GameObject.FindGameObjectWithTag("player2").SetActive(false);
            GameObject.FindGameObjectWithTag("player3").SetActive(false);
        }
        if(num == 2)
        {
            GameObject.FindGameObjectWithTag("Player").SetActive(false);
            GameObject.FindGameObjectWithTag("player2").SetActive(false);
            GameObject.FindGameObjectWithTag("player3").SetActive(false);
        }
        if(num == 3)
        {
            GameObject.FindGameObjectWithTag("player1").SetActive(false);
            GameObject.FindGameObjectWithTag("Player").SetActive(false);
            GameObject.FindGameObjectWithTag("player3").SetActive(false);
        }

       
    }
    
}
