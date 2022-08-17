namespace GeoRelationSample.Models
{
    public class LanguageInCountry
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int LanguageId { get; set; }

        public int Percent { get; set; }

        #region Nav
        public virtual Country CountryRef { get; set; } 
        public virtual Language LanguageRef { get; set; }
        #endregion
    }
}