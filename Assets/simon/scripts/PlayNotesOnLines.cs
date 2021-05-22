using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayNotesOnLines : MonoBehaviour
{
    public GameObject notePrefab;

    public List<Transform> Lines;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            checkInput();
        }
    }

    void checkInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playNote(Lines[0], Color.blue);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playNote(Lines[1], Color.yellow);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playNote(Lines[2], Color.red);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playNote(Lines[3], Color.green);
            return;
        }
    }

    void playNote(Transform startLine, Color noteColor)
    {
        GameObject temp = Instantiate(notePrefab, startLine.position, new Quaternion(0, 0, 0, 0), startLine);
        temp.GetComponent<Image>().color = noteColor;
        timer = 0.1f;
    }
}
