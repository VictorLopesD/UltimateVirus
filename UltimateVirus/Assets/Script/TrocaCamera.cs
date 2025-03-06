using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrocaCamera : MonoBehaviour
{
    [SerializeField]
    GameObject camBattle, camRPG;
    [SerializeField]
    public bool batalhaAtivada;
    [SerializeField]
    Transform Jogador;
    // Start is called before the first frame update
    void Start()
    {
        camBattle.SetActive(false);
        camRPG.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        camRPG.transform.LookAt(Jogador.position);
       camRPG.transform.position = new Vector3 (Jogador.transform.position.x,Jogador.transform.position.y, camRPG.transform.position.z);
    }

    public void BatalhaAtiva()
    {
        camBattle.SetActive(true);
        camRPG.SetActive(false);
        batalhaAtivada = true;

    }
    public void BatalhaFim()
    {
        camBattle.SetActive(false);
        camRPG.SetActive(true);
        batalhaAtivada = false;

    }
}
