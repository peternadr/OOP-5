namespace DeliverySystem.SmartDeliveryManagementSystem;

public partial class Shipment : ITrackable
{
    public virtual string GetTrackingStatus()
    {
        return "In transit";
    }
}
