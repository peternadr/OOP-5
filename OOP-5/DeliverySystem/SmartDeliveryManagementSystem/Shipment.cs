namespace DeliverySystem.SmartDeliveryManagementSystem;

public abstract class Shipment : IInsurable , ITrackable
{

    #region Fields
    private string trackingCode;
    private string description;
    private decimal weight;
    private decimal deliveryFee;




    #endregion

    #region Properties

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

    public abstract decimal EstimatedCost { get; }
    #endregion

    #region Constructors

    public Shipment(string trackingCode)
    {
        TrackingCode = trackingCode;
        Description = "Unknown";
        Weight = 1;
        DeliveryFee = 50;
    }

    public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee)
    {
        TrackingCode = trackingCode;
        Description = description;
        Weight = weight;
        DeliveryFee = deliveryFee;
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




    public abstract void PrintShipment();

    public virtual string GetTrackingStatus()
    {
        return $"Shipment with tracking code {TrackingCode} is in transit.";
    }

    public virtual decimal CalculateInsurance()
    {
        return EstimatedCost;
    }

    #endregion
}
