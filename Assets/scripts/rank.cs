using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class rank : MonoBehaviour
{
    public Text high_scoreText;
    public Text first_scoreText;
    public Text second_scoreText;
    public Text third_scoreText;
    private AudioSource button;
    int num;
    int image_1st;
    int image_2st;
    int image_3st;
    // Start is called before the first frame update
    void Start()
    {
        //取得目前角色代號
        num = PlayerPrefs.GetInt("SelectedCharacterIndex");
        //取得各自排名的角色代號
        image_1st=PlayerPrefs.GetInt("image1");
        image_2st=PlayerPrefs.GetInt("image2");
        image_3st=PlayerPrefs.GetInt("image3");
        //第一高分數
        first_scoreText.text = PlayerPrefs.GetInt("highscore").ToString();
        
        //第二高分數
        second_scoreText.text = PlayerPrefs.GetInt("rank2").ToString();
        //第三高分數
        third_scoreText.text = PlayerPrefs.GetInt("rank3").ToString();
        //顯示第一名角色照片
        if(image_1st==0)
        {
            GameObject.FindGameObjectWithTag("fox1").SetActive(false);
            GameObject.FindGameObjectWithTag("eagle1").SetActive(false);
            GameObject.FindGameObjectWithTag("frog1").SetActive(false);
        }
        else if(image_1st==1)
        {
            GameObject.FindGameObjectWithTag("mouse1").SetActive(false);
            GameObject.FindGameObjectWithTag("eagle1").SetActive(false);
            GameObject.FindGameObjectWithTag("frog1").SetActive(false);
        }
        else if(image_1st==2)
        {
            GameObject.FindGameObjectWithTag("fox1").SetActive(false);
            GameObject.FindGameObjectWithTag("mouse1").SetActive(false);
            GameObject.FindGameObjectWithTag("frog1").SetActive(false);
        }
        else if(image_1st==3)
        {
            GameObject.FindGameObjectWithTag("fox1").SetActive(false);
            GameObject.FindGameObjectWithTag("eagle1").SetActive(false);
            GameObject.FindGameObjectWithTag("mouse1").SetActive(false);
        }
        //顯示第二名角色照片
        if(image_2st==0)
        {
            GameObject.FindGameObjectWithTag("fox2").SetActive(false);
            GameObject.FindGameObjectWithTag("eagle2").SetActive(false);
            GameObject.FindGameObjectWithTag("frog2").SetActive(false);
        }
        else if(image_2st==1)
        {
            GameObject.FindGameObjectWithTag("mouse2").SetActive(false);
            GameObject.FindGameObjectWithTag("eagle2").SetActive(false);
            GameObject.FindGameObjectWithTag("frog2").SetActive(false);
        }
        else if(image_2st==2)
        {
            GameObject.FindGameObjectWithTag("fox2").SetActive(false);
            GameObject.FindGameObjectWithTag("mouse2").SetActive(false);
            GameObject.FindGameObjectWithTag("frog2").SetActive(false);
        }
        else if(image_2st==3)
        {
            GameObject.FindGameObjectWithTag("fox2").SetActive(false);
            GameObject.FindGameObjectWithTag("eagle2").SetActive(false);
            GameObject.FindGameObjectWithTag("mouse2").SetActive(false);
        }
        //顯示第三名角色照片
        if(image_3st==0)
        {
            GameObject.FindGameObjectWithTag("fox3").SetActive(false);
            GameObject.FindGameObjectWithTag("eagle3").SetActive(false);
            GameObject.FindGameObjectWithTag("frog3").SetActive(false);
        }
        else if(image_3st==1)
        {
            GameObject.FindGameObjectWithTag("mouse3").SetActive(false);
            GameObject.FindGameObjectWithTag("eagle3").SetActive(false);
            GameObject.FindGameObjectWithTag("frog3").SetActive(false);
        }
        else if(image_3st==2)
        {
            GameObject.FindGameObjectWithTag("fox3").SetActive(false);
            GameObject.FindGameObjectWithTag("mouse3").SetActive(false);
            GameObject.FindGameObjectWithTag("frog3").SetActive(false);
        }
        else if(image_3st==3)
        {
            GameObject.FindGameObjectWithTag("fox3").SetActive(false);
            GameObject.FindGameObjectWithTag("eagle3").SetActive(false);
            GameObject.FindGameObjectWithTag("mouse3").SetActive(false);
        }
    }
    public void home()
    {
        SceneManager.LoadScene(0);
        button=GameObject.FindGameObjectWithTag("home").GetComponent<AudioSource>();
        button.Play();
    }
    public void fight()
    {
        SceneManager.LoadScene(4);
        button=GameObject.FindGameObjectWithTag("fight").GetComponent<AudioSource>();
        button.Play();
    }



    
}
