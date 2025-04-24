using UnityEngine;

public class BaseAtributos : MonoBehaviour
{
    public GameObject[] tipoMonstro;
    public GameObject[] spawPointMonstro;
    int classifMonst;
    public int hpMax;
    public int dano;
    public float speed;
    public int nivel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        GerarAtributos(tipoMonstro, 0,4);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GerarAtributos(GameObject[] vetTipoMonstro, int valorMin, int valorMax)
    {
        int valor  = Random.Range(valorMin, valorMax);
        int pontSpaw = 0;
        nivel = 1 * nivel;
        classifMonst = Random.Range(valorMin, this.tipoMonstro.Length);
        if (pontSpaw <= spawPointMonstro.Length)
        {
            switch (classifMonst)
            {
                case 0:
                    Debug.Log("Monstro 0");
                    hpMax = 100*nivel;
                    dano = 100*nivel;
                    speed = 100 * nivel;
                    Instantiate(tipoMonstro[classifMonst], spawPointMonstro[pontSpaw].transform.position, Quaternion.Euler(0, 0, 0));
                    pontSpaw++;
                    break;
                case 1:
                    Debug.Log("Monstro 1");
                    hpMax = 200*nivel;
                    dano = 200 * nivel;
                    speed = 200 * nivel;
                    Instantiate(tipoMonstro[classifMonst], spawPointMonstro[pontSpaw].transform.position, Quaternion.Euler(0, 0, 0));
                    pontSpaw++;
                    break;
                default:
                    Debug.LogError("não foi possivel criar inimigo");
                    break;
            }

        }

    }

}
