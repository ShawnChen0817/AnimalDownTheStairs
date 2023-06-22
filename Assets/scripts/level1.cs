using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class level1 : MonoBehaviour
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
    public void Level1()
    {
       button=GameObject.FindGameObjectWithTag("character").GetComponent<AudioSource>();
       button.Play();
       SceneManager.LoadScene(4);
    }

  
}
