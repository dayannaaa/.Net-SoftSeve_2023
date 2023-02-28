class Animal
{
    public string Species { get; set; }
    public double Speed { get; set; }
    public double Weight { get; set; }
    public string Habitat { get; set; }

    public virtual void Move()
    {
        Console.WriteLine("The animal moves.");
    }

    public virtual void MakeSound()
    {
        Console.WriteLine("The animal makes a sound.");
    }

    public virtual void Show()
    {
        Console.WriteLine($"Species: {Species}\nSpeed: {Speed}\nWeight: {Weight}\nHabitat: {Habitat}");
    }
}

class Bird : Animal
{
    public bool CanFly { get; set; }

    public override void Move()
    {
        Console.WriteLine("The bird flies.");
    }

    public override void MakeSound()
    {
        Console.WriteLine("The bird chirps.");
    }

    public override void Show()
    {
        Console.WriteLine($"Species: {Species}\nSpeed: {Speed}\nWeight: {Weight}\nHabitat: {Habitat}\nCan Fly: {CanFly}\n");
    }
}

class Eagle : Bird
{
    public Eagle()
    {
        Species = "Eagle";
        Speed = 120; 
        Weight = 6.5; 
        Habitat = "Mountains";
        CanFly = true;
    }
}

class Reptile : Animal
{
    public bool IsColdBlooded { get; set; }

    public override void Move()
    {
        Console.WriteLine("The reptile crawls or slithers.");
    }

    public override void MakeSound()
    {
        Console.WriteLine("The reptile hisses.");
    }

    public override void Show()
    {
        Console.WriteLine($"Species: {Species}\nSpeed: {Speed}\nWeight: {Weight}\nHabitat: {Habitat}\nIs Cold-Blooded: {IsColdBlooded}");
    }
}

class Crocodile : Reptile
{
    public Crocodile()
    {
        Species = "Crocodile";
        Speed = 29;
        Weight = 500;
        Habitat = "Rivers and swamps";
        IsColdBlooded = true;
    }
}

class Fish : Animal
{
    public string WaterType { get; set; }

    public override void Move()
    {
        Console.WriteLine("The fish swims.");
    }

    public override void MakeSound()
    {
        Console.WriteLine("The fish does not make sounds.");
    }

    public override void Show()
    {
        Console.WriteLine($"Species: {Species}\nSpeed: {Speed}\nWeight: {Weight}\nHabitat: {Habitat}\nWater Type: {WaterType}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Eagle eagle = new Eagle();
        eagle.Show();
        eagle.MakeSound();
        eagle.Move();

        Fish fish = new Fish();
        fish.Show();
        fish.MakeSound();
        fish.Move(); 


    }
}
