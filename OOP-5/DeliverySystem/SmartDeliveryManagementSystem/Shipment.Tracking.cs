namespace DeliverySystem.SmartDeliveryManagementSystem;

public partial class Shipment : ITrackable
{
    public string TrackingStatus { get; private set; }
    public virtual string GetTrackingStatus()
    {
        return "In Transit";
    }
}
