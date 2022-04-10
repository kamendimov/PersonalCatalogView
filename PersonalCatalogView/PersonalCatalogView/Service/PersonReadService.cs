using PersonalCatalogView.ObjectModel;
using System;
using System.Data.SQLite;

namespace PersonalCatalogView.Service
{
    public class PersonReadService : IPersonReadService
    {
        public PersonPersistentObject FindPersonByAddress(string address)
        {
            DatabaseProvider databaseProvider = DatabaseProvider.GetDatabaseProvider();
            String sql = @"select Id, FirstName, SurName, Dob, Address, PhoneNumber, IBAN from 
                                PERSONAL_INFO where FirstName like @address";

            SQLiteCommand Command = new SQLiteCommand(sql, DatabaseProvider.GetDbConnection());
            SQLiteParameter Param = new SQLiteParameter("@address", address);
            Command.Parameters.Add(Param);
            SQLiteDataReader Reader = Command.ExecuteReader();

            PersonPersistentObject person = null;
            if (Reader.Read())
            {
                person = new PersonPersistentObject();

                person.Id = (Int64)Reader["Id"];
                person.FirstName = (String)Reader["FirstName"];

                person.SurName = (String)Reader["SurName"];
                person.SetDobFromString((String)Reader["Dob"]);

                person.Address = (String)Reader["Address"];
                person.PhoneNumber = (String)Reader["PhoneNumber"];

                person.IBAN = (String)Reader["IBAN"];
            }
            Command.Dispose();
            Reader.Close();

            return person;
        }

        public PersonPersistentObject FindPersonByFirstName(string FirstName)
        {
            DatabaseProvider databaseProvider = DatabaseProvider.GetDatabaseProvider();
            String sql = @"select Id, FirstName, SurName, Dob, Address, PhoneNumber, IBAN from 
                                PERSONAL_INFO where FirstName like @FirstName";

            SQLiteCommand Command = new SQLiteCommand(sql, DatabaseProvider.GetDbConnection());
            SQLiteParameter Param = new SQLiteParameter("@FirstName", FirstName + "%");
            Command.Parameters.Add(Param);
            SQLiteDataReader Reader = Command.ExecuteReader();

            PersonPersistentObject person = null;
            if (Reader.Read())
            {
                person = new PersonPersistentObject();

                person.Id = (Int64)Reader["Id"];
                person.FirstName = (String)Reader["FirstName"];

                person.SurName = (String)Reader["SurName"];
                person.SetDobFromString((String)Reader["Dob"]);

                person.Address = (String)Reader["Address"];
                person.PhoneNumber = (String)Reader["PhoneNumber"];

                person.IBAN = (String)Reader["IBAN"];
            }
            Command.Dispose();
            Reader.Close();

            return person;
        }

        public PersonPersistentObject FindPersonByIBAN(string iban)
        {
            DatabaseProvider databaseProvider = DatabaseProvider.GetDatabaseProvider();
            String sql = @"select Id, FirstName, SurName, Dob, Address, PhoneNumber, IBAN from 
                                PERSONAL_INFO where IBAN like @iban";

            SQLiteCommand Command = new SQLiteCommand(sql, DatabaseProvider.GetDbConnection());
            SQLiteParameter Param = new SQLiteParameter("@iban", iban);
            Command.Parameters.Add(Param);
            SQLiteDataReader Reader = Command.ExecuteReader();

            PersonPersistentObject person = null;
            if (Reader.Read())
            {
                person = new PersonPersistentObject();

                person.Id = (Int64)Reader["Id"];
                person.FirstName = (String)Reader["FirstName"];

                person.SurName = (String)Reader["SurName"];
                person.SetDobFromString((String)Reader["Dob"]);

                person.Address = (String)Reader["Address"];
                person.PhoneNumber = (String)Reader["PhoneNumber"];

                person.IBAN = (String)Reader["IBAN"];
            }
            Command.Dispose();
            Reader.Close();

            return person;
        }

        public PersonPersistentObject FindPersonByPhoneNumber(string phoneNumber)
        {
            DatabaseProvider databaseProvider = DatabaseProvider.GetDatabaseProvider();
            String sql = @"select Id, FirstName, SurName, Dob, Address, PhoneNumber, IBAN from 
                                PERSONAL_INFO where PhoneNumber like @phoneNumber";

            SQLiteCommand Command = new SQLiteCommand(sql, DatabaseProvider.GetDbConnection());
            SQLiteParameter Param = new SQLiteParameter("@phoneNumber", phoneNumber);
            Command.Parameters.Add(Param);
            SQLiteDataReader Reader = Command.ExecuteReader();

            PersonPersistentObject person = null;
            if (Reader.Read())
            {
                person = new PersonPersistentObject();

                person.Id = (Int64)Reader["Id"];
                person.FirstName = (String)Reader["FirstName"];

                person.SurName = (String)Reader["SurName"];
                person.SetDobFromString((String)Reader["Dob"]);

                person.Address = (String)Reader["Address"];
                person.PhoneNumber = (String)Reader["PhoneNumber"];

                person.IBAN = (String)Reader["IBAN"];
            }
            Command.Dispose();
            Reader.Close();

            return person;
        }

        public PersonPersistentObject GetPersonById(int Id)
        {
            DatabaseProvider databaseProvider = DatabaseProvider.GetDatabaseProvider();
            String sql = @"select Id, FirstName, SurName, Dob, Address, PhoneNumber, IBAN from PERSONAL_INFO where Id = @Id";

            SQLiteCommand Command = new SQLiteCommand(sql, DatabaseProvider.GetDbConnection());
            SQLiteParameter Param = new SQLiteParameter("@Id", Id);
            Command.Parameters.Add(Param);
            SQLiteDataReader Reader = Command.ExecuteReader();

            PersonPersistentObject person = null;
            if (Reader.Read())
            {
                person = new PersonPersistentObject();

                person.Id = (Int64)Reader["Id"];
                person.FirstName = (String)Reader["FirstName"];

                person.SurName = (String)Reader["SurName"];
                person.SetDobFromString((String)Reader["Dob"]);

                person.Address = (String)Reader["Address"];
                person.PhoneNumber = (String)Reader["PhoneNumber"];

                person.IBAN = (String)Reader["IBAN"];
            }
            Command.Dispose();
            Reader.Close();

            return person;
        }
    }
}
