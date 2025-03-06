using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviJogador : MonoBehaviour
{
    TrocaCamera trocaCamera;
    float velocidadeJogador = 5f;
    // Start is called before the first frame update
    void Start()
    {
        trocaCamera = FindObjectOfType<TrocaCamera>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!trocaCamera.batalhaAtivada)
        {
            Movimentarjogador();
        }
       


    }

    public void Movimentarjogador()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movimento = new Vector2(horizontal, vertical)* velocidadeJogador * Time.deltaTime;

        transform.Translate(movimento);
    }


}
