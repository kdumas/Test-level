using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {


void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "Player" && Items.keys > 0)
        {
            Items.keys--;
            Destroy(gameObject);
            Debug.Log(Items.keys);
        }
    }

}
