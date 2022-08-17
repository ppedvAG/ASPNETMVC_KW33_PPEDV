namespace GeoRelationSample.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public string Capital { get; set; }

        public int ContinentId { get; set; }

        #region Nav
        public virtual Continent ContinentRef { get; set; }

        public virtual ICollection<LanguageInCountry> LanguagesInCountryRef { get; set; }
        #endregion
    }
}