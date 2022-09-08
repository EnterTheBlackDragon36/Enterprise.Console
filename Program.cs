using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enterprise.Console
{
    class Program
    {
        static string customerConnectionString = ConfigurationManager.ConnectionStrings["PeopleSqlProvider"].ConnectionString;
        static string EnterpriseConnection = ConfigurationManager.ConnectionStrings["EnterpriseSqlProvider"].ConnectionString;
        static string DebugConnection = ConfigurationManager.ConnectionStrings["DebugSqlProvider"].ConnectionString;
        static string EonSoftConnection = ConfigurationManager.ConnectionStrings["EonSoftSqlProvider"].ConnectionString;
        static string AefnbConnection = ConfigurationManager.ConnectionStrings["AefnbSqlProvider"].ConnectionString;
        static string ApplicationsConnection = ConfigurationManager.ConnectionStrings["ApplicationsSqlProvider"].ConnectionString;
        static string AtlasTravelConnection = ConfigurationManager.ConnectionStrings["AtlasTravelSqlProvider"].ConnectionString;
        static string BaldEagleConnection = ConfigurationManager.ConnectionStrings["BaldEagleSqlProvider"].ConnectionString;
        static string CrestWaveConnection = ConfigurationManager.ConnectionStrings["CrestWaveSqlProvider"].ConnectionString;
        static string CustomCommConnection = ConfigurationManager.ConnectionStrings["CustomCommSqlProvider"].ConnectionString;
        static string HealthInfoConnection = ConfigurationManager.ConnectionStrings["HealthInfoSqlProvider"].ConnectionString;
        static string NmcConnection = ConfigurationManager.ConnectionStrings["NewtonianMotorCompanySqlProvider"].ConnectionString;
        static string NobleStatesmanConnection = ConfigurationManager.ConnectionStrings["NobleStatesmanSqlProvider"].ConnectionString;
        static string RetroplexConnection = ConfigurationManager.ConnectionStrings["RetroplexSqlProvider"].ConnectionString;
        static string TalkMobileConnection = ConfigurationManager.ConnectionStrings["TalkMobileSqlProvider"].ConnectionString;
        static string TradeShareConnection = ConfigurationManager.ConnectionStrings["TradeShareSqlProvider"].ConnectionString;
        static string TwentySecondCreditUnionConnection = ConfigurationManager.ConnectionStrings["TwentySecondCreditUnionSqlProvider"].ConnectionString;
        static string WfgsConnection = ConfigurationManager.ConnectionStrings["WellFitGymSpaSqlProvider"].ConnectionString;
        static string AdvWorks2016Connection = ConfigurationManager.ConnectionStrings["AdvWorks2016SqlProvider"].ConnectionString;
        static string onlineStatus;
        static string statusMessage;

        static void Main(string[] args)
        {
            executeDatabaseCheck();
            Recheck();
        }


        public static async void executeDatabaseCheck()
        {
            Thread.Sleep(15000); // 15 seconds
            checkDatabaseConnectionStatus();
            System.Console.ReadLine();
        }

        public static void Recheck()
        {
            executeDatabaseCheck();
        }

        private static List<SqlConnection> getListOfDatabaseConnections()
        {
            List<SqlConnection> databases = new List<SqlConnection>();
            var customerConnection = new SqlConnection(customerConnectionString);
            var Enterprise = new SqlConnection(EnterpriseConnection);
            var Debug = new SqlConnection(DebugConnection);
            var EonSoft = new SqlConnection(EonSoftConnection);
            var Aefnb = new SqlConnection(AefnbConnection);
            var Applications = new SqlConnection(ApplicationsConnection);
            var AtlasTravel = new SqlConnection(AtlasTravelConnection);
            var BaldEagle = new SqlConnection(BaldEagleConnection);
            var CrestWave = new SqlConnection(CrestWaveConnection);
            var CustomComm = new SqlConnection(CustomCommConnection);
            var HealthInfo = new SqlConnection(HealthInfoConnection);
            var Nmc = new SqlConnection(NmcConnection);
            var NobleStatesman = new SqlConnection(NobleStatesmanConnection);
            var Retroplex = new SqlConnection(RetroplexConnection);
            var TalkMobile = new SqlConnection(TalkMobileConnection);
            var TradeShare = new SqlConnection(TradeShareConnection);
            var TwentySecondCreditUnion = new SqlConnection(TwentySecondCreditUnionConnection);
            var Wfgs = new SqlConnection(WfgsConnection);
            var AdvWorks2016 = new SqlConnection(AdvWorks2016Connection);

            databases.Add(customerConnection);
            databases.Add(Enterprise);
            databases.Add(Debug);
            databases.Add(EonSoft);
            databases.Add(Aefnb);
            databases.Add(Applications);
            databases.Add(AtlasTravel);
            databases.Add(BaldEagle);
            databases.Add(CrestWave);
            databases.Add(CustomComm);
            databases.Add(HealthInfo);
            databases.Add(Nmc);
            databases.Add(NobleStatesman);
            databases.Add(Retroplex);
            databases.Add(TalkMobile);
            databases.Add(TradeShare);
            databases.Add(TwentySecondCreditUnion);
            databases.Add(Wfgs);
            databases.Add(AdvWorks2016);

            return databases;
        }


        private static void checkDatabaseConnectionStatus()
        {
            var databases = getListOfDatabaseConnections();
            foreach (var database in databases)
            {
                if (IsServerConnected(database))
                {
                    System.Console.WriteLine("Status: {0}", Status.Online.ToString());
                }
                else
                {
                    System.Console.WriteLine("Status: {0}", Status.Offline.ToString());
                }
            }
        }

        private static bool IsServerConnected(SqlConnection database)
        {
            using (SqlConnection conn = database)
            {
                try
                {
                    conn.Open();
                    //System.Console.WriteLine("Connection Successful");
                    conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    //System.Console.WriteLine("There was a problem connecting to your SQL Server Database");
                    return false;
                    throw;
                }
            }
        }

        //private static string ServerOnlineStatus()
        //{
        //    if (IsServerConnected())
        //    {
        //        onlineStatus = Status.Online.ToString();
        //    }
        //    else
        //    {
        //        onlineStatus = Status.Offline.ToString();
        //    }
        //    return onlineStatus;
        //}

        public enum Status
        {
            Offline,
            Online
        }
    }
}
