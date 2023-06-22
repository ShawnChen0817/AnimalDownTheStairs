using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour
{
    [SerializeField] float move_speed=2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
      
        transform.Translate(0,move_speed*Time.deltaTime,0);
      
        
        if(transform.position.y > 5.3f)
        {
            Destroy(gameObject);
            transform.parent.GetComponent<FloorManager>().Spawnfloor();//transform為子物件
        }
  
    }
    
}
