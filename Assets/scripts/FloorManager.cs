using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
   [SerializeField] GameObject[] floorprefabs;
   public void Spawnfloor()//自動生成階梯的函式
   {
        int r = Random.Range(0, floorprefabs.Length);
        GameObject floor = Instantiate(floorprefabs[r], transform);//希望串列出來的物件為FloorManager的子物件
        //生成階梯的位置
        floor.transform.position = new Vector3(Random.Range(-3.37f,3.37f),-5f,0f);//三個座標型態
   }

}
