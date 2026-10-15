namespace DeliverySystem.SmartDeliveryManagementSystem;

public class InternationalShipment : Shipment
{

    #region Fields
    private string destinationCountry;
    private decimal customsFee;

    #endregion

    #region Properties
    public string DestinationCountry
    {
        get
        {
            return destinationCountry;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                destinationCountry = value;
            }
        }
    }

    public decimal CustomsFee
    {
        get
        {
            return customsFee;
        }
        set
        {
            if (value >= 0)
            {
                customsFee = value;
            }
        }
    }

    public override decimal EstimatedCost
    {
        get
        {
            return DeliveryFee + (Weight * 5) + CustomsFee;
        }
    }
    #endregion

    #region Constructors
    public InternationalShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, string destinationCountry, decimal customsFee) : base(trackingCode, description, weight, deliveryFee)
    {
        DestinationCountry = destinationCountry;
        CustomsFee = customsFee;
    }
    #endregion

    #region Methods
    public override void PrintShipment()
    {
        Console.WriteLine($"Tracking code: {TrackingCode}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Weight: {Weight} KG");
        Console.WriteLine($"Delivery Fee: {DeliveryFee} EGP");
        Console.WriteLine($"Estimated cost: {EstimatedCost} EGP");
        Console.WriteLine($"Customs Fee: {CustomsFee} EGP");
        Console.WriteLine($"Destination Country: {DestinationCountry}");
    }

    public override string GetShipmentType()
    {
        return "International";
    }

    override public string GetTrackingStatus()
    {
        return "Delivered";
    }

    override public decimal CalculateInsurance()
    {
        return EstimatedCost * 0.12m; // 12% of the estimated cost
    }

    #endregion
}
