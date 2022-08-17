namespace GeoRelationSample.Models
{
    public class Continent
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        #region Navigation 1:n
        public virtual ICollection<Country> Countries { get; set; }
        #endregion
    }
}
