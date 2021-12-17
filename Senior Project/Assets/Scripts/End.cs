using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public GameObject END;
    public GameObject HUD;
    public GameObject dialogueHUD;
    public Text nameplate;
    public Text textbox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Global.Interests = Global.Sayaka + Global.Kyoko + Global.Aoi + Global.Knife + Global.Katana;
        if (Global.Interests == 4 & Global.Sayaka2 == 1)
        {
            StartCoroutine(Endgame());
        }
    }

    private IEnumerator Endgame()
    {
        HUD.SetActive(false);
            END.SetActive(true);
            dialogueHUD.SetActive(true);
            nameplate.text = "Monokuma";
            textbox.text = "Welp, I'm bored. Let's move onto the class trial and find the blackened, or everyone else dies.";
        //Stream reader the ending txt file for Monokuma here. Would have done this if I could get interaction to work better. For now the one line works
        yield return new WaitUntil(() => Input.GetButtonDown("Fire1"));
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("Menu");
    }
}
