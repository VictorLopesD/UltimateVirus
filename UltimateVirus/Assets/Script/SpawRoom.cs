using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawRoom : MonoBehaviour
{
    public int openingDirection;
    private int rand;
    public bool spawned = false;
    private Room_Template template;
    public GameObject room;

    private void Awake()
    {
        // Define a direção de abertura com base no nome do objeto
        switch (gameObject.name)
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

    void Start()
    {
        template = GameObject.FindGameObjectWithTag("Rooms").GetComponent<Room_Template>();
        // Aguarda um pequeno tempo pra evitar conflitos
        Invoke("SpawRooms", 0.2f);
        Invoke("CloseRoom", 4f);
        
    }

    private void Update()
    {
        
    }

    public void SpawRooms()
    {
        
        Collider2D checkRoom = Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("Room"));
        if (checkRoom != null && checkRoom.gameObject != this.gameObject)
        {
            spawned = true;
            return;
        }
        // Se já spawnou ou não tem mais salas pra gerar, sai
        if (!spawned && GameManager.instance.numRoom > 0)
        {       
            
           
            // Diminui o número de salas a gerar
            GameManager.instance.numRoom -= 1;

            // Gera uma sala com base na direção
            switch (openingDirection)
            {
                case 1: // cima
                    rand = Random.Range(0, template.bottonRoom.Length);
                    room = Instantiate(template.bottonRoom[rand], transform.position, Quaternion.identity);
                    break;
                case 2: // esquerda
                    rand = Random.Range(0, template.rigthRoom.Length);

                    room = Instantiate(template.leftRoom[rand], transform.position, Quaternion.identity);
                    break;
                case 3: // baixo
                    rand = Random.Range(0, template.topRoom.Length);
                    room = Instantiate(template.topRoom[rand], transform.position, Quaternion.identity);
                    break;
                case 4: // direita
                    rand = Random.Range(0, template.leftRoom.Length);
                    room = Instantiate(template.rigthRoom[rand], transform.position, Quaternion.identity);
                    break;
            }

            spawned = true;
            }
        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spawpoint"))
        {
            if (!collision.GetComponent<SpawRoom>().spawned && !spawned)
            {
                Destroy(gameObject);
            }

            spawned = true;
        }
    }

    public void CloseRoom()
    {
        
        Collider2D checkRoom = Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("Room"));
        if (checkRoom != null && checkRoom.gameObject != this.gameObject)
        {
            spawned = true;
            return;
        }
        
       


        if (!spawned && GameManager.instance.numRoom <= 0)
        {
            
            switch (openingDirection)
            {
                case 1:
                    room = Instantiate(template.closeRoom[0], transform.position, Quaternion.identity);
                    break;
                case 2:
                    room = Instantiate(template.closeRoom[1], transform.position, Quaternion.identity);
                    break;
                case 3:
                    room = Instantiate(template.closeRoom[2], transform.position, Quaternion.identity);
                    break;
                case 4:
                    room = Instantiate(template.closeRoom[3], transform.position, Quaternion.identity);
                    break;
            }
            

        }
        else if(checkRoom == null && room == null)
            {
                Debug.LogWarning(this.gameObject + " gerando sala faltante");
                switch (openingDirection)
                {
                    case 1:
                        room = Instantiate(template.closeRoom[0], transform.position, Quaternion.identity);
                        break;
                    case 2:
                        room = Instantiate(template.closeRoom[1], transform.position, Quaternion.identity);
                        break;
                    case 3:
                        room = Instantiate(template.closeRoom[2], transform.position, Quaternion.identity);
                        break;
                    case 4:
                        room = Instantiate(template.closeRoom[3], transform.position, Quaternion.identity);
                        break;
                }
            }
        spawned = true;
    }
}
