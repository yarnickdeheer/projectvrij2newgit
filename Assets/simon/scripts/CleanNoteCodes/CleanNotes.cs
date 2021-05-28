using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void UpdateNoteOnScreen(int whatNote)
    {
        Instantiate(NotePrefabs[whatNote], NoteStartLoc[whatNote], new Quaternion(0, 0, 0, 0), canvas.transform);
    }

    public void cleanLastPlayedNotes(List<int> played)
    {
        while(played.Count > 5)
        {
            played.RemoveAt(0);
        }
    }
}
