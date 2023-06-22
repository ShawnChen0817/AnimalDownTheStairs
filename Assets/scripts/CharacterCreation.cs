using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CharacterCreation : MonoBehaviour
{
    public GameObject[] CharacterPrefabs;
    private GameObject[] characterGameObjects;
    private int selectedIndex = 0;
    private int length;//所有可供选择的角色个数 
    AudioSource button;
    private GameObject welcome;
    private GameObject player;
    public Text charactername = null;
    public Text intro = null;
 
    void Start () {
        length = CharacterPrefabs.Length;
        characterGameObjects = new GameObject[length];
        for (int i=0;i<length;i++) 
        {
            characterGameObjects[i] = GameObject.Instantiate(CharacterPrefabs[i],transform.position, transform.rotation) as GameObject;
            //characterGameObjects[i].SetActive(false);
        } 
        UpdateCharacterShow();
    }
 
    void UpdateCharacterShow ()//更新所有角色的显示
    {
        characterGameObjects[selectedIndex].SetActive(true);
        for (int i=0;i<length;i++) 
        {
            if (i != selectedIndex) 
            {
                characterGameObjects[i].SetActive(false);//把未选择的角色隐藏起来
            } 
        }
        if(selectedIndex==0)
        {
            charactername.text = "臭臭鼠";
            intro.text = "擁有最快速度的角色，別看他這樣他可是all star中的最速";
        }
        if(selectedIndex==1)
        {
            charactername.text = "屁屁狐";
            intro.text = "是村里中最平凡的狐狸，卻很屁，每天都在嗆人，所以村民都討厭他";
        }
        if(selectedIndex==2)
        {
            charactername.text = "酷酷鷹";
            intro.text = "每天都在耍酷，常常幻想自己是最帥的，自稱譍界車銀優";
        }
        if(selectedIndex==3)
        {
            charactername.text = "泡泡蛙";
            intro.text = "是胖子沒錯，卻是個靈活的胖子，擔任村里的忍者，身手矯健，擁有不輸坦克的怪力";
        }
        
    }
    public void OnNextButtonClick()//当我们点击了下一个按钮
    {
        selectedIndex++;
        selectedIndex %= length;
        button=GameObject.FindGameObjectWithTag("character").GetComponent<AudioSource>();
        button.Play();
        if(selectedIndex==0)
        {
            charactername.text = "臭臭鼠";
            intro.text = "擁有最快速度的角色，別看他這樣他可是all star中的最速";
        }
        if(selectedIndex==1)
        {
            charactername.text = "屁屁狐";
            intro.text = "是村里中最平凡的狐狸，卻很屁，每天都在嗆人，所以村民都討厭他";
        }
        if(selectedIndex==2)
        {
            charactername.text = "酷酷鷹";
            intro.text = "每天都在耍酷，常常幻想自己是最帥的，自稱譍界車銀優";
        }
        if(selectedIndex==3)
        {
            charactername.text = "泡泡蛙";
            intro.text = "是胖子沒錯，卻是個靈活的胖子，擔任村里的忍者，身手矯健，擁有不輸坦克的怪力";
        }
        UpdateCharacterShow();
        
    }
    public void OnPreButtonClick()//当我们点击了上一个按钮
    {
        selectedIndex--;
        if (selectedIndex == -1)
        {
            selectedIndex = length - 1;
        }
        if(selectedIndex==0)
        {
            charactername.text = "臭臭鼠";
            intro.text = "擁有最快速度的角色，別看他這樣他可是all star中的最速";
        }
        if(selectedIndex==1)
        {
            charactername.text = "屁屁狐";
            intro.text = "是村里中最平凡的狐狸，卻很屁，每天都在嗆人，所以村民都討厭他";
        }
        if(selectedIndex==2)
        {
            charactername.text = "酷酷鷹";
            intro.text = "每天都在耍酷，常常幻想自己是最帥的，自稱譍界車銀優";
        }
        if(selectedIndex==3)
        {
            charactername.text = "泡泡蛙";
            intro.text = "是胖子沒錯，卻是個靈活的胖子，擔任村里的忍者，身手矯健，擁有不輸坦克的怪力";
        }
        button=GameObject.FindGameObjectWithTag("character").GetComponent<AudioSource>();
        button.Play();
        UpdateCharacterShow();
    }
    public void OnOkButtonClick()
    {
        PlayerPrefs.SetInt("SelectedCharacterIndex",selectedIndex);
        button=GameObject.FindGameObjectWithTag("character").GetComponent<AudioSource>();
        GameObject.FindGameObjectWithTag("character_name").SetActive(false);
        button.Play();
    }



}
