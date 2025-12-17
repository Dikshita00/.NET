using System;
namespace ReportFactoryPattern
{
    // ABSTRACT BASE CLASSES
    public abstract class Report
    {
                                                             protected abstract void Parse();
        protected abstract void Validate();
        protected abstract void Save();

        public virtual void GeneralReport()
        { 
            Parse();
            Validate();
            Save();
            Console.WriteLine("Report generated");
        }
    }
    public abstract class SpecialReport : Report
    {
        protected abstract void ReValidate();

        public override void GeneralReport()
        {
            Parse();
            Validate();
            ReValidate();
            Save();
            Console.WriteLine("Special Report generated");
        }
    }
    // CONCRETE REPORT IMPLEMENTATIONS

    public class PDF : Report
    {
        protected override void Parse() => Console.WriteLine("PDF parsed");
        protected override void Validate() => Console.WriteLine("PDF validated");
        protected override void Save() => Console.WriteLine("PDF Saved");
        
    }

    public class DOCX : Report
    {
        protected override void Parse() => Console.WriteLine("DOCX parsed");
        protected override void Validate() => Console.WriteLine("DOCX validation");
        protected override void Save() => Console.WriteLine("DOCX Saved");

    }

    public class Excel : Report
    {
        protected override void Parse() => Console.WriteLine("Excle parsed");
        protected override void Validate() => Console.WriteLine("Excle validated");
        protected override void Save() => Console.WriteLine("Excle Saved");
        
    }
    public class XML : SpecialReport
    {
        protected override void Parse() => Console.WriteLine("XML parsed.");
        protected override void Validate() => Console.WriteLine("XML validated.");
        protected override void Save() => Console.WriteLine("XML Saved.");
        protected override void ReValidate() => Console.WriteLine("XML Re-Validated.");
    }

    public class JSON : SpecialReport
    {
        protected override void Parse() => Console.WriteLine("JSON parsed.");
        protected override void Validate() => Console.WriteLine("JSON validated.");
        protected override void Save() => Console.WriteLine("JSON Saved.");
        protected override void ReValidate() => Console.WriteLine("JSON Re-Validated.");
    }

    // FACTORY CLASS

    public class ReportFactory
    { 
        public  Report GetSomeReport(int choice) {
            Report someReport = null;
           
            switch (choice) 
            {
                case 1:
                    someReport = new PDF();
                    break;

                case 2:
                    someReport = new DOCX();
                    break;

                case 3:
                    someReport= new Excel();
                    break;

                case 4:
                    someReport= new XML();
                    break;

                case 5:
                    someReport= new JSON();
                    break;

                default:
                    someReport = null;
                    break;
            }
            return someReport;
        }
    }
    // PROGRAM ENTRY POINT

    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter your choice: 1. PDF, 2. DOCX, 3. Excel, 4. XML, 5. JSON");
                int choice = Convert.ToInt32(Console.ReadLine());
                
                ReportFactory factory = new ReportFactory();
                Report report = factory.GetSomeReport(choice);

                if (report != null)
                {
                    report.GeneralReport();
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }

                Console.WriteLine("Do you want to continue ?? 'y/n'");
                string ynChoice = Console.ReadLine();

                if (ynChoice == "n")
                {
                    break;
                }
            }
        }
    }

}