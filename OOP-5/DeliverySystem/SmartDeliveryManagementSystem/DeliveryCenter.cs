namespace DeliverySystem.SmartDeliveryManagementSystem;

public class DeliveryCenter
{

    #region Fields

    private string driverName;
    private Shipment[] shipments;

    #endregion

    #region properties
    public string DriverName
    {
        get
        {
            return driverName;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                driverName = value;
            }
        }
    }
    #endregion

    #region ctor
    public DeliveryCenter(string driverName)
    {
        shipments = new Shipment[20];
        DriverName = driverName;
    }
    #endregion

    #region indexers
    public Shipment this[int position]
    {
        get
        {
            if (position >= 0 && position < 10)
            {
                return shipments[position];
            }
            return default!;
        }
        set
        {
            if (position >= 0 && position < 10)
            {
                shipments[position] = value;
            }
        }
    }

    public Shipment this[string trackingCode]
    {
        get
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (trackingCode == shipments[i].TrackingCode)
                {

                    return shipments[i];

                }
            }
            return default!;
        }
    }
    #endregion

    #region Methods
    public bool AddShipment(Shipment newShipment)
    {
        for (int i = 0; i < shipments.Length; i++)
        {
            if (shipments[i] == null)
            {
                shipments[i] = newShipment;
                return true;
            }
        }

        return false;
    }

    public bool RemoveShipment(string searchCode)
    {
        bool isFound = false;
        int index = -1;
        for (int i = 0; i < shipments.Length; i++)
        {
            if (shipments[i] == null)
            {
                break;
            }
            if (shipments[i].TrackingCode == searchCode)
            {
                index = i;
                isFound = true;
                break;
            }
        }
        if (index == -1)
        {
            return isFound;
        }

        Shipment[] newShipments = new Shipment[shipments.Length - 1];
        for (int i = 0, j = 0; i < shipments.Length; i++)
        {
            if (i == index)
                continue;

            newShipments[j] = shipments[i];
            j++;
        }
        shipments = newShipments;
        return isFound;
    }

    public void printAll()
    {
        foreach (Shipment shipment in shipments)
        {
            if (shipment != null)
            {
                shipment.PrintShipment();
                Console.WriteLine("----------------------");
            }
        }
    }

    public void PrintItrackable(ITrackable shipment)
    {
        shipment.GetTrackingStatus();
    }

    public void PrintInsurance(IInsurable shipment)
    {
        shipment.CalculateInsurance();
    }

    public void PrintTrackingStatuses()
    {
        foreach (Shipment shipment in shipments)
        {
            if (shipment != null)
            {
                Console.WriteLine(shipment.GetTrackingStatus());
            }
        }
    }

    public void PrintInsurance()
    {
        foreach (Shipment shipment in shipments)
        {
            if (shipment != null)
            {
                Console.WriteLine(shipment.CalculateInsurance());
            }
        }
    }

    #endregion
}
