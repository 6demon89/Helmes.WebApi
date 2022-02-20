namespace Helmes.Shared.Model
{
    public class Sectors
    {
        public Sectors(){}

        public Sectors(int sectorID, string name, int? parentSectorID)
        {
            SectorID = sectorID;
            Name = name;
            ParentSectorID = parentSectorID;
        }

        public int SectorID { get; set; }
        public string Name { get; set; }
        public int? ParentSectorID { get; set; }
        

        [System.Text.Json.Serialization.JsonIgnore]
        public Sectors ParentSector { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public List<Sectors> SubSectors { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public List<User> Users { get; set; } = new List<User>();
    }
}
