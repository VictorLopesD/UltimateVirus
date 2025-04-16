using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawRoom : MonoBehaviour
{
    public int openingDirection;
    private int rand;
    public bool spawned;
    private Room_Template template;

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

    public void SpawRooms()
    {
        // Se já spawnou ou não tem mais salas pra gerar, sai
        if (spawned || GameManager.instance.numRoom <= 0)
            return;

        // Evita gerar sala se já tiver algo na posição
        Collider2D checkRoom = Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("Room"));
        if (checkRoom != null)
        {
            spawned = true;
            return;
        }

        // Diminui o número de salas a gerar
        GameManager.instance.numRoom -= 1;

        // Gera uma sala com base na direção
        switch (openingDirection)
        {
            case 1: // cima
                rand = Random.Range(0, template.bottonRoom.Length);
                Instantiate(template.bottonRoom[rand], transform.position, Quaternion.identity);
                break;
            case 2: // esquerda
                rand = Random.Range(0, template.leftRoom.Length);
                Instantiate(template.leftRoom[rand], transform.position, Quaternion.identity);
                break;
            case 3: // baixo
                rand = Random.Range(0, template.topRoom.Length);
                Instantiate(template.topRoom[rand], transform.position, Quaternion.identity);
                break;
            case 4: // direita
                rand = Random.Range(0, template.rigthRoom.Length);
                Instantiate(template.rigthRoom[rand], transform.position, Quaternion.identity);
                break;
        }

        spawned = true;
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
        if (spawned || GameManager.instance.numRoom > 0)
            return;

        switch (openingDirection)
        {
            case 1:
                Instantiate(template.closeRoom[0], transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(template.closeRoom[1], transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(template.closeRoom[2], transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(template.closeRoom[3], transform.position, Quaternion.identity);
                break;
        }

        spawned = true;
    }
}
