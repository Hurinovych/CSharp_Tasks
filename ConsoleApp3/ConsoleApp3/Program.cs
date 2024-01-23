using Microsoft.VisualBasic.FileIO;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("Lambo", 2022, "gas", 120);
            ElectricCar car2 = new ElectricCar("Ferrari", 2023, "electric", 500);
            car1.CalculateFuelConsumption(car1.FuelEfficiency);
            car2.CalculateFuelConsumption(car2.BatteryCapacity);
            Console.ReadKey();
        }
    }
    class Vehicle
    {
        String brand;
        int year;
        String fuelType;
        double distance;
        double fuel;
        public Vehicle(String brand, int year, String fuelType)
        {
            this.brand = brand;
            this.year = year;
            this.fuelType = fuelType;
        }
        public virtual void CalculateFuelConsumption(double fuel)
        {
            double distance;
            Console.Write($"Enter distance for {fuelType} {brand} {year} calculation consumption: ");
            distance = Convert.ToDouble(Console.ReadLine());
            double fuelConsumption = fuel / distance * 100;
            Console.WriteLine($"Fuel consumption of this {fuelType} {brand} {year} is {fuelConsumption} units for 100 kilometers!");
        }
    }
    class Car : Vehicle
    {
        public double FuelEfficiency; 
        public Car(string brand, int year, String fuelType, double FuelEfficiency):base(brand, year, fuelType)
        {
            this.FuelEfficiency = FuelEfficiency;
        }
        public override void CalculateFuelConsumption(double fuel)
        {
            base.CalculateFuelConsumption(FuelEfficiency);
        }
    }
    class ElectricCar : Vehicle
    {
        public double BatteryCapacity;
        public ElectricCar(string brand, int year, String fuelType, double BatteryCapacity):base(brand, year, fuelType)
        {
            this.BatteryCapacity = BatteryCapacity;
        }
        public override void CalculateFuelConsumption(double fuel)
        {
            base.CalculateFuelConsumption(BatteryCapacity);
        }
    }
}

