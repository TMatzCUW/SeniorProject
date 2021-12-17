using UnityEngine;

public class Click : MonoBehaviour
{
    public float range = 10f;
    public Camera fpsCam;
    public GameObject dialogueBox;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))//Maybe this being in update causes clicks to not be "counted" but the debug works fine so I'm stumped
        {
            interact();
        }
    }

    void interact()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            
            Target target = hit.transform.GetComponent<Target>();//I'm assuming around here is where the problem is that causes doors and objects to not work consistently
            if (target != null)
            {
                target.interacted();
            }
            Debug.Log(hit.transform.name);//Essentially a check to see that the click is registered, which it is
        }
    }
}
