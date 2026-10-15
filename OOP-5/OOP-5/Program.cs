namespace OOP_5;

using DeliverySystem.SmartDeliveryManagementSystem;

internal class Program
{
    static void Main(string[] args)
    {
        #region Theoretical Questions

        #region Q1  Object Copying
        // a) What happens when you assign one object variable to another object variable?
        // When assign one object variable to another, both variables refer to the same object in memory. Changes made through one variable will affect the other since they point to the same instance

        // b) Does assigning one object to another create a new object? Explain.
        // No, assigning one object to another does not create a new object. It simply copies the reference to the existing object, so both variables point to the same instance in memory

        // c) What is the difference between copying an object and copying its reference?
        // Copying an object creates a new instance with the same values, while copying its reference means both variables point to the same object in memory. Changes to one will affect the other
        #endregion

        #region Q2  Shallow Copy vs Deep Copy
        //a) What is a Shallow Copy?
        // A shallow copy creates a new object but does not create copies of the objects that the original object references. Instead, it copies the references to those objects, so both the original and the shallow copy share the same referenced objects

        // b) What is a Deep Copy?
        // A deep copy creates a new object and also recursively copies all objects that the original object references. This means that the new object and the original object are completely independent, with no shared references

        //c) What happens to reference-type members when a Shallow Copy is created?
        // When a shallow copy is created, reference-type members are not duplicated; instead, the references to those members are copied. As a result, both the original and the shallow copy will point to the same instances of the reference-type members. Changes made to these shared instances through one object will be reflected in the other object

        // d) What happens to reference-type members when a Deep Copy is created?
        // When a deep copy is created, new instances of the reference-type members are created, and the values of the original object's members are copied into these new instances. This means that the original object and the deep copy have completely independent copies of all reference-type members. Changes made to the reference-type members in one object will not affect the other object

        //e) Give one situation where Deep Copy would be safer than Shallow Copy.
        // Deep copy would be safer than shallow copy in situations where you want to ensure that modifications to the copied object do not affect the original object, especially when dealing with mutable reference-type members


        #endregion

        #region Q3  Static Members
        //a) What is a static field, and how is it different from an instance field?
        // A static field belongs to the class itself rather than any specific instance of the class. It is shared among all instances of the class, meaning that there is only one copy of the static field regardless of how many objects are created. In contrast, an instance field is unique to each object, and each instance has its own copy of the field

        //b) What is a static method? Can a static method directly access instance members?
        // A static method is a method that belongs to the class itself rather than any specific instance of the class. It can be called without creating an instance of the class. A static method cannot directly access instance members (fields or methods) because it does not have a reference to any particular object. To access instance members, a static method would need to create an instance of the class or receive an instance as a parameter

        //c) What is a static constructor, and when is it executed?
        // A static constructor is a special constructor that is used to initialize static members of a class. It is executed automatically by the runtime before any static members are accessed or any instances of the class are created

        //d) What is a static class? Can you create an object from a static class?
        // A static class is a class that cannot be instantiated and can only contain static members (fields, methods, properties, etc.). You cannot create an object from a static class

        #endregion

        #region Q4  Extension Methods
        //a) What is an Extension Method?
        // An extension method is a static method that allows you to add new functionality to existing types (classes, structs, interfaces) without modifying their source code or creating a new derived type

        //b) What keyword must be used in the first parameter of an extension method?
        // The "this"

        //c) Where must an extension method be declared?
        // An extension method must be declared in a static class

        //d) Can an extension method access private members of the class it extends?
        // No, an extension method cannot access private members of the class it extends. It can only access public and protected members

        #endregion

        #region Q5  Partial Classes and Partial Methods
        //a) What is a Partial Class?
        // A partial class is a class whose definition can be split across multiple files

        //b) Why would a developer split one class into multiple files?
        // to improve code organization, maintainability, and collaboration among team members

        //c) What is a Partial Method?
        // A partial method is a method that is declared in one part of a partial class and can be optionally implemented in another part of the same partial class

        //d) What happens if a declared partial method has no implementation?
        // If a declared partial method has no implementation, the compiler removes the method declaration and any calls to it from the compiled code. This means that there will be no runtime overhead for the unimplemented partial method

        #endregion

        #endregion


        #region Main() Checklist

        DeliveryUtilities.PrintSeparator();
        DeliveryUtilities.PrintSystemTitle();
        DeliveryUtilities.PrintSeparator();
        Console.WriteLine();

        


        #region creat DeliveryCenter
        Console.WriteLine();
        // Create a DeliveryCenter object with a driver name.
        Console.WriteLine("Enter Driver Name: ");
        string driverName = Console.ReadLine()!;

        // Create a DeliveryCenter object with the driver name.
        DeliveryCenter deliveryCenter = new DeliveryCenter(driverName);
        #endregion

        #region Creat StanderdShipment
        bool flag = false;

        //Read the tracking code from the user.
        Console.Write("Tracking Code: ");
        string trackingCode = Console.ReadLine();

        //Read the description from the user.
        Console.Write("Description: ");
        string description = Console.ReadLine();

        // Get weight from user
        decimal weight;
        do
        {
            Console.Write("Enter Valid Weight: ");
            flag = decimal.TryParse(Console.ReadLine(), out weight);
        }
        while (!flag || weight <= 0);

        // Get DeliveryFee from user
        decimal deliveryFee;
        do
        {
            Console.Write("Enter Valid Delivery Fee: ");
            flag = decimal.TryParse(Console.ReadLine(), out deliveryFee);
        }
        while (!flag || deliveryFee <= 0);

        //Create one StandardShipment.
        StandardShipment standardShipment = new StandardShipment(
            trackingCode,
            description,
            weight,
            deliveryFee
            );

        Console.WriteLine();

        // Add StandardShipment
        if (deliveryCenter.AddShipment(standardShipment))
        {
            Console.WriteLine("Shipment Add Successfully ");

        }
        Console.WriteLine("--------------------------");
        Console.WriteLine();
        
        #endregion

        #region Creat ExpressShipment

        //Read the tracking code from the user.
        Console.Write("Tracking Code: ");
        string ExpressTrackingCode = Console.ReadLine();

        //Read the description from the user.
        Console.Write("Description: ");
        string ExpressDescription = Console.ReadLine();

        // Get weight from user
        decimal ExpressWeight;
        do
        {
            Console.Write("Enter Valid Weight: ");
            flag = decimal.TryParse(Console.ReadLine(), out ExpressWeight);
        }
        while (!flag || ExpressWeight <= 0);

        // Get DeliveryFee from user
        decimal ExpressDeliveryFee;
        do
        {
            Console.Write("Enter Valid Delivery Fee: ");
            flag = decimal.TryParse(Console.ReadLine(), out ExpressDeliveryFee);
        }
        while (!flag || ExpressDeliveryFee <= 0);

        // Get extraFee from user
        decimal ExpressExtraFee;
        do
        {
            Console.Write("Enter Valid Extra Fee: ");
            flag = decimal.TryParse(Console.ReadLine(), out ExpressExtraFee);
        }
        while (!flag || ExpressExtraFee < 0);


        //Create one ExpressShipment.
        ExpressShipment expressShipment = new ExpressShipment(
            ExpressTrackingCode,
            ExpressDescription,
            ExpressWeight,
            ExpressDeliveryFee,
            ExpressExtraFee
            );

        Console.WriteLine();

        // Add ExpressShipment
        if (deliveryCenter.AddShipment(expressShipment))
        {
            Console.WriteLine("Shipment Add Successfully ");

        }
        Console.WriteLine("--------------------------");
        Console.WriteLine();
        #endregion

        #region Creat InternationlShipment

        //Read the tracking code from the user.
        Console.Write("Tracking Code: ");
        string InternationlTrackingCode = Console.ReadLine();

        //Read the description from the user.
        Console.Write("Description: ");
        string InternationlDescription = Console.ReadLine();

        // Get weight from user
        decimal InternationlWeight;
        do
        {
            Console.Write("Enter Valid Weight: ");
            flag = decimal.TryParse(Console.ReadLine(), out InternationlWeight);
        }
        while (!flag || InternationlWeight <= 0);

        // Get DeliveryFee from user
        decimal InternationlDeliveryFee;
        do
        {
            Console.Write("Enter Valid Delivery Fee: ");
            flag = decimal.TryParse(Console.ReadLine(), out InternationlDeliveryFee);
        }
        while (!flag || InternationlDeliveryFee <= 0);

        // Get customsFee from user
        decimal customsFee;
        do
        {
            Console.Write("Enter Valid customs Fee: ");
            flag = decimal.TryParse(Console.ReadLine(), out customsFee);
        }
        while (!flag || customsFee < 0);

        //Read destinationCountry from user
        Console.Write("Destination Country: ");
        string destinationCountry = Console.ReadLine();

        //Create one ExpressShipment.
        InternationalShipment internationlShipment = new InternationalShipment(
            InternationlTrackingCode,
            InternationlDescription,
            InternationlWeight,
            InternationlDeliveryFee,
            destinationCountry,
            customsFee
            );

        Console.WriteLine();

        // Add ExpressShipment
        if (deliveryCenter.AddShipment(internationlShipment))
        {
            Console.WriteLine("Shipment Add Successfully ");

        }
        Console.WriteLine("--------------------------");
        Console.WriteLine();
        #endregion

        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Creating Shipments...");
        DeliveryUtilities.PrintSeparator();

        Console.WriteLine();
        Console.WriteLine($"Total Shipments: {Shipment.GetTotalShipmentsCreated()}");
        Console.WriteLine();

        #region object coping
        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Object Copying");
        DeliveryUtilities.PrintSeparator();
        Console.WriteLine();

        Shipment shipment1 = new Shipment("sh101", "iphone", 10, 520);
        Shipment shipment2 = shipment1; // Copying reference
        shipment2.Weight = 15;

        Console.WriteLine($"Original Shipment  : {shipment1.Weight}"); // Output: 15
        Console.WriteLine($"Assigned  Shipment  : {shipment2.Weight}"); // Output: 15
        Console.WriteLine();

        Console.WriteLine($"Same Object : {ReferenceEquals(shipment1, shipment2)}"); // Output: True
        Console.WriteLine();
        #endregion

        #region Schallow copy
        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Schallow Copy");
        DeliveryUtilities.PrintSeparator();
        Console.WriteLine();

        DeliveryAdress deliveryAdress = new DeliveryAdress
        (
            "Alex",
            "45 St",
            12
        );
        Shipment shipment3 = new Shipment(deliveryAdress, "sh102", "Samsung", 12, 600);
        Shipment shipment4 = shipment3.SchallowCopy();

        Console.WriteLine($"Original Shipment  : {shipment3.Destination.City}"); // Output: Alex
        Console.WriteLine($"Copied Shipment  : {shipment4.Destination.City}"); // Output: Alex
        Console.WriteLine();

        shipment4.Destination.City = "Cairo";
        Console.WriteLine("Changing copied shipment address...");
        Console.WriteLine();

        Console.WriteLine($"Original Shipment  : {shipment3.Destination.City}"); // Output: Cairo
        Console.WriteLine($"Copied Shipment  : {shipment4.Destination.City}"); // Output: Cairo
        Console.WriteLine();

        Console.WriteLine($"Same DeliveryAddress Object : {ReferenceEquals(shipment3.Destination, shipment4.Destination)}"); // Output: True
        Console.WriteLine();
        #endregion

        #region Deep copy
        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Deep Copy");
        DeliveryUtilities.PrintSeparator();
        Console.WriteLine();

        Shipment shipment5 = new Shipment(deliveryAdress, "sh102", "Samsung", 12, 600);
        Shipment shipment6 = shipment5.DeepCopy();

        Console.WriteLine($"Original Shipment  : {shipment5.Destination.City}"); // Output: Cairo
        Console.WriteLine($"Copied Shipment  : {shipment6.Destination.City}"); // Output: cairo
        Console.WriteLine();

        shipment6.Destination.City = "alex";
        Console.WriteLine("Changing copied shipment address...");
        Console.WriteLine();

        Console.WriteLine($"Original Shipment  : {shipment5.Destination.City}"); // Output: cairo
        Console.WriteLine($"Copied Shipment  : {shipment6.Destination.City}"); // Output: alex
        Console.WriteLine();

        Console.WriteLine($"Same DeliveryAddress Object : {ReferenceEquals(shipment5.Destination, shipment6.Destination)}"); // Output: false
        Console.WriteLine();

        #endregion

        #region Extension Methods
        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Extension Methods");
        DeliveryUtilities.PrintSeparator();
        Console.WriteLine();

        Console.WriteLine(ShipmentExtensions.GetSummary(standardShipment));
        Console.WriteLine(ShipmentExtensions.GetSummary(expressShipment));
        Console.WriteLine(ShipmentExtensions.GetSummary(internationlShipment));
        Console.WriteLine();

        Console.WriteLine(ShipmentExtensions.IsDelivered(standardShipment));
        Console.WriteLine(ShipmentExtensions.IsDelivered(expressShipment));
        Console.WriteLine(ShipmentExtensions.IsDelivered(internationlShipment));
        Console.WriteLine();


        #endregion

        #region Tracking Status
        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Tracking Status");
        DeliveryUtilities.PrintSeparator();
        Console.WriteLine();

        standardShipment.UpdateTrackingStatus("Out For Delivery ");
        Console.WriteLine($"Tracking status changed to: {standardShipment.TrackingStatus}");
        Console.WriteLine();

        #endregion

        #region Static Utilities
        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Static Utilities");
        DeliveryUtilities.PrintSeparator();
        Console.WriteLine();

        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Delivery Center");
        DeliveryUtilities.PrintSeparator();
        Console.WriteLine();

        Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");
        Console.WriteLine();
        #endregion

        #region Partial Method
        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Partial Method");
        DeliveryUtilities.PrintSeparator();
        Console.WriteLine();

        standardShipment.UpdateTrackingStatus("Delivered");
        Console.WriteLine($"Tracking status changed to: {standardShipment.TrackingStatus}");
        Console.WriteLine();
        #endregion

        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Assignment Completed");
        DeliveryUtilities.PrintSeparator();
        Console.WriteLine();

        #endregion
    }
}
