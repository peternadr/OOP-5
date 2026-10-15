namespace DeliverySystem.SmartDeliveryManagementSystem;

public partial class Shipment : IInsurable
{

    #region Fields
    private string trackingCode;
    private string description;
    private decimal weight;
    private decimal deliveryFee;
    private static int TotalShipmentsCreated;


    #endregion

    #region Properties
    public DeliveryAdress Destination { get; set; }
    public string TrackingCode
    {
        get
        {
            return trackingCode;
        }
        private set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                trackingCode = value;
            }
        }
    }
    public string Description
    {
        get
        {
            return description;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                description = value;
            }
        }
    }

    public decimal Weight
    {
        get
        {
            return weight;
        }
        set
        {
            if (value > 0)
            {
                weight = value;
            }
        }
    }

    public decimal DeliveryFee
    {
        get
        {
            return deliveryFee;
        }
        private set
        {
            if (value > 0)
            {
                deliveryFee = value;
            }
        }
    }

    public virtual decimal EstimatedCost { get; }
    #endregion

    #region Constructors

    public Shipment(string trackingCode)
    {
        TrackingCode = trackingCode;
        Description = "Unknown";
        Weight = 1;
        DeliveryFee = 50;
        TotalShipmentsCreated++;
    }

    public Shipment(string trackingCode,string description, decimal weight, decimal deliveryFee)
    {
        TrackingCode = trackingCode;
        Description = description;
        Weight = weight;
        DeliveryFee = deliveryFee;
        TotalShipmentsCreated++;
    }

    public Shipment(DeliveryAdress deliveryAdress ,string trackingCode,string description, decimal weight, decimal deliveryFee)
    {
        Destination = deliveryAdress;
        TrackingCode = trackingCode;
        Description = description;
        Weight = weight;
        DeliveryFee = deliveryFee;
        TotalShipmentsCreated++;
    }

    static Shipment()
    {
        Console.WriteLine("Shipment System Initialized");
    }

    #endregion

    #region Methods
    public void UpdateDeliveryFee(decimal newFee)
    {
        if (newFee > 0)
        {
            DeliveryFee = newFee;
        }
    }

    public void UpdateWeight(decimal newWeight)
    {
        if (newWeight > 0)
        {
            Weight = newWeight;
        }
    }

    public void UpdateWeight(decimal newWeight, decimal ExtraPacking)
    {
        if (newWeight > 0 && ExtraPacking > 0)
        {
            Weight = newWeight + ExtraPacking;
        }
    }




    public virtual void PrintShipment()
    {
        Console.WriteLine($"Tracking code: {TrackingCode}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Weight: {Weight} KG");
        Console.WriteLine($"Delivery Fee: {DeliveryFee} EGP");
        Console.WriteLine($"Estimated cost: {EstimatedCost} EGP");
    }


    public virtual string GetShipmentType()
    {
        return "Shipment";
    }

    public virtual decimal CalculateInsurance()
    {
        return EstimatedCost;
    }

    public Shipment CopyShipment()
    {
        return new Shipment
        (
            TrackingCode = this.TrackingCode,
            Description = this.Description,
            Weight = this.Weight,
            DeliveryFee = this.DeliveryFee
        );
    }

    public Shipment SchallowCopy()
    {
        return (Shipment)this.MemberwiseClone();
    }

    public Shipment DeepCopy()
    {
        Shipment copy = (Shipment)this.MemberwiseClone();
        copy.Destination = new DeliveryAdress(
            this.Destination.City,
            this.Destination.Street, 
            this.Destination.BuildingNumber
            );
        return copy;
    }

    public static int GetTotalShipmentsCreated()
    {
        return TotalShipmentsCreated;
    }

    #endregion
}
