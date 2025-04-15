using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawRoom : MonoBehaviour
{

    public int openingDirection;
    string spawName ;

    private Room_Template template =  ;

    // Start is called before the first frame update
    void Start()
    {
        spawName = this.gameObject.name;
        


        switch (spawName)
        {
            case "spawT":
                openingDirection = 1;
                break;
            case "spawR":
                openingDirection = 2;
                break;
            case "spawD":
                openingDirection = 3;
                break;
            case "spawL":
                openingDirection = 4;
                break;
            default:
                openingDirection = 0;
                break;


        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
