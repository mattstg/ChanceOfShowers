using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum MyCullingMask { Player = 1, Dog = 2, Cat = 4, Aliens = 8, UI = 16 }
public class LayerExamples : MonoBehaviour
{

    //UI Aliens Cat Dog Player
    // 1   1    0    0    1   
    // 2^4 2^3 2^2  2^1  2^0  
    //  16  8   4    2    1   
    
    // 00001 = 1 
    //  0101 = 5
    
    public void Whatever()
    {

        Physics.Raycast(Vector3.zero, Vector3.zero, 0, LayerMask.GetMask("Ground","Wall"));


        string toCheckLayerName = "Ground";                      //Index    Raw Value                Binary Value
        int toCheckLayerIndex = LayerMask.NameToLayer("Ground"); //11        2^11                   1000 0000 0000
        int myMask = LayerMask.GetMask("Ground", "Wall"); //               2^11 + 2^10              1100 0000 0000


        //1100 0000 0000 == 1100 0000 0000 | 1000 0000 0000
        //0000 0000 0010 | 1100 0000 0000 == 1100 0000 0000
        //             1100 0000 0000 == 1100 0000 0000

        bool b = LayerMask.GetMask("Ground", "Wall") == (LayerMask.GetMask("Ground", "Wall") | 1 << toCheckLayerIndex);

    }
    // 1<< 3
    // 1000

    public LayerMask myLayerMask;
    private void TriggerOnEnter(Collider c)
    {
       bool b = (myLayerMask == (myLayerMask | 1 << c.gameObject.layer));

    }
}
