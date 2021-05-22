using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    public List<int> forwards;
    public List<int> backwards;
    public List<int> right;
    public List<int> left;
    public List<int> still;

    private List<int> lastFourNotes;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        lastFourNotes = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        inputCheck();
        if(lastFourNotes.Count > 4)
        {
            lastFourNotes.Remove(lastFourNotes[0]);
        }

        checkInputPossibilities();

        transform.position += moveDirection * 0.5f;

        if (lastFourNotes.Count == 4)
        {
            Debug.Log(lastFourNotes[0] + "" + lastFourNotes[1] + "" + lastFourNotes[2] + "" + lastFourNotes[3]);
        }
    }

    void inputCheck()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            lastFourNotes.Add(0);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            lastFourNotes.Add(1);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            lastFourNotes.Add(2);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            lastFourNotes.Add(3);
            return;
        }
    }

    void checkInputPossibilities()
    {
        if(compareIntLists(lastFourNotes, forwards))
        {
            Debug.Log("go forward");
            moveDirection = new Vector3(0, 0, 1);
            lastFourNotes.Clear();
            return;
        }

        if(compareIntLists(lastFourNotes, backwards))
        {
            //backwards
            moveDirection = new Vector3(0, 0, -1);
            lastFourNotes.Clear();
            return;
        }

        if(compareIntLists(lastFourNotes, right))
        {
            //right
            moveDirection = new Vector3(1, 0, 0);
            lastFourNotes.Clear();
            return;
        }

        if(compareIntLists(lastFourNotes, left))
        {
            //left
            moveDirection = new Vector3(-1, 0, 0);
            lastFourNotes.Clear();
            return;
        }

        if (compareIntLists(lastFourNotes, still))
        {
            //stand still
            moveDirection = new Vector3(0, 0, 0);
            lastFourNotes.Clear();
            return;
        }
    }

    bool compareIntLists(List<int> one, List<int> two)
    {
        if(one.Count == two.Count)
        {
            for(int i = 0; i < one.Count; i++)
            {
                if(one[i] != two[i])
                {
                    return false;
                }
            }

            return true;
        }

        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}
