using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public Collider2D checkRoom;


    private void Update()
    {
        checkRoom = Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("SpawPoint"));
        
            if (checkRoom != null && checkRoom.gameObject == checkRoom.CompareTag("Spawpoint"))
        {
            Debug.LogWarning("Objeto: " + checkRoom.gameObject.name + " destruido");
            Destroy(checkRoom.gameObject);
            checkRoom = null;
        }
    }
       
}
