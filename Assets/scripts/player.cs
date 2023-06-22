using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float move_speed = 5f;
    GameObject currentfloor;
    public int hp;
    public GameObject hpbar;
    public GameObject replaybutton;
    [SerializeField] GameObject gem;
    [SerializeField] GameObject mainbutton;
    [SerializeField] Text scoreText;
    public Text high_scoreText;
    public Text first_scoreText;
    public Text second_scoreText;
    public Text third_scoreText;
    int score;
    int starting_highscore;
    int second_highscore;
    int third_highscore;
    int num;
    int first;
    int second;
    int third;
    float scoretime;
    Animator anim;
    Animator animator;
    SpriteRenderer Ren;
    AudioSource deathsound;
    [SerializeField] AudioSource bgm;
    void Start()//遊戲一開始
    {
        hp=10;
        score=0;
        scoretime=0;
        anim=GetComponent<Animator>();
        Ren=GetComponent<SpriteRenderer>();
        deathsound = GetComponent<AudioSource>();
        //hp顏色
        for(int i=0; i<hpbar.transform.childCount; i++)
        {
            hpbar.transform.GetChild(i).GetComponent<Image>().color = Color.yellow;
        }
        //取得角色代號
        num = PlayerPrefs.GetInt("SelectedCharacterIndex");
        //PlayerPrefs.SetInt("highscore",0);
        //最高分數
        high_scoreText.text = PlayerPrefs.GetInt("highscore").ToString();
        starting_highscore = PlayerPrefs.GetInt("highscore");
        //第一高分數
        //first_scoreText.text = PlayerPrefs.GetInt("highscore").ToString();
        //第二高分數
        ///second_scoreText.text = PlayerPrefs.GetInt("rank2").ToString();
        second_highscore = PlayerPrefs.GetInt("rank2");
        //第三高分數
        //third_scoreText.text = PlayerPrefs.GetInt("rank3").ToString();
        third_highscore = PlayerPrefs.GetInt("rank3");
        bgm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {   
            //deltaTime為跑一次迴圈所需要的時間，能夠解決不同電腦體驗不同得情形
            transform.Translate(move_speed*Time.deltaTime,0,0);
            Ren.flipX = false;
            anim.SetBool("run",true);
            if(Input.GetKey(KeyCode.Space))
            {
                transform.Translate(0,move_speed*Time.deltaTime+1f,0);
                transform.Translate(0,move_speed*Time.deltaTime-1f,0);
            }
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-move_speed*Time.deltaTime,0,0);
            Ren.flipX = true;
            anim.SetBool("run",true);
            if(Input.GetKey(KeyCode.Space))
            {
                transform.Translate(0,move_speed*Time.deltaTime+1f,0);
                transform.Translate(0,move_speed*Time.deltaTime-1f,0);
            }
            
        }
        
        else
        {
            anim.SetBool("run",false);
        }
        updatescore();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag=="normal")
        {
            if(other.contacts[0].normal == new Vector2(0f,1f))
            {
                currentfloor = other.gameObject;
                other.gameObject.GetComponent<AudioSource>().Play();
            }
            
        }
        else if(other.gameObject.tag=="nails")
        {
        
            if(other.contacts[0].normal == new Vector2(0f,1f))
            {
                currentfloor = other.gameObject;
                modifyhp(-2);
                anim.SetTrigger("hurt");
                other.gameObject.GetComponent<AudioSource>().Play();
            }
            
        }
        else if(other.gameObject.tag == "celling")
        {
            currentfloor.GetComponent<BoxCollider2D>().enabled = false;
            modifyhp(-3);
            anim.SetTrigger("hurt");
            other.gameObject.GetComponent<AudioSource>().Play();
        }      
        else if(other.gameObject.tag == "gem")
        {
 
            //currentfloor.GetComponent<BoxCollider2D>().enabled = false;
            modifyhp(3);
            other.gameObject.SetActive(false);

        }    
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="death line")
        {
            modifyhp(-10);
            die();
        }
    }

    private void modifyhp(int num)
    {
        hp+=num;
        if(hp>=10)
        {
            hp=10;
            for(int i=0; i<hpbar.transform.childCount; i++)
            {
                hpbar.transform.GetChild(i).GetComponent<Image>().color = Color.yellow;
            }
        }
        else if(5<=hp && hp<10)
        {
            for(int i=0; i<hpbar.transform.childCount; i++)
            {
                hpbar.transform.GetChild(i).GetComponent<Image>().color = new Color(1.0f, 0.64f, 0.0f);
            }
        }
        else if(hp>0 && hp<5)
        {
            for(int i=0; i<hpbar.transform.childCount; i++)
            {
                hpbar.transform.GetChild(i).GetComponent<Image>().color = Color.red;
            }
        }
        else if(hp<=0)
        {
            hp=0;
            die();
        }
        
        updatehpbar();

    }

    private void updatehpbar()
    {
        for(int i=0; i<hpbar.transform.childCount; i++)
        {
            if(hp>i)
            {
                hpbar.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                hpbar.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    
    private void updatescore()
    {
        scoretime+=Time.deltaTime;
        if(scoretime>2f)
        {
            score++;
            scoretime = 0f; 
            scoreText.text = "score  " + score.ToString() ;
        }  
        
    }
    public void updatehighscore()
    {
        if(score > starting_highscore)
        {
            PlayerPrefs.SetInt("highscore",score);
        } 
    }
    //分數排行
    public void updaterank()
    {
        //如果該角色有進入排行則儲存此角色代號
        //score為每次的分數  starting_highscore為最高的分數
        if(score > starting_highscore)
        {
            PlayerPrefs.SetInt("highscore",score);
        }
        if(starting_highscore < score && starting_highscore > second_highscore)
        {
            PlayerPrefs.SetInt("rank2",starting_highscore);
        }
        if(score < starting_highscore && score > second_highscore)
        {
            PlayerPrefs.SetInt("rank2",score);
        }
        if(second_highscore < score && second_highscore > third_highscore )
        {
            PlayerPrefs.SetInt("rank3",second_highscore);
        }
        if(score < second_highscore && score > third_highscore )
        {
            PlayerPrefs.SetInt("rank3",score);
        }
        updateimage();
    }
    private void updateimage()
    {
        //將角色代號記錄在image
        first = PlayerPrefs.GetInt("highscore");
        second = PlayerPrefs.GetInt("rank2");
        third = PlayerPrefs.GetInt("rank3");
        if(score == first)
        {
            PlayerPrefs.SetInt("image1",num);
        }
        if(score == second)
        {
            PlayerPrefs.SetInt("image2",num);
        }  
        if(score == third) 
        {
            PlayerPrefs.SetInt("image3",num);
        } 
    }
    private void die() 
    {
        {
            deathsound.Play();
            Time.timeScale = 0f;
            bgm.Pause();
            replaybutton.SetActive(true);
            mainbutton.SetActive(true);
        }
        updatehighscore();
        updaterank();
    }
    
    public void replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(4);
        
    } 
    
    public void main()
    {
        SceneManager.LoadScene("開始");
        Time.timeScale = 1f;  
    }
    
}
