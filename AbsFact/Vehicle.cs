using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Windows;
using System.Xml.Schema;

namespace Vehicle;


public static class Program
{

    static void Main(string[] args)
    {


    }
}


abstract class Vehicle
{
    public string reg { get; set; }

    public string Model { get; set; }
    public string Brand { get; set; }

    public override string ToString()
    {
        return $"Brand: {this.Brand}, Model: {this.Model}, Registration: {this.reg}";
    }

    public Vehicle(string reg, string model, string brand)
    {
        this.reg = reg;
        Model = model;
        Brand = brand;
    }
}

class DieselVehicle : Vehicle
{
    public readonly FuelType Fuel = FuelType.Diesel;

    public override string ToString()
    {
        return base.ToString() + $"FuelType: {this.Fuel}";
    }

    public DieselVehicle(string reg, string model, string brand) : base(reg, model, brand) { }

}

class GasolineVehicle : Vehicle
{
    public readonly FuelType Fuel = FuelType.Gasoline;
    public GasolineVehicle(string reg, string model, string brand) : base(reg, model, brand)
    { 
        
    }
}

class Plane : Vehicle
{
    public readonly FuelType Fuel = FuelType.JetFuel;
    public virtual int Passengers { get; set; } 
    public override string ToString()
    {
        return base.ToString() + $"FluelType: {this.Fuel}, I Can Fly!";
    }
    public Plane(string reg, string model, string brand, int Passenger, string brands = "Airbus") : base(reg, model, brand) {

        this.Passengers = Passenger;
        if (brands is not null) this.Brand = brands;
    
    }

}

class DAPlane : Plane
{
    public override int Passengers { get; set; } = 5;
    public override string ToString()
    {
        return base.ToString() + $" But only with {Passengers} passengers";
    }

    public DAPlane(string reg, string model, string brand, int Passenger, string brands = "DA") : base(reg, model, brand, Passenger, brands)
    {

    }
}

class DA40Plane : DAPlane
{
    public new readonly FuelType Fuel = FuelType.Diesel;
    public override int Passengers { get; set; } = 2;
    public override string ToString()
    {
        return base.ToString();
    }
    public DA40Plane(string reg, string model, string brand, int passengers, string brands = "DA", string models = "40") : base(reg, model, brand,  passengers, brands)
    {
        if (models is not null) this.Model = $"{this.Brand}40";

    }
}
abstract class VehiclesFactory
{
    public abstract Vehicle VehicleFactory(params string[] a);
}

class DieselVehicleFactory : VehiclesFactory
{
    public override Vehicle VehicleFactory(params string[] a)
    {
        return new DieselVehicle();
    }
}

class GasolineVehicleFactory : VehiclesFactory
{
    public override Vehicle VehicleFactory(params string[] a)
    {
        return new GasolineVehicle();
    }
}

class PlaneFactory : VehiclesFactory
{
    public override Vehicle VehicleFactory(params string[] a)
    {
        return new Plane();
    }
}

class DaPlaneFactory : VehiclesFactory
{
    public override Vehicle VehicleFactory(params string[] a)
    {
        return new DAPlane();
    }
}

class VehiclesConstructor : VehiclesFactory
{
    public override Vehicle VehicleFactory(params string[] a)
    {
        if (a.Length > 7) throw new Exception("TooMany Arguments");
        int[] IntegerParams = new int[a.Length];
        int Iterator = 0;
        bool diesel = false;
        foreach(var i in a)
        {
           if(int.TryParse(i,out IntegerParams[Iterator]))
           {
                Iterator++;
           }
           if(i.Contains("diesel"))
           {
                diesel = true;
           }
           if()
        }
    }
}

enum FuelType { Diesel, Gasoline, JetFuel, RocketFuel}
