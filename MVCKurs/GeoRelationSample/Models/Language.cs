namespace GeoRelationSample.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        #region Nav
        public virtual ICollection<LanguageInCountry> LanguageInCountryRef { get; set; }
        #endregion
    }
}
