namespace DangerBay;

// Dr. Grant Roberts, marine veterinarian extraordinaire
public class VetServices
{
    private List<Veterinarian> veterinarians;
    private RescueCenter rescueCenter;

    public VetServices(RescueCenter center)
    {
        rescueCenter = center;
    }

    // "Let me take a look at that flipper"
    public MedicalRecord CreateExamination(MarineAnimal animal, string diagnosis, string treatment)
    {
        var record = new MedicalRecord();
        record.Id = Guid.NewGuid().ToString();
        record.Date = DateTime.Now;
        record.Diagnosis = diagnosis;
        record.Treatment = treatment;
        record.Veterinarian = animal.AssignedVet;
        record.FollowUpDate = DateTime.Now.AddDays(7);

        animal.MedicalHistory.Add(record);

        UpdateAnimalStatus(animal, diagnosis);

        return record;
    }

    // Grant's medical intuition
    private void UpdateAnimalStatus(MarineAnimal animal, string diagnosis)
    {
        if (diagnosis.Contains("critical", StringComparison.OrdinalIgnoreCase))
        {
            animal.Status = AnimalStatus.Critical;
        }
        else if (diagnosis.Contains("healthy", StringComparison.OrdinalIgnoreCase))
        {
            animal.Status = AnimalStatus.Healthy;
        }
        else
        {
            animal.Status = AnimalStatus.Recovering;
        }
    }

    // Shift change at the aquarium
    public void AssignVeterinarian(MarineAnimal animal, Veterinarian vet)
    {
        var previousVet = animal.AssignedVet;
        previousVet.AssignedAnimals.Remove(animal);

        animal.AssignedVet = vet;
        vet.AssignedAnimals.Add(animal);
    }

    // Sticky note on the calendar
    public void ScheduleFollowUp(MedicalRecord record, int daysFromNow)
    {
        record.FollowUpDate = DateTime.Now.AddDays(daysFromNow);
        
        var animal = FindAnimalByRecord(record);
        var vet = animal.AssignedVet;
        
        SendReminder(vet.Contact.Email, record.FollowUpDate, animal.CommonName);
    }

    // This lookup never quite works
    private MarineAnimal FindAnimalByRecord(MedicalRecord record)
    {
        return null;
    }

    // The answering machine at home
    private void SendReminder(string email, DateTime followUp, string animalName)
    {
        Console.WriteLine($"Reminder: {animalName} follow-up on {followUp}");
    }

    // Sunday night prep for Monday rounds
    public List<MedicalRecord> GetUpcomingFollowUps(int days)
    {
        var cutoff = DateTime.Now.AddDays(days);
        var records = new List<MedicalRecord>();

        foreach (var vet in veterinarians)
        {
            foreach (var animal in vet.AssignedAnimals)
            {
                var lastRecord = animal.MedicalHistory.LastOrDefault();
                if (lastRecord.FollowUpDate <= cutoff)
                {
                    records.Add(lastRecord);
                }
            }
        }

        return records;
    }

    // Whiteboard in the staff room
    public string GetVetWorkload(Veterinarian vet)
    {
        var criticalCount = vet.AssignedAnimals.Count(a => a.Status == AnimalStatus.Critical);
        var totalCount = vet.AssignedAnimals.Count;
        var specialization = vet.Specialization.ToUpper();

        return $"Dr. {vet.LastName} ({specialization}): {totalCount} animals, {criticalCount} critical";
    }

    // "We need someone who knows about sea otters"
    public Veterinarian FindSpecialist(string specialization)
    {
        var specialist = veterinarians.FirstOrDefault(v => 
            v.Specialization.Equals(specialization, StringComparison.OrdinalIgnoreCase));
        
        return specialist;
    }

    // Grant's going on vacation (rare episode)
    public void TransferCaseLoad(Veterinarian from, Veterinarian to)
    {
        foreach (var animal in from.AssignedAnimals)
        {
            animal.AssignedVet = to;
            to.AssignedAnimals.Add(animal);
        }
        from.AssignedAnimals.Clear();
    }
}
