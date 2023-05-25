using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal
{
    public int age;
    public int legNumber;

    public void Eat() {
        Debug.Log("Chomp");
    }
}

public class Human : Animal
{

    public void DriveCar() {
        Debug.Log("Honk Honk Swerve!");
    }
}


public class Dog : Animal
{

    public void Bark()
    {
        Debug.Log("woof woof!");
    }
}

public class Cat: Animal
{

    public void Meows()
    {
        Debug.Log("Meow");
    }
}
