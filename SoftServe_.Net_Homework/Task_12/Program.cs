using System;
using System.Runtime.Intrinsics.X86;
public class Task_12
{
    public abstract class CombatVehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public int Health { get; set; }

        public CombatVehicle(string type, string model, int health)
        {
            Type = type;
            Model = model;
            Health = health;
        }

        public bool IsDestroyed()
        {
            if (Health <= 0)
            {
                return false;
            }
            return true;
        }
        public virtual void ShowInfo()
        {
            Console.WriteLine($"Type: {Type} | Model: {Model} | Health: {Health}");
        }

        public abstract int Attack();
        public abstract void Defense(int damage);
    }

    public class Tank : CombatVehicle
    {
        public int RechargeTime { get; set; }
        public int ShotAccuracy { get; set; }
        public int ArmorThickness { get; set; }

        public Tank(string type, string model, int health, int rechargeTime, int shotAccuracy, int armorThickness)
            : base(type, model, health)
        {
            RechargeTime = rechargeTime;
            ShotAccuracy = shotAccuracy;
            ArmorThickness = armorThickness;
        }

        public override int Attack()
        {
            return 100 * ShotAccuracy / RechargeTime;
        }

        public override void Defense(int damage)
        {
            Health -= (damage - ArmorThickness);
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Recharge Time: {RechargeTime} | Shot Accuracy: {ShotAccuracy} | Armor Thickness: {ArmorThickness}");
        }
    }
    public class ArmoredCar : CombatVehicle
    {
        public int NumberOfWeapons { get; set; }
        public int Speed { get; set; }

        public ArmoredCar(string type, string model, int health, int numberOfWeapons, int speed)
            : base(type, model, health)
        {
            NumberOfWeapons = numberOfWeapons;
            Speed = speed;
        }

        public override int Attack()
        {
            return 50 * NumberOfWeapons;
        }

        public override void Defense(int damage)
        {
            Health -= (damage - Speed / 2);
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Number of Weapons: {NumberOfWeapons} | Speed: {Speed}");
        }
    }


    public class AirDefenseVehicle : CombatVehicle
    {
        public int RangeOfAction { get; set; }
        public int RateOfFire { get; set; }
        public int Mobility { get; set; }

        public AirDefenseVehicle(string type, string model, int health, int rangeOfAction, int rateOfFire, int mobility)
            : base(type, model, health)
        {
            RangeOfAction = rangeOfAction;
            RateOfFire = rateOfFire;
            Mobility = mobility;
        }

        public override int Attack()
        {
            return (150 + RangeOfAction * (RateOfFire / 2));
        }

        public override void Defense(int damage)
        {
            Health -= damage / Mobility;
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Range of Action: {RangeOfAction}|  RateOfFire: {RateOfFire} | Mobility: {Mobility}\n");
        }


    }
    public class TestSimulation
    {
        public static void Round(CombatVehicle bm1, CombatVehicle bm2)
        {
            bm1.Defense(bm2.Attack());
            bm2.Defense(bm1.Attack());
        }
    }
    public static void Main(string[] args)
    {
        CombatVehicle tank = new Tank("Tank", "T-34", 500, 5, 80, 50);
        CombatVehicle armoredCar = new ArmoredCar("Armored Car", "BRDM-2", 200, 3, 120);
        CombatVehicle airDefenseVehicle = new AirDefenseVehicle("Air Defense Vehicle", "S-300", 800, 20, 6, 2);


        Console.WriteLine("Before the battle:");
        tank.ShowInfo();
        armoredCar.ShowInfo();
        airDefenseVehicle.ShowInfo();
        Console.WriteLine();

        Console.WriteLine("The battle begins:");
        int round = 1;
        while (!tank.IsDestroyed() && !armoredCar.IsDestroyed())
        {
            Console.WriteLine($"Round {round}:");
            TestSimulation.Round(tank, armoredCar);
            tank.ShowInfo();
            armoredCar.ShowInfo();
            Console.WriteLine();
            round++;
        }

        Console.WriteLine("After the battle:");
        tank.ShowInfo();
        armoredCar.ShowInfo();
        Console.WriteLine();

        Console.WriteLine("The battle begins:");
        round = 1;
        while (!airDefenseVehicle.IsDestroyed() && !armoredCar.IsDestroyed())
        {
            Console.WriteLine($"Round {round}:");
            TestSimulation.Round(airDefenseVehicle, armoredCar);
            airDefenseVehicle.ShowInfo();
            armoredCar.ShowInfo();
            Console.WriteLine();
            round++;
        }

        Console.WriteLine("After the battle:");
        airDefenseVehicle.ShowInfo();
        armoredCar.ShowInfo();
        Console.WriteLine();


    }


}