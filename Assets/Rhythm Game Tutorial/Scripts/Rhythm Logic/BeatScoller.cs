using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScoller : MonoBehaviour {

    public RectTransform LeftNote;
    public RectTransform UpNote;
    public RectTransform RightNote;
    public RectTransform DownNote;
    public RectTransform[] Notes;
    private List<RectTransform> instances = new List<RectTransform>();
    public float xAxisPosition;
    public float tempo;
	public bool hasStarted;
    private int numberOfArrows;

    public static int numNotes;

	// Use this for initialization
	void Start () {
		tempo = tempo / 60f;
        numNotes = 0;

        numberOfArrows = Random.Range(5, 10);
        GenerateArrows();

        numNotes = GetComponentsInChildren<RectTransform>().GetLength(0);
        print(numNotes.ToString());
        //Debug.Log(numNotes.ToString());
    }
	
	// Update is called once per frame
	void Update () {
        numNotes = GetComponentsInChildren<RectTransform>().GetLength(0);

        //Debug.Log(numNotes.ToString());
        if (!hasStarted)    
		{
			if(Input.anyKeyDown){
				hasStarted = true;
			}
		}
		else
		{
            //transform.position -= new Vector3(0f, tempo*Time.deltaTime, 0f);

            if (instances.Count > 0)
            {
                foreach (RectTransform arrow in instances)
                {
                    Vector3 temp = new Vector3(arrow.position.x - tempo * Time.deltaTime, arrow.position.y, 0f);
                    arrow.position -= new Vector3(tempo * Time.deltaTime, 0f, 0f);
                }

            }
            else
            {
                numberOfArrows = Random.Range(5, 10);
                GenerateArrows();
            }

            bool clear = true;

            foreach (RectTransform arrow in instances)
            {
                if (arrow.gameObject.activeSelf)
                {
                    clear = false;
                }
            }

            if (clear)
            {
                instances.Clear();
                numNotes = 0;
                print("CLEAR");
            }
        }
	}

    void GenerateArrows()
    {
        xAxisPosition = 0;
        Notes = new RectTransform[4];
        Notes[0] = LeftNote;
        Notes[1] = UpNote;
        Notes[2] = RightNote;
        Notes[3] = DownNote;
        for (int i = 0; i < numberOfArrows; i++)
        {
            var nextArrow = Notes[Random.Range(0, Notes.Length)];

            var instance = Instantiate(nextArrow) as RectTransform;

            instance.transform.SetParent(transform, false);
            instances.Add(instance);

            instance.localPosition = new Vector3(transform.localPosition.x + 100f * xAxisPosition, 0f, 0f);
            xAxisPosition++;

        }
    }
}