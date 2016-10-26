using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurnOnLamp : MonoBehaviour {

    public GameObject Lamp;
    public Text LampText;
    bool EnterLamp;

    void Start ()
    {
        Lamp.SetActive(false);
        LampText.enabled = false;
        EnterLamp = false;
    }
    void OnTriggerStay(Collider Player)
    {
        if (Player.gameObject.CompareTag("Player"))
        {
            EnterLamp = true;
            LampText.enabled = true;
        }
    }
    void OnTriggerExit(Collider Player)
    {
        if (Player.gameObject.CompareTag("Player"))
        {
            LampText.enabled = false;
            EnterLamp = false;
        }
    }
    void Update ()
    {
        if (Input.GetKeyDown (KeyCode.E) & (EnterLamp))
        {
            if (Lamp.activeSelf)
                Lamp.SetActive(false);
            else
                Lamp.SetActive(true);
        }
    }
}
