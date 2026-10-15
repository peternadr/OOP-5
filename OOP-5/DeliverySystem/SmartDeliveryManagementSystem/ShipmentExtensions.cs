namespace DeliverySystem.SmartDeliveryManagementSystem;

public static class ShipmentExtensions
{
    public static string GetSummary(this Shipment shipment)
    {
        return $"{shipment.TrackingCode} | {shipment.GetShipmentType()} | {shipment.Weight} KG | {shipment.GetTrackingStatus()}";
    }


    public static bool IsDelivered(this Shipment shipment)
    {
        return shipment.GetTrackingStatus()
            .Contains("Delivered", StringComparison.OrdinalIgnoreCase);
    }
}
