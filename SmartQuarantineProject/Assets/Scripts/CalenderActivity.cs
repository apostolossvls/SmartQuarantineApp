using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalenderActivity : MonoBehaviour
{
    public enum ActivityType {
        Work = 0, Doctor = 1, Shop = 2, Bank = 3,
        Help = 4, Funeral = 5, Workout = 6};
    public enum MovementType {
        Car = 0, OnFoot = 1, PublicTransport};
    public ActivityType type;
    public List<CalenderOrder> orders;
    public string time;
    public MovementType movement;
    public bool activated = false;

    public void SetType(int value){
        type = (ActivityType) value;
    }

    public void SetTime(string value){
        time = value;
    }

    public void SetMovement(int value){
        movement = (MovementType) value;
    }
}
