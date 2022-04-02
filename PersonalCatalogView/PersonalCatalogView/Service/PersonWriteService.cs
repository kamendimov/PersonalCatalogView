using PersonalCatalogView.ObjectModel;
using System;
using System.Data.SQLite;

namespace PersonalCatalogView.Service
{
    public class PersonWriteService : IPersonWriteService
    {
        public void SavePerson(Person person)
        {
            DatabaseProvider databaseProvider = DatabaseProvider.GetDatabaseProvider();
            String Sql = @"insert into PERSONAL_INFO (FirstName, SurName, Dob, Address, PhoneNumber, IBAN) values 
                                       (?, ?, ?, ?, ?, ?)";

            SQLiteCommand RoutesCommand = new SQLiteCommand(Sql, DatabaseProvider.GetDbConnection());

            SQLiteParameter FirstName = new SQLiteParameter("FirstName", person.FirstName);
            SQLiteParameter SurName = new SQLiteParameter("SurName", person.SurName);
            SQLiteParameter Dob = new SQLiteParameter("Dob", person.GetDobAsTring());
            SQLiteParameter Address = new SQLiteParameter("Address", person.Address);
            SQLiteParameter PhoneNumber = new SQLiteParameter("PhoneNumber", person.PhoneNumber);
            SQLiteParameter IBAN = new SQLiteParameter("IBAN", person.IBAN);

            RoutesCommand.Parameters.Add(FirstName);
            RoutesCommand.Parameters.Add(SurName);
            RoutesCommand.Parameters.Add(Dob);
            RoutesCommand.Parameters.Add(Address);
            RoutesCommand.Parameters.Add(PhoneNumber);
            RoutesCommand.Parameters.Add(IBAN);

            RoutesCommand.ExecuteNonQuery();

            Sql = @"select last_insert_rowid()";

            SQLiteCommand LastIdCommand = new SQLiteCommand(Sql, DatabaseProvider.GetDbConnection());
            person.Id = (long)LastIdCommand.ExecuteScalar();
        }

        public void UpdatePerson(Person person)
        {
            DatabaseProvider databaseProvider = DatabaseProvider.GetDatabaseProvider();
            String Sql = @"update PERSONAL_INFO set FirstName = @FirstName, SurName = @SurName, Dob = @Dob, 
                            Address = @Address, PhoneNumber = @PhoneNumber, IBAN = @IBAN where Id = @Id";

            SQLiteCommand RoutesCommand = new SQLiteCommand(Sql, DatabaseProvider.GetDbConnection());

            SQLiteParameter FirstName = new SQLiteParameter("FirstName", person.FirstName);
            SQLiteParameter SurName = new SQLiteParameter("SurName", person.SurName);
            SQLiteParameter Dob = new SQLiteParameter("Dob", person.GetDobAsTring());
            SQLiteParameter Address = new SQLiteParameter("Address", person.Address);
            SQLiteParameter PhoneNumber = new SQLiteParameter("PhoneNumber", person.PhoneNumber);
            SQLiteParameter IBAN = new SQLiteParameter("IBAN", person.IBAN);
            SQLiteParameter Id = new SQLiteParameter("Id", person.Id);

            RoutesCommand.Parameters.Add(FirstName);
            RoutesCommand.Parameters.Add(SurName);
            RoutesCommand.Parameters.Add(Dob);
            RoutesCommand.Parameters.Add(Address);
            RoutesCommand.Parameters.Add(PhoneNumber);
            RoutesCommand.Parameters.Add(IBAN);
            RoutesCommand.Parameters.Add(Id);

            RoutesCommand.ExecuteNonQuery();
        }
    }
}
