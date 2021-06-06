using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMODUnity;

public class CleanNotes : MonoBehaviour
{
    public List<int> PlayedNotes = new List<int>();

    public KeyCode firstNoteInput;
    public KeyCode secondNoteInput;
    public KeyCode thirdNoteInput;
    public KeyCode fourthNoteInput;

    public GameObject[] NotePrefabs;
    private Canvas canvas;
    public Vector3[] NoteStartLoc;

    public StudioEventEmitter noteHandler;
    int fmodNote = -2;

    // Start is called before the first frame update
    void Awake()
    {
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
        }

        noteHandler.SetParameter("Noot", fmodNote + 1, false);
        if (!noteHandler.IsPlaying())
            noteHandler.Play();
        
        
        //en als er input was, geven we dat door aan een andere functie die ze op het scherm zet
        if (noteThisUpdate >= 0)
        {
            PlayedNotes.Add(noteThisUpdate);
            UpdateNoteOnScreen(noteThisUpdate);
        }

        cleanLastPlayedNotes(PlayedNotes);
    }

    public int checkNoteInput()
    {
        if (Input.GetKeyDown(firstNoteInput))
        {
            return 0;
        }

        if (Input.GetKeyDown(secondNoteInput))
        {
            return 1;
        }

        if (Input.GetKeyDown(thirdNoteInput))
        {
            return 2;
        }

        if (Input.GetKeyDown(fourthNoteInput))
        {
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
