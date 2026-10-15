namespace DeliverySystem.SmartDeliveryManagementSystem;

public class ExpressShipment : Shipment
{
    private decimal extraFee;

    #region Properties
    public decimal ExtraFee
    {
        get
        {
            return extraFee;
        }
        set
        {
            if (value >= 0)
            {
                extraFee = value;
            }
        }
    }

    public override decimal EstimatedCost
    {
        get
        {
            return DeliveryFee + (Weight * 5) + ExtraFee;
        }
    }
    #endregion

    #region Constructors
    public ExpressShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, decimal extraFee) : base(trackingCode, description, weight, deliveryFee)
    {
        ExtraFee = extraFee;
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
        Console.WriteLine($"Extra Fee: {ExtraFee} EGP");
    }

    public override string GetTrackingStatus()
    {
        return $"Shipment {TrackingCode} is in Out for Delivery.";
    }

    override public decimal CalculateInsurance()
    {
        return EstimatedCost * 0.08m; // 8% of the estimated cost
    }

    #endregion
}
