using System;

namespace SingletonLogger
{
    
    // ABSTRACT BASE CLASS
   
    public abstract class Database
    {
        public Logger _logger = null;

        public Database()
        {
            // Every Database object gets the same Logger instance (Singleton)
            _logger = Logger.GetLogger();
        }

        // Abstract methods to be implemented by concrete databases
        protected abstract void DoInsert();
        protected abstract void DoUpdate();
        protected abstract void DoDelete();
        protected abstract string GetDataBaseName();

        // Public methods that wrap operations and log them
        public void Insert()
        {
            DoInsert();
            _logger.Log($"Insert From {GetDataBaseName()} done.");
        }

        public void Update()
        {
            DoUpdate();
            _logger.Log($"Update From {GetDataBaseName()} done.");
        }

        public void Delete()
        {
            DoDelete();
            _logger.Log($"Delete From {GetDataBaseName()} done.");
        }
    }

    
    // CONCRETE DATABASE IMPLEMENTATIONS
    
    public class SqlServer : Database
    {
        protected override string GetDataBaseName() => "Sql Server";

        protected override void DoInsert() => Console.WriteLine("Record Inserted in SqlServer Successfully");
        protected override void DoUpdate() => Console.WriteLine("Record Updated in SqlServer Successfully");
        protected override void DoDelete() => Console.WriteLine("Record Deleted from SqlServer Successfully");
    }

    public class MySqlServer : Database
    {
        protected override string GetDataBaseName() => "MySQL Server";

        protected override void DoInsert() => Console.WriteLine("Record Inserted in MySql Successfully");
        protected override void DoUpdate() => Console.WriteLine("Record Updated in MySql Successfully");
        protected override void DoDelete() => Console.WriteLine("Record Deleted from MySql Successfully");
    }

    public class OracleServer : Database
    {
        protected override string GetDataBaseName() => "Oracle Server";

        protected override void DoInsert() => Console.WriteLine("Record Inserted in OracleServer Successfully");
        protected override void DoUpdate() => Console.WriteLine("Record Updated in OracleServer Successfully");
        protected override void DoDelete() => Console.WriteLine("Record Deleted from OracleServer Successfully");
    }

   
    // FACTORY CLASS
  
    public class DataBaseFactory
    {
        public Database GetSomeDatabase(int dbChoice)
        {
            Database db = null;
            switch (dbChoice)
            {
                case 1: db = new SqlServer(); break;
                case 2: db = new MySqlServer(); break;
                case 3: db = new OracleServer(); break;
                default: db = null; break;
            }
            return db;
        }
    }


    // SINGLETON LOGGER CLASS
  
    public class Logger
    {
        // Single static instance created once
        private static readonly Logger _logger1 = new Logger();

        // Private constructor prevents external instantiation
        private Logger()
        {
            Console.WriteLine("Logger Object is created for the first time!..");
        }

        // Public method to get the single Logger instance
        public static Logger GetLogger()
        {
            return _logger1;
        }

        // Log method
        public void Log(string message)
        {
            Console.WriteLine("---Logged at {0}, message : {1}", DateTime.Now.ToString(), message);
        }
    }

   
    // PROGRAM ENTRY POINT
   
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter your Db choice. 1. SqlServer, 2. MySql Server, 3. Oracle Server");
                int dbChoice = Convert.ToInt32(Console.ReadLine());

                DataBaseFactory factory = new DataBaseFactory();
                Database someDatabaseObject = factory.GetSomeDatabase(dbChoice);

                Console.WriteLine("Enter db operation choice : 1. Insert, 2. Update, 3. Delete");
                int opChoice = Convert.ToInt32(Console.ReadLine());

                switch (opChoice)
                {
                    case 1: someDatabaseObject.Insert(); break;
                    case 2: someDatabaseObject.Update(); break;
                    case 3: someDatabaseObject.Delete(); break;
                    default: Console.WriteLine("Invalid Db operation Choice"); break;
                }

                Console.WriteLine("Do you want to continue? y/n");
                string ynChoice = Console.ReadLine();
                if (ynChoice == "n")
                {
                    break;
                }
            }
        }
    }
}
