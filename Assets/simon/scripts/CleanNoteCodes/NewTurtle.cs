using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTurtle : MonoBehaviour
{
    //ok ik moet dus een path kunnen maken van transforms
    //ik kan recht van punt naar punt doen en
    //van punt naar punt maar met een bocht erin
    //Dat doe ik door tussen de punten een transform te zetten en te zeggen dat dat de curvature is

    private CleanNotes notes;

    private List<int> privateNoteList;

    public int[] forwards;
    public int[] backwards;
    public int[] right;
    public int[] left;
    // Start is called before the first frame update
    void Start()
    {
        notes = FindObjectOfType<CleanNotes>();
    }

    // Update is called once per frame
    void Update()
    {
        privateNoteList.Add(notes.checkNoteInput());
        notes.cleanLastPlayedNotes(privateNoteList);

        int correctInput = goThroughOptions(new int[][] { forwards, backwards, right, left });
        if (correctInput >= 0)
        {
            switch (correctInput)
            {
                case 0:
                    //go forward
                    break;

                case 1:
                    //go back
                    break;

                case 2:
                    //go right
                    break;

                case 3:
                    //go left
                    break;

            }
        }
    }

    int goThroughOptions(int[][] options)
    {
        for (int k = 0; k < options.Length; k++)
        {
            for (int i = 0; i < privateNoteList.Count; i++)
            {
                if(i > options[k].Length - 1)
                {
                    return k;
                }

                if(options[k][i] != privateNoteList[i])
                {
                    break;
                }
            }
        }

        return -1;
    }
}
