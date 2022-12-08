using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public float radius;
    private float[] distances;
    private GameObject[] circles;


    private void Start() {

        circles = GameObject.FindGameObjectsWithTag("circle");
        distances = new float[circles.Length];
        updateDistances();

        Color objColor = gameObject.GetComponent<SpriteRenderer>().color;
        //GetComponent<SpriteRenderer>().color = new Color(objColor.r,objColor.g,objColor.b,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(cursorPos.x, cursorPos.y, transform.position.z);
        //transform.position.z = 2;
        updateDistances();
        updateRadius();
    }

    

    public void updateRadius(){


        /*float[] distancesInter = distances;
        for (int k = 0; k < distancesInter.Length; k++)
        {
            distancesInter[k] -= circles[k].transform.localScale.x;
        }*/
        
        float minDistance = Mathf.Min(distances);
        int i = System.Array.IndexOf(distances, minDistance);

        float[] secondDistancesTable = distances;
        List<float> d_List = new List<float>(secondDistancesTable);
        d_List.RemoveAt(i);
        float[] newArray = d_List.ToArray();

        Debug.Log(newArray.Length);
        float secondMinDistance = Mathf.Min(newArray);
        int j = System.Array.IndexOf(distances, secondMinDistance);

        radius = Mathf.Min(containingDistance(distances[i], circles[i]) , intersectingDistance(distances[j], circles[j]));
        //radius +=1;
        //GetComponent<CircleCollider2D>().radius = radius/4;
        //
        transform.localScale = new Vector2(radius *2, radius *2);
    }

    public void updateDistances(){
        for (var i = 0; i < circles.Length; i++)
        {
            distances[i] = distance(circles[i]);
        }
    }

    public float distance(GameObject obj){
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return (Mathf.Sqrt(Mathf.Pow(obj.transform.position.y - cursorPos.y,2f) + Mathf.Pow(obj.transform.position.x - cursorPos.x,2f) ));
    }

    public float intersectingDistance(float distance, GameObject obj){
        return distance - obj.transform.localScale.x;
    }

    public float containingDistance(float distance, GameObject obj){
        return distance + obj.transform.localScale.x;
    }

    public float getRadius(){
        return radius;
    }

   
}
