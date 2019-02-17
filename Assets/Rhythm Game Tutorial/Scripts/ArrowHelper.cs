using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHelper : MonoBehaviour
{
    public Transform LeftNote;
    public Transform UpNote;
    public Transform RightNote;
    public Transform DownNote;
    public bool hasStarted;
    public float tempo;
    public Transform[] Notes;
    public int numberOfArrows;
    public int xAxisPosition;

    private List<Transform> instances = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        print("ARROW HELPER START");
        GenerateArrows();
        tempo = tempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        else
        {
            if (instances.Count > 0)
            {
                foreach (Transform arrow in instances)
                {
                    Vector3 temp = new Vector3(arrow.position.x - tempo * Time.deltaTime, 2.93f, 0f);
                    arrow.position -= new Vector3(tempo * Time.deltaTime, 0f, 0f);
                }

            }
            else
            {
                GenerateArrows();
            }

            bool clear = true;

            foreach (Transform arrow in instances)
            {
                if (arrow.gameObject.activeSelf)
                {
                    clear = false;
                }
            }

            if (clear)
            {
                instances.Clear();
                print("CLEAR");
            }

        }
    }

    void GenerateArrows()
    {
        xAxisPosition = 0;
        Notes = new Transform[4];
        Notes[0] = LeftNote;
        Notes[1] = UpNote;
        Notes[2] = RightNote;
        Notes[3] = DownNote;
        for (int i = 0; i < numberOfArrows; i++)
        {
            var nextArrow = Notes[1]; //Notes[Random.Range(0, Notes.Length)];

            var instance = Instantiate(nextArrow) as Transform;
            instances.Add(instance);

            instance.localPosition = new Vector3((float)(-1.52 + 1 * xAxisPosition), 2.93f, 0f);
            xAxisPosition++;

        }
    }


}
