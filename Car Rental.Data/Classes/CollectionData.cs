﻿using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Classes;
using Car_Rental.Data.Interfaces;
using System;
using System.Linq.Expressions;
using System.ComponentModel;
using System.Reflection;

namespace Car_Rental.Data.Classes;

public class CollectionData : IData
{
    readonly List<IPerson> _persons = new List<IPerson>();
    readonly List<IVehicle> _vehicles = new List<IVehicle>();
    readonly List<IBooking> _bookings = new List<IBooking>();

    public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(b => b.Id) + 1;
    public int NextPersonId => _persons.Count.Equals(0) ? 1 : _persons.Max(b => b.Id) + 1;
    public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(b => b.Id) + 1;

    public string[] VehicleStatusNames => Enum.GetNames(typeof(VehicleStatuses)); //Retunera enum konstanterna
    public string[] VehicleTypeNames => Enum.GetNames(typeof(VehicleTypes)); //Retunera enum konstanterna
    public VehicleTypes GetVehicleType(string name) =>
        (VehicleTypes)Enum.Parse(typeof(VehicleTypes), name, true); /*Retunera en enum konstants värde med hjälp av konstantens namn*/

    public CollectionData() => SeedData();

    void SeedData()
    {
        //Vehicles

        _vehicles.Add(new Car(1, "ABC123", "Volvo", 10000, 1, VehicleTypes.Combi, VehicleStatuses.Available));
        _vehicles.Add(new Car(2,"DEF456", "Saab", 20000, 1, VehicleTypes.Sedan, VehicleStatuses.Available));
        _vehicles.Add(new Car(3,"GHI789", "Tesla", 1000, 3, VehicleTypes.Sedan, VehicleStatuses.Available));
        _vehicles.Add(new Car(4, "JKL012", "Jeep", 5000, 1.5, VehicleTypes.Van,  VehicleStatuses.Available));
        _vehicles.Add(new Motorcycle(5, "MNO234", "Yamaha", 30000, 0.5, VehicleTypes.Motorcycle, VehicleStatuses.Available));
            
        //Customers
        
        _persons.Add(new Customer(1, "John", "Doe", 12345));
        _persons.Add(new Customer(2, "Jane", "Doe", 98765));
        _persons.Add(new Customer(3, "John", "Cena", 80808));
    }
    public List<T> Get<T>(Expression<Func<T, bool>>? expression)
    {
       FieldInfo? info = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.FieldType == typeof(List<T>));
        if (info is not null)
        {
            var list = (List<T>)info.GetValue(this);
            if (expression is not null)
            {
                list = list.Where(expression.Compile()).ToList();
            }
            return list;
        }
        else
        {
            throw new InvalidOperationException("Could not find list");
        }
    }
    public T? Single<T>(Expression<Func<T, bool>>? expression)
    {
        FieldInfo? info = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.FieldType == typeof(List<T>));
        if (info is not null)
        {
            var list = (List<T>)info.GetValue(this);
            var item = list.SingleOrDefault(expression.Compile());
            return item;
        }
        else
        {
            throw new InvalidOperationException("Could not find type");
        }
    }
    public IBooking RentVehicle(int vehicleId, int customerId)
    {
        var vehicle = _vehicles.SingleOrDefault(v => v.Id == vehicleId);
        var customer = _persons.SingleOrDefault(c => c.Id == customerId);
        Booking newB = new Booking(NextBookingId, vehicle, customer);

        if (vehicle is not null && customer is not null)
        {
            foreach (var booking in _bookings)
            {
                if (booking.Vehicle.regNum == newB.RegNum && booking.Vehicle.status == VehicleStatuses.Available)
                {
                    newB.Vehicle.status = VehicleStatuses.Booked;
                }
                else
                {
                    continue;
                }
            }
            return newB; 
        }
        else
        {
            throw new Exception("Vehicle is shit");
        }
    }
    public async Task Add<T>(T item)
    {
        await Task.Delay(2000);
        try
        {
            FieldInfo? info = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.FieldType == typeof(List<T>));
            if (info is not null && item is not null) 
            {
                var list = (List<T>)info.GetValue(this);
                list.Add(item);
            }
            else
            {
                throw new ArgumentNullException("Could not add item");
            }
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
    public IBooking ReturnVehicle(int vehicleId)
    {
        try
        {
            var newB = Single<IBooking>(b => b.Vehicle.Id == vehicleId && b.isOpen == true);
            if (newB is not null)
            {
                return newB;
            }
            else
            {
                throw new ArgumentNullException("Booking could not be found");
            }
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
    public IEnumerable<IPerson> GetPersons() => _persons;
    public IEnumerable<IBooking> GetBookings() => _bookings;
    public IEnumerable<IVehicle> GetVehicles(/*VehicleStatuses status = default*/) => _vehicles;
}