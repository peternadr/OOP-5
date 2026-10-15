namespace DeliverySystem.SmartDeliveryManagementSystem;

public class StandardShipment : Shipment
{

    #region proprties
    public override decimal EstimatedCost => DeliveryFee + (Weight * 5);

    public override string TrackingStatus { get; set; } = " Under review ";
    #endregion

    #region constructor
    public StandardShipment(string trackingCode, string description, decimal weight, decimal deliveryFee) : base(trackingCode, description, weight, deliveryFee)
    {
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
    }

    public override string GetShipmentType()
    {
        return "Standard";
    }

    public override string GetTrackingStatus()
    {
        return TrackingStatus;
    }

    public override decimal CalculateInsurance()
    {
        return EstimatedCost * 0.05m; // 5% of the estimated cost
    }

    #endregion
}
