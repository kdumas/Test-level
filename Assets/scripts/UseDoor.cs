using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UseDoor : MonoBehaviour {

    public Text DoorText;
    public float CloseDoorTime;
    bool EnterDoor;
    bool UsedDoor;
    bool key;
    Animator DoorAnim;
    public int waste;
    

    void Start ()
    {

        DoorText.enabled = false;
        EnterDoor = false;
        UsedDoor = false;
        DoorAnim = GetComponent<Animator>();

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "player" && Items.keys > 0)
        {
            Items.keys--;
        }
    }
    void OnTriggerStay(Collider Player)
    {
        if (Player.gameObject.CompareTag("Player"))
        {
            EnterDoor = true;
            DoorText.enabled = true;
        }
    }
    void OnTriggerExit(Collider Player)
    {
        if (Player.gameObject.CompareTag("Player"))
        {
            DoorText.enabled = false;
            EnterDoor = false;
        }

        if (UsedDoor)
        {
            Invoke("DoorClose", CloseDoorTime);

        }
    }
 
        void update(){

            if (Input.GetKeyDown(KeyCode.E) & (EnterDoor))
            {
                DoorAnim.SetTrigger("DoorOpen");
                UsedDoor = true;

            }
        }

    

    void DoorClose()
    {
        DoorAnim.SetTrigger("DoorClose");
        UsedDoor = false;
    }
}
