using UnityEngine;

public class BaseAtributos : MonoBehaviour
{
    public GameObject[] tipoMonstro;
    public GameObject[] spawPointMonstro;
    int classifMonst = 0;
    public int hpMax;
    public int dano;
    public float speed;
    public int nivel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GerarAtributos();

       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GerarAtributos()
    {
        int valor;
        valor = Random.Range(0, spawPointMonstro.Length - 1);
        int pontSpaw = 0;
        nivel = 1 * Random.Range(1, 3);
        
        


        while (valor < spawPointMonstro.Length-1)
        {
            classifMonst = Random.Range(0, this.tipoMonstro.Length);

            GameObject inimigo1 = null;
            Debug.Log("class " + classifMonst );
            switch (classifMonst)
            {
                case 0:
                    Debug.Log("Monstro 0");
                    hpMax = 100*nivel;
                    dano = 100*nivel;
                    speed = 100 * nivel;
                    inimigo1 = Instantiate(tipoMonstro[classifMonst], new Vector3 (spawPointMonstro[pontSpaw].transform.position.x, spawPointMonstro[pontSpaw].transform.position.y, -0.5f) , Quaternion.Euler(0, 0, 0));
                    pontSpaw++;
                    break;
                case 1:
                    Debug.Log("Monstro 1");
                    hpMax = 200*nivel;
                    dano = 200 * nivel;
                    speed = 200 * nivel;
                    inimigo1 = Instantiate(tipoMonstro[classifMonst], new Vector3(spawPointMonstro[pontSpaw].transform.position.x, spawPointMonstro[pontSpaw].transform.position.y, -0.5f), Quaternion.Euler(0, 0, 0));
                    pontSpaw++;
                    break;
                default:
                    Debug.LogError("não foi possivel criar inimigo");
                    break;
            }
            valor++;
            Debug.Log(this.name + " - monstro " + inimigo1.name + " qnt de spaw: " + valor);
        }

    }

}
