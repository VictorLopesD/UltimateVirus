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
    public Transform mapaAtivo;
    // Start is called before the first frame update
    void Start()
    {
        camBattle.SetActive(false);
        camRPG.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        camRPG.transform.LookAt(mapaAtivo.position);
       camRPG.transform.position = new Vector3 (mapaAtivo.transform.position.x, mapaAtivo.transform.position.y, camRPG.transform.position.z);
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
