using System;
using Unity;
using UnityEngine;


//Base Class
public class Car
{
    float milesDriven;

    float gasUsed;

    public virtual void MilesPerGallon(float milesDriven,float gasUsed)
    {
        Debug.Log(milesDriven / gasUsed);

    }
}


public class ElectricCar : Car
{

    public override void MilesPerGallon(float milesDriven, float gasUsed)
    {
        Debug.Log(milesDriven / 0);
    }
    
}

