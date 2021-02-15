using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineHelpPanel : MonoBehaviour
{
    public Transform label;
    public Transform context;
    public int[] ids;
    public Transform[] marks;

    public bool Open(int id){
        bool found = false;
        for (int i = 0; i < ids.Length; i++)
        {
            bool b = ids[i] == id;
            if (b){
                found = true;
                Scroll(i);
            }
        }
        return found;
    }

    void Scroll(int index){
        float y = Mathf.Abs(marks[index].localPosition.y + 80);
        context.localPosition = new Vector3(context.localPosition.x, y, context.localPosition.z);
    }
}
