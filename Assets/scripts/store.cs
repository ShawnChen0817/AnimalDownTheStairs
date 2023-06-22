using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class store : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource button;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Enter_store()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f; 
        button=GameObject.FindGameObjectWithTag("character").GetComponent<AudioSource>();
        button.Play();
    }
    public void Exit_store()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1f; 
        button=GameObject.FindGameObjectWithTag("character").GetComponent<AudioSource>();
        button.Play();
    }
    public void rank_button()
    {
        SceneManager.LoadScene(3);
        button=GameObject.FindGameObjectWithTag("home").GetComponent<AudioSource>();
        button.Play();
    }

    public void home_button()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        button=GameObject.FindGameObjectWithTag("home").GetComponent<AudioSource>();
        button.Play();
    }
    
}
