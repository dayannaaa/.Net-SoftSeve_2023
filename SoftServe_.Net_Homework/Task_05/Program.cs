namespace _Task_05
{
    class Weapon
    {
        private int shot_range;
        float caliber;
        int count_of_bullets;
        int max_count_of_bullets;

        public Weapon()
        {
            shot_range = 0;
            caliber = 0;
            count_of_bullets = 0;
            max_count_of_bullets = 25;
        }
        public void Initialize(int range, float caliber, int maxSize)
        {
            if (range < 0) shot_range = 0;
            shot_range = range;
            if (caliber < 0) this.caliber = 0;
            this.caliber = caliber;
            if (maxSize > 25) count_of_bullets = max_count_of_bullets;
            if (maxSize < 0) count_of_bullets = 0;
            else count_of_bullets = maxSize;
        }
        public bool Shot()
        {
            --count_of_bullets;
            if (count_of_bullets > 0)
                return true;
            else
            {
                count_of_bullets = 0;
                return false;
            }
        }
        public void Recharge()
        {
            count_of_bullets = max_count_of_bullets;
        }
        public void Print()
        {
            
            Console.WriteLine($"The number of cartridges in the weapon = {count_of_bullets} ");
        }

    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Weapon weapon = new Weapon();
            weapon.Print();
            weapon.Initialize(120, .5f, 3);
            weapon.Shot();
            weapon.Shot();
            weapon.Shot();
            weapon.Shot();
            weapon.Shot();
            weapon.Print();

            weapon.Recharge();
            weapon.Print();


        }
    }
}