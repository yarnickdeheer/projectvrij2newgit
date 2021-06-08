using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMODUnity;

public class CleanNotes : MonoBehaviour
{
    public List<int> PlayedNotes;

    public KeyCode firstNoteInput;
    public KeyCode secondNoteInput;
    public KeyCode thirdNoteInput;
    public KeyCode fourthNoteInput;
    private bool canPlayNote = true;

    public GameObject[] NotePrefabs;
    private Canvas canvas;
    public Vector3[] NoteStartLoc;
    public Animator player;
    public StudioEventEmitter noteHandler;
    public StudioEventEmitter grabAlto;
    int fmodNote = -2;


    public SpriteRenderer alto;

    // Start is called before the first frame update
    void Awake()
    {
        PlayedNotes = new List<int>() { -1, -1, -1, -1 };
        //als we meer canvasses hebben is dit onhandig, maar slepen in de editor is ook weer naar
        canvas = FindObjectOfType<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        //hier checken we voor input
        int noteThisUpdate = checkNoteInput();
   

        if (checkNoteKeyLifted() == fmodNote || fmodNote == -2)
        {
            fmodNote = noteThisUpdate;
            canPlayNote = true;
            noteHandler.SetParameter("Noot", fmodNote + 1, false);
        }
        
        
        //en als er input was, geven we dat door aan een andere functie die ze op het scherm zet
        if (noteThisUpdate >= 0 && canPlayNote == true)
        {
            PlayedNotes.Add(noteThisUpdate);
            UpdateNoteOnScreen(noteThisUpdate);
            canPlayNote = false;
        }

        cleanLastPlayedNotes(PlayedNotes);
    }

    public int checkNoteInput()
    {
        if (Input.GetKeyDown(firstNoteInput))
        {
            if (player.GetBool("viool") == false && grabAlto.IsPlaying() == false)
            {
                grabAlto.Play();
            }
            player.SetBool("viool", true);

            alto.enabled = false;
            return 0;
        }

        if (Input.GetKeyDown(secondNoteInput))
        {
            if (player.GetBool("viool") == false && grabAlto.IsPlaying() == false)
            {
                grabAlto.Play();
            }
            player.SetBool("viool", true);

            alto.enabled = false;
            return 1;
        }

        if (Input.GetKeyDown(thirdNoteInput))
        {
            if (player.GetBool("viool") == false && grabAlto.IsPlaying() == false)
            {
                grabAlto.Play();
            }
            player.SetBool("viool", true);

            alto.enabled = false;
            return 2;
        }

        if (Input.GetKeyDown(fourthNoteInput))
        {
            if (player.GetBool("viool") == false && grabAlto.IsPlaying() == false)
            {
                grabAlto.Play();
            }
            player.SetBool("viool", true);

            alto.enabled = false;
            return 3; 
        }

        return -1;
    }

    public int checkNoteKeyLifted()
    {
        if (Input.GetKeyUp(firstNoteInput))
        {
            return 0;
        }

        if (Input.GetKeyUp(secondNoteInput))
        {
            return 1;
        }

        if (Input.GetKeyUp(thirdNoteInput))
        {
            return 2;
        }

        if (Input.GetKeyUp(fourthNoteInput))
        {
            return 3;
        }

        return -1;
    }

    void UpdateNoteOnScreen(int whatNote)
    {
        if (NotePrefabs.Length > 0)
            Instantiate(NotePrefabs[whatNote], NoteStartLoc[whatNote], new Quaternion(0, 0, 0, 0), canvas.transform.GetChild(1).transform);
    }

    public void cleanLastPlayedNotes(List<int> played)
    {
        while(played.Count > 4)
        {
            played.RemoveAt(0);
        }
    }
}
