using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    //This is to hopefully make all dialogue easier to change
    public GameObject dialogueBox;
    public GameObject expression;
    public Text nameplate;
    public Text speech;
    public GameObject player;
    public GameObject character;
    public GameObject HUD;

    public void dialogue()
    {
        
        StartCoroutine(ReadString());
        
        
    }
    //I think it might be easier for me to make text files for each thing that has the lines
    IEnumerator ReadString()
    {
        dialogueBox.SetActive(true);//Displays the dialoguebox
        Cursor.lockState = CursorLockMode.Confined;//Shows mouse, using as a way to signify that dialogue is open
        nameplate.text = character.name;
        HUD.SetActive(false);//Removes the reticle
        string path = Path.Combine(Application.streamingAssetsPath, character.name + ".txt");//It works and makes organizing easy, so name the txt what its for
        if (Global.Aoi == 1 & gameObject.name=="Sayaka")//This is to get Sayaka to read the second dialogue. Would be similar if anything was to have 2 dialogues
        {
            path = Path.Combine(Application.streamingAssetsPath, "Sayaka 2.txt");
        }
        using (StreamReader reader = new StreamReader(path))
        {
            while (reader.Peek()>-1)
            {
                //It reads every even line for some reason, so keep that in mind
                string line = reader.ReadLine();
                if (line.StartsWith("-"))//Have it find the name of the character then read line after, and with each click goes to the next line until a null
                {
                    line=line.Remove(0, 1);
                    nameplate.text = line;
                    speech.text = "";
                    //See if I can get it to read the next line automatically from here, or just leave this empty and make it obvious that someone else is the new speaker
                    //I'm leaving it so it's obvious there's a new speaker
                }
                else
                {
                    speech.text = line;
                }
                
                yield return new WaitUntil(() => Input.GetButtonDown("Fire1"));
            }

           
            reader.Close();//Forgot this, so during the demo this is what caused dialogue to not work. Weirdly, worked a few hours before. My bad
            
        }
        dialogueBox.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;//for when it gets done reading
        HUD.SetActive(true);
        if (character.name == "Aoi Asahina")//All these so that game end can trigger
        {
            Global.Aoi = 1;
        }
        else if (character.name == "Kyoko Kirigiri")
        {
            Global.Kyoko = 1;
        }
        else if (character.name == "Sayaka")
        {
            Global.Sayaka = 1;
        }
        else if (character.name == "Knife")
        {
            Global.Knife = 1;
        }
        else if (path == Path.Combine(Application.streamingAssetsPath, "Sayaka 2.txt"))
        {
            Global.Sayaka2 = 1;
        }
        yield break;//Stops coroutine, in hopes that it would fix the interaction issue
    }
}
