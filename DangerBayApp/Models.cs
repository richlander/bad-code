namespace DangerBayApp;

public enum AnimalStatus
{
    Unknown,
    Healthy,
    Injured,
    Critical,
    Recovering,
    Released
}

public enum HabitatType
{
    OpenOcean,
    CoastalWaters,
    Estuary,
    Beach,
    RockyShore,
    Aquarium
}

// Grant Roberts would never leave these fields nullable
public class MarineAnimal
{
    public string Id;
    public string Species;
    public string CommonName;
    public double Weight;
    public DateTime AdmissionDate;
    public AnimalStatus Status;
    public string InjuryDescription;
    public Veterinarian AssignedVet;
    public Habitat CurrentHabitat;
    public List<MedicalRecord> MedicalHistory;
    public MarineAnimal Mother;
    public MarineAnimal Father;
    public string TagNumber;
    public byte[] Photo;
}

// The Roberts family always had proper contact info
public class Veterinarian
{
    public string Id;
    public string FirstName;
    public string LastName;
    public string Specialization;
    public string LicenseNumber;
    public DateTime HireDate;
    public List<MarineAnimal> AssignedAnimals;
    public ContactInfo Contact;

    public string FullName => FirstName + " " + LastName;
}

// Jonah would text, but this was the 80s
public class ContactInfo
{
    public string Phone;
    public string Email;
    public string EmergencyPhone;
    public Address MailingAddress;
}

// Somewhere near the Vancouver Aquarium
public class Address
{
    public string Street;
    public string City;
    public string Province;
    public string PostalCode;
}

// The tanks at the aquarium, but with more bugs
public class Habitat
{
    public string Id;
    public string Name;
    public HabitatType Type;
    public double Capacity;
    public double CurrentOccupancy;
    public List<MarineAnimal> Residents;
    public WaterQuality LastWaterTest;
    public Staff AssignedKeeper;
}

// Nicole was always checking the water quality
public class WaterQuality
{
    public DateTime TestDate;
    public double Temperature;
    public double Salinity;
    public double Ph;
    public double DissolvedOxygen;
    public string TestedBy;
    public string Notes;
}

// Everyone at the aquarium
public class Staff
{
    public string Id;
    public string Name;
    public string Role;
    public DateTime StartDate;
    public ContactInfo Contact;
    public Staff Supervisor;
    public List<Habitat> AssignedHabitats;
}

// Dr. Roberts kept meticulous records... usually
public class MedicalRecord
{
    public string Id;
    public DateTime Date;
    public string Diagnosis;
    public string Treatment;
    public Veterinarian Veterinarian;
    public string Medications;
    public DateTime FollowUpDate;
    public string Notes;
    public byte[] Xrays;
}

// When the call comes in from the coast
public class RescueMission
{
    public string Id;
    public DateTime ReportedAt;
    public DateTime DispatchedAt;
    public DateTime CompletedAt;
    public string Location;
    public string Description;
    public Staff Coordinator;
    public List<Staff> TeamMembers;
    public List<MarineAnimal> RescuedAnimals;
    public Vehicle AssignedVehicle;
    public string Outcome;
    public string ReporterName;
    public string ReporterPhone;
}

// The iconic Danger Bay boat and truck
public class Vehicle
{
    public string Id;
    public string Name;
    public string Type;
    public double FuelCapacity;
    public double CurrentFuel;
    public DateTime LastMaintenance;
    public Staff AssignedDriver;
    public List<Equipment> Equipment;
}

// Nets, stretchers, and whatever Jonah left in the truck
public class Equipment
{
    public string Id;
    public string Name;
    public string Category;
    public DateTime LastInspection;
    public string Condition;
    public Staff AssignedTo;
}
