
Console.WriteLine("Following is an example of Thread synchronisation with semaphores and the \"Racing Simulator\" exercies");
Console.WriteLine("If you find any mistakes or want to give feedback contact the author Gabriel Lugmayr.\n");

new Thread(() => new Car("1").WaitForSignal()).Start();
new Thread(() => new Car("2").WaitForSignal()).Start();
new Thread(() => new Car("3").WaitForSignal()).Start();
new Thread(() => new Car("4").WaitForSignal()).Start();
new Thread(() => new Car("5").WaitForSignal()).Start();

new Thread(() => new Race().Start()).Start();

static class Sems
{
    public static Random Random = new Random();
    public static Semaphore StartRace = new Semaphore(0, 5);
    public static Semaphore Pit = new Semaphore(3, 3);
}

class Car
{
    public Car(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
    public void WaitForSignal()
    {
        Sems.StartRace.WaitOne();

        Console.WriteLine(Name + ":\tcar race started");
        Race();

        Console.WriteLine(Name + ":\twaiting for pit");
        Sems.Pit.WaitOne();

        Console.WriteLine(Name + ":\tin pit");
        TakingPitStop();

        Console.WriteLine(Name + ":\texit pit");
        Sems.Pit.Release();

        Race();
        Console.WriteLine(Name + ":\tfinished");
    }

    public void Race()
    {
        Thread.Sleep(Sems.Random.Next(0, 500));
    }

    public void TakingPitStop()
    {
        Thread.Sleep(Sems.Random.Next(500, 1500));

    }
}

class Race
{
    public void Start()
    {
        Sems.StartRace.Release();
        Sems.StartRace.Release();
        Sems.StartRace.Release();
        Sems.StartRace.Release();
        Sems.StartRace.Release();
    }
}