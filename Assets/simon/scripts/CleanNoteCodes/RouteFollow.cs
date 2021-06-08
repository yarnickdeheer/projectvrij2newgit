using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteFollow : MonoBehaviour
{
    [SerializeField]

    public Transform[] routes;

    private int routeToGo;
    
    private float tParam;

    private Vector3 objectPosition;

    private float speedModifier;
    public float speedInDistance;

    private bool coroutineAllowed;


    [Range(-2.0f, 2.0f)]
    public float sideToSide;

    private CleanNotes notes;

    private List<int> privateNoteList;

    //public int[] forwards;
    //public int[] backwards;
    public int[] right;
    public int[] left;

    // Start is called before the first frame update

    void Start()
    {
        privateNoteList = new List<int>();
        notes = FindObjectOfType<CleanNotes>();
        routeToGo = 0;
        tParam = 0f;
        speedModifier = 0.5f;
        speedInDistance = 0f;
        coroutineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(GoByTheRoute(routeToGo));
        }

        //Vector3 p0 = routes[0].GetChild(0).position;
        //Vector3 p1 = routes[0].GetChild(1).position;
        //Vector3 p2 = routes[0].GetChild(2).position;
        //Vector3 p3 = routes[0].GetChild(3).position;

        //objectPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;
        //transform.position = objectPosition;

        if (notes.checkNoteInput() > -1)
            privateNoteList.Add(notes.checkNoteInput());

        notes.cleanLastPlayedNotes(privateNoteList);
        ///Debug.Log(privateNoteList[0]);

        int correctInput = goThroughOptions(new int[][] { right, left });
        if (correctInput > -1)
        {
            switch (correctInput)
            {
                case -1:
                    break;

                case 0:
                    sideToSide += Time.deltaTime;
                    //go right
                    break;

                case 1:
                    sideToSide -= Time.deltaTime;
                    //go left
                    break;

                    //case 2:
                    //    //go right
                    //    break;

                    //case 3:
                    //    //go left
                    //    break;

            }
        }

        sideToSide = Mathf.Clamp(sideToSide, -2f, 2f);
    }

    public static float BezierSingleLength(Vector3[] points)
    {
        var p0 = points[0] - points[1];
        var p1 = points[2] - points[1];
        var p2 = new Vector3();
        var p3 = points[3] - points[2];

        var l0 = p0.magnitude;
        var l1 = p1.magnitude;
        var l3 = p3.magnitude;
        if (l0 > 0) p0 /= l0;
        if (l1 > 0) p1 /= l1;
        if (l3 > 0) p3 /= l3;

        p2 = -p1;
        var a = Mathf.Abs(Vector3.Dot(p0, p1)) + Mathf.Abs(Vector3.Dot(p2, p3));
        if (a > 1.98f || l0 + l1 + l3 < (4 - a) * 8) return l0 + l1 + l3;

        var bl = new Vector3[4];
        var br = new Vector3[4];

        bl[0] = points[0];
        bl[1] = (points[0] + points[1]) * 0.5f;

        var mid = (points[1] + points[2]) * 0.5f;

        bl[2] = (bl[1] + mid) * 0.5f;
        br[3] = points[3];
        br[2] = (points[2] + points[3]) * 0.5f;
        br[1] = (br[2] + mid) * 0.5f;
        br[0] = (br[1] + bl[2]) * 0.5f;
        bl[3] = br[0];

        return BezierSingleLength(bl) + BezierSingleLength(br);
    }

        int goThroughOptions(int[][] options)
    {
        for (int k = 0; k < options.Length; k++)
        {
            for (int i = 0; i < privateNoteList.Count; i++)
            {
                if(i > options[k].Length - 2)
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



    private IEnumerator GoByTheRoute(int routeNum)
    {
        if (routeToGo > routes.Length - 1)
        {
            routeToGo = 0;
        }
        coroutineAllowed = false;
        //float coveredDistance = 0;

        Vector3 p0 = routes[routeNum].GetChild(0).position;
        Vector3 p1 = routes[routeNum].GetChild(1).position;
        Vector3 p2 = routes[routeNum].GetChild(2).position;
        Vector3 p3 = routes[routeNum].GetChild(3).position;

        Vector3[] points = new Vector3[] { routes[routeNum].GetChild(0).position, routes[routeNum].GetChild(1).position, routes[routeNum].GetChild(2).position, routes[routeNum].GetChild(3).position };
        float length = BezierSingleLength(points);
        Debug.Log(length);

        // (1/length) * distance

        while (tParam < 1)
        {
            //hier gaat het percentage omhoog elke loop
            //tParam = (1/length) * coveredDistance;
            //tParam = tParam + Llength(t2⋅v⃗ 1+t⋅v⃗ 2+v⃗ 3)
            Vector3 v1 = -3 * p0 + 9 * p1 - 9 * p2 + 3 * p3;
            Vector3 v2 = 6 * p0 - 12 * p1 + 6 * p2;
            Vector3 v3 = -3 * p0 + 3 * p1;
            tParam = tParam + ((Time.deltaTime * speedInDistance) / Vector3.Magnitude(Mathf.Pow(tParam, 2) * v1 + tParam * v2 + v3));
//            Debug.Log(tParam);
            Vector3 oldPos = transform.position;
            if (objectPosition != null)
            {
                oldPos = objectPosition;
            }

            //This is working with percentages, but we want it to work with distance, so the speed is constantly the same
            //het is een lastige formule om aan te passen, wat ik kan doen is de afstand in percentage om te zetten en dat te gebruiken
            objectPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3; 

            transform.forward = oldPos - objectPosition;
            Vector3 leftToRight = transform.right * sideToSide;
            transform.position = objectPosition + leftToRight;
           // coveredDistance += Time.deltaTime * speedInDistance;
            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;
        routeToGo += 1;

        if (routeToGo > routes.Length - 1)
        {
            coroutineAllowed = false;
        }
        else
        {
            coroutineAllowed = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if(collision is een steen)
        //sterf

        //if(collision.gameObject.tag == "Player")
        //{
        //    collision.transform.SetParent(transform);
        //}
    }

    private void OnCollisionExit(Collision collision)
    {
        //if (collision.gameObject.tag == "Player")
        //{
        //    collision.transform.SetParent(null);
        //}
    }
}
