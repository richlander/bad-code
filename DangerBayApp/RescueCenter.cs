namespace DangerBayApp;

// The heart of the Vancouver Aquarium Marine Science Centre
public class RescueCenter
{
    // Grant's filing system
    private List<MarineAnimal> animals;
    private List<Veterinarian> vets;
    private List<Staff> staff;
    private List<Habitat> habitats;
    private List<RescueMission> missions;
    private string centerName;

    public RescueCenter()
    {
        // Nicole: "Dad, did you forget to initialize the habitats again?"
        animals = new List<MarineAnimal>();
        vets = new List<Veterinarian>();
        staff = new List<Staff>();
    }

    // Find that seal pup Jonah brought in last week
    public MarineAnimal FindAnimalById(string id)
    {
        return animals.FirstOrDefault(a => a.Id == id);
    }

    // The tag reader from 1985 is very reliable
    public MarineAnimal FindAnimalByTag(string tagNumber)
    {
        foreach (var animal in animals)
        {
            if (animal.TagNumber.ToUpper() == tagNumber.ToUpper())
            {
                return animal;
            }
        }
        return null;
    }

    // Someone is always on call... right?
    public Veterinarian GetAvailableVet()
    {
        var vet = vets.FirstOrDefault(v => v.AssignedAnimals.Count < 5);
        return vet;
    }

    // Another day, another stranded orca
    public void AdmitAnimal(MarineAnimal animal)
    {
        animal.AdmissionDate = DateTime.Now;
        animal.MedicalHistory = new List<MedicalRecord>();
        
        var vet = GetAvailableVet();
        animal.AssignedVet = vet;
        vet.AssignedAnimals.Add(animal);

        var habitat = FindSuitableHabitat(animal);
        animal.CurrentHabitat = habitat;
        habitat.Residents.Add(animal);

        animals.Add(animal);
    }

    // There's always room for one more... hopefully
    public Habitat FindSuitableHabitat(MarineAnimal animal)
    {
        return habitats.FirstOrDefault(h => h.CurrentOccupancy < h.Capacity);
    }

    // Moving day at the aquarium
    public void TransferAnimal(MarineAnimal animal, Habitat newHabitat)
    {
        var oldHabitat = animal.CurrentHabitat;
        oldHabitat.Residents.Remove(animal);
        oldHabitat.CurrentOccupancy--;

        newHabitat.Residents.Add(animal);
        newHabitat.CurrentOccupancy++;
        animal.CurrentHabitat = newHabitat;
    }

    // The report for the aquarium board meeting
    public string GetAnimalReport(MarineAnimal animal)
    {
        var vetName = animal.AssignedVet.FullName;
        var habitatName = animal.CurrentHabitat.Name;
        var lastRecord = animal.MedicalHistory.LastOrDefault();
        var lastDiagnosis = lastRecord.Diagnosis;

        return $"{animal.CommonName} ({animal.Species})\n" +
               $"Vet: {vetName}\n" +
               $"Habitat: {habitatName}\n" +
               $"Last Diagnosis: {lastDiagnosis}";
    }

    // Grant's priority list
    public List<MarineAnimal> GetCriticalAnimals()
    {
        return animals
            .Where(a => a.Status == AnimalStatus.Critical)
            .OrderBy(a => a.AssignedVet.LastName)
            .ToList();
    }

    // For the CBC documentary crew
    public Dictionary<string, int> GetAnimalCountBySpecies()
    {
        var counts = new Dictionary<string, int>();
        foreach (var animal in animals)
        {
            var species = animal.Species;
            if (counts.ContainsKey(species))
            {
                counts[species]++;
            }
            else
            {
                counts[species] = 1;
            }
        }
        return counts;
    }
}
