using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawRoom : MonoBehaviour
{
   
    public int openingDirection;
    string spawName ;
    private int rand;
    public bool spawned;
    private Room_Template template;

    private void Awake()
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

   
    
    // Start is called before the first frame update
    void Start()
    {
        template = GameObject.FindGameObjectWithTag("Rooms").GetComponent<Room_Template>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("SpawRooms", 2f);
        Invoke("CloseRoom", 2f);


    }

    public void SpawRooms()
    {
        if (!spawned && GameManager.instance.numRoom > 0)
        {
            GameManager.instance.numRoom -= 1;
            Debug.Log("numPgerar: " + GameManager.instance.numRoom);
            if (openingDirection == 3)
            {
                rand = Random.Range(1, template.topRoom.Length);
                GameObject topRoom = Instantiate(template.topRoom[rand], transform.position, template.topRoom[rand].transform.rotation);
               // Debug.Log(topRoom.name + " - " + gameObject.name);


            }
            else if (openingDirection == 4)
            {
                rand = Random.Range(0, template.rigthRoom.Length);
                GameObject rightRoom = Instantiate(template.rigthRoom[rand], transform.position, template.rigthRoom[rand].transform.rotation);
                //Debug.Log(rightRoom.name + gameObject.name);

            }
            else if (openingDirection == 1)
            {
                rand = Random.Range(0, template.bottonRoom.Length);
                GameObject bottonRoom = Instantiate(template.bottonRoom[rand], transform.position, template.bottonRoom[rand].transform.rotation);
                //Debug.Log(bottonRoom.name + gameObject.name);

            }
            else if (openingDirection == 2)
            {
                rand = Random.Range(0, template.leftRoom.Length);
                GameObject leftRoom = Instantiate(template.leftRoom[rand], transform.position, template.leftRoom[rand].transform.rotation);
                //Debug.Log(leftRoom.name + gameObject.name);

            }
            


                spawned = true;
        }
        


        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.CompareTag("Spawpoint") )
      {
            Debug.Log(this.gameObject.name.ToString() + " - " + collision.gameObject.name.ToString());

            if ( collision.GetComponent<SpawRoom>().spawned == false &&  spawned == false )
            {
                
                
                Destroy(gameObject);
            }
            
        }
               
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Room") && spawned)
        {
            Debug.Log( "Estou em uma sala");
            Instantiate(template.closeRoom[4], transform.position, template.closeRoom[4].transform.rotation);
            spawned = true;
        }
    }
    public void CloseRoom()
    {
        if (!spawned && GameManager.instance.numRoom <= 0)
        {
            if (openingDirection == 1)
            {
                GameObject CloseRoom = Instantiate(template.closeRoom[0], transform.position, template.closeRoom[0].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                GameObject CloseRoom = Instantiate(template.closeRoom[1], transform.position, template.closeRoom[1].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                GameObject CloseRoom = Instantiate(template.closeRoom[2], transform.position, template.closeRoom[2].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                GameObject CloseRoom = Instantiate(template.closeRoom[3], transform.position, template.closeRoom[3].transform.rotation);
            }
            spawned = true;
        }
    }
        
}
