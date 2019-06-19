using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour {

    public bool showDialogue, grid;
    public Vector2 scr;
    public string[] dialogueText;
    public int dialogueIndex;
    public int dialogueOptionIndex; // to use later
    private void OnGUI()
    {
        if (showDialogue)
        {

            //if screen measure units is not at 16:9 ration
            if (scr.x != Screen.width /16 || scr.y != Screen.height /9)
            {
                scr.x = Screen.width / 16;
                scr.y = Screen.height / 9;
            }

            GUI.Box(new Rect(0, scr.y * 6, scr.x*16, scr.y*3), dialogueText[dialogueIndex]);
            if (!(dialogueIndex + 1 >= dialogueText.Length - 1 || dialogueIndex == dialogueOptionIndex))
            {
                if (GUI.Button(new Rect(scr.x*15f, scr.y*8.5f, scr.x, scr.y*0.5f), "Next"))
                {
                    dialogueIndex++;
                }
            }
            else if (dialogueIndex == dialogueOptionIndex)
            {
                if (GUI.Button(new Rect(scr.x * 13f, scr.y * 8.5f, scr.x, scr.y * 0.5f), "Accept"))
                {
                    dialogueIndex ++;
                                       
                }
                if (GUI.Button(new Rect(scr.x * 14f, scr.y * 8.5f, scr.x, scr.y * 0.5f), "Decline"))
                {
                    dialogueIndex = dialogueText.Length - 1;

                }
            }
            else
            {
                if (GUI.Button(new Rect(scr.x * 15f, scr.y * 8.5f, scr.x, scr.y * 0.5f), "Bye"))
                {
                    dialogueIndex = 0;
                    showDialogue = false;
                    Movement.canMove = true;
                    //we are not doing this for our game
                    //Cursor.lockState = CursorLockMode.Locked;
                    //Cursor.visible = false;
                    //enable camera and player movement
                }
            }
            


            if (grid)
            {
                for (int x = 0; x < 16; x++)
                {
                    for (int y = 0; y < 9; y++)
                    {
                        GUI.Box(new Rect(scr.x * x, scr.y * y, scr.x, scr.y), "");
                    }
                }
            }
        }
    }
}
