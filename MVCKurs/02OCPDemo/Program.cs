namespace _02OCPDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
    }

    #region BadCode
    public class BadGenerateReport
    {
        public string ReportType { get; set; }  

        public void Generate()
        {
            if (ReportType == "CRS")
            {
                //Crystal Reports verwendet
            }
            else if (ReportType == "PDF")
            {
                //PDF wird verwendet
            }
            else
            {
                //Was anderes wird verwendet
            }
        }
    }



    #endregion

    #region BetterCode

    public abstract class ReportGeneratorBase
    {
        public abstract void GenerateReport(Employee employee);
    }


    public class PDFReporter : ReportGeneratorBase
    {
        public override void GenerateReport(Employee employee)
        {
            //GenerateReport Methode + eigene Klasse nur für PDFs und seinen ganzen Optionen 
        }
    }

    public class CrystalReporter : ReportGeneratorBase
    {
        public override void GenerateReport(Employee employee)
        {
            //GenerateReport Methode + eigene Klasse nur für Crystal Reports und seinen ganzen Optionen 
        }
    }
    #endregion
}