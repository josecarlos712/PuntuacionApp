using System;
using UnityEngine;

class Configuration : MonoBehaviour
{
    public static Game game = new Game();
    public Configuration()
    {
    }

    public void Start()
    {
        Console.WriteLine("HOla");
    }
}