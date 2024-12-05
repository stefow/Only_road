using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ListOfAnimals", menuName = "AnimalsList", order = 1)]
public class AnimalList : ScriptableObject
{
    public List<Animals> Animals;
}

[CreateAssetMenu(fileName = "ListOfVehicles", menuName = "VehiclessList", order = 1)]
public class VehicleslList : ScriptableObject
{
    public List<Vehicles> Vehicles;
}

[System.Serializable]
public class Animals
{
    public string Name;
    public int id;
    public string Description;
    public double Price;
    public GameObject AnimalGameObject;

    public Animals(int id, string name, string description, double price, GameObject gameObject)
    {
        this.id = id;
        Name = name;
        Description = description;
        Price = price;
        AnimalGameObject = gameObject;
    }
}

[System.Serializable]
public class Vehicles
{
    public string Name;
    public int id;
    public string Description;
    public double Price;
    public GameObject VehiclesGameObject;

    public Vehicles(int id, string name, string description, double price, GameObject gameObject)
    {
        this.id = id;
        Name = name;
        Description = description;
        Price = price;
        VehiclesGameObject = gameObject;
    }
}