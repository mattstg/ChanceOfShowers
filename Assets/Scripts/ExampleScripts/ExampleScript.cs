using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum myENum { a,b,c }
public class ExampleScript : MonoBehaviour
{
    [Tooltip("this is a tooltip")] public float playerSpeed = 5;

    Rigidbody rb; //caching
    public PlayerStats msc;
    public MeshRenderer[] renderersToColor;
    Color[] originalColors;

    private void Awake()
    {
        originalColors = new Color[renderersToColor.Length];

        rb = gameObject.GetComponent<Rigidbody>();
        for (int i = 0; i < renderersToColor.Length; i++)
        {
            originalColors[i] = renderersToColor[i].material.color;
        }
    }


    private void FixedUpdate()
    {
        rb.AddForce(Vector3.forward);
    }

    public void MyFunc() { }

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.W))
       {
            //transform.position = transform.position + new Vector3(0, 0, playerSpeed * Time.deltaTime);
            for(int i = 0; i < renderersToColor.Length; i++)
            {
                renderersToColor[i].material.color = new Color(.5f, .5f, .25f);  //Color.
            }

       }

        if (Input.GetKeyUp(KeyCode.W))
        {
            for (int i = 0; i < renderersToColor.Length; i++)
                renderersToColor[i].material.color = originalColors[i];

        }

    }

    [System.Serializable]
    public class PlayerStats
    {
        public float hp;
        public float armor;
        public float mana;
        public float maxMana;

    }


   
}
