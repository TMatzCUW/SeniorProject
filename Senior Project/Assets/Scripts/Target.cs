using UnityEngine;

public class Target : MonoBehaviour
{
    //To create a person/object it goes Plane object->Drag Body onto it->Make scale work for size->Rendering mode set to cutout
    public Transform teleportTarget;
    public GameObject player;
    public void interacted()
    {
        if (gameObject.tag == "Door")
        {
            player.transform.position = teleportTarget.transform.position;
        }
        else if(gameObject.tag == "Person")
        {
            //Expressions are Raw Imagaes
            //Maybe create another script for dialogue. I did
            gameObject.GetComponent<Dialogue>().dialogue();
            //Going to forgo disabling movement and stuff until later,live with jank
        }
        else if (gameObject.tag == "Object")
        {
            gameObject.GetComponent<Dialogue>().dialogue();
        }
        
    }
}
