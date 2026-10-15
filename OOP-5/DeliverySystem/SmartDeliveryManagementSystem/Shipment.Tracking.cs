namespace DeliverySystem.SmartDeliveryManagementSystem;

public partial class Shipment : ITrackable
{
    public virtual string TrackingStatus { get; set; } = "In transit";
    public virtual string GetTrackingStatus()
    {
        return TrackingStatus;
    }
}
