using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;

public class DatabaseHelper
{
    // Строка подключения для PostgreSQL
    NpgsqlConnection npgsqlConnection = new NpgsqlConnection(
        "Host=localhost; Port=5432; Database=Hospital; Username=postgres; Password=postgres"
    );

    public void openConnection()
    {
        if (npgsqlConnection.State == System.Data.ConnectionState.Closed)
        {
            npgsqlConnection.Open();
        }
    }

    public void CloseConnection()
    {
        if (npgsqlConnection.State == System.Data.ConnectionState.Open)
        {
            npgsqlConnection.Close();
        }
    }

    public NpgsqlConnection getConnection()
    {
        return npgsqlConnection;
    }
}

// ==================== Модели таблиц ====================

public class Region
{
    public int ID { get; set; }
    public string Region_name { get; set; }
}

public class City
{
    public int ID { get; set; }
    public string City_Name { get; set; }
}

public class Street
{
    public int ID { get; set; }
    public string Street_Name { get; set; }
}

public class House
{
    public int ID { get; set; }
    public string House_Number { get; set; }
}

public class Addres
{
    public int ID { get; set; }
    public int FK_IDRegion { get; set; }
    public int FK_IDCity { get; set; }
    public int FK_IDStreet { get; set; }
    public int FK_IDHouse { get; set; }
    public string Postal_Code { get; set; }
}

public class Passport
{
    public int ID { get; set; }
    public string Series { get; set; }
    public string Number { get; set; }
    public string Issued_By { get; set; }
    public DateTime Issue_Date { get; set; }
}

public class Cardpatient
{
    public int ID { get; set; }
    public int FK_IDAdres { get; set; }
    public int FK_IDPassport { get; set; }
    public string Surname { get; set; }
    public string Patronomik { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { get; set; }
}

public class Registration
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class Application
{
    public int ID { get; set; }
    public int FK_IDCardpatient { get; set; }
    public byte[] FailCard { get; set; }
    public byte[] Picture { get; set; }
    public string Description { get; set; }
    public string Doctor_Name { get; set; }
}

public class Accaunt
{
    public int ID { get; set; }
    public int FK_IDCardpatient { get; set; }
    public int FK_IDRegistration { get; set; }
    public byte[] Photo { get; set; }
}

// ==================== Репозиторий для работы с таблицами ====================

public class HospitalRepository
{
    private DatabaseHelper dbHelper;

    public HospitalRepository(DatabaseHelper helper)
    {
        dbHelper = helper;
    }

    // ========== Region ==========
    public void InsertRegion(Region region)
    {
        string query = "INSERT INTO Region (Region_name) VALUES (@Region_name) RETURNING ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@Region_name", region.Region_name);
            region.ID = Convert.ToInt32(cmd.ExecuteScalar());
        }
        dbHelper.CloseConnection();
    }

    public List<Region> GetAllRegions()
    {
        List<Region> regions = new List<Region>();
        string query = "SELECT * FROM Region";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        using (NpgsqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                regions.Add(new Region
                {
                    ID = reader.GetInt32(0),
                    Region_name = reader.GetString(1)
                });
            }
        }
        dbHelper.CloseConnection();
        return regions;
    }

    public Region GetRegionById(int id)
    {
        Region region = null;
        string query = "SELECT * FROM Region WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@ID", id);
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    region = new Region
                    {
                        ID = reader.GetInt32(0),
                        Region_name = reader.GetString(1)
                    };
                }
            }
        }
        dbHelper.CloseConnection();
        return region;
    }

    public void UpdateRegion(Region region)
    {
        string query = "UPDATE Region SET Region_name = @Region_name WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@Region_name", region.Region_name);
            cmd.Parameters.AddWithValue("@ID", region.ID);
            cmd.ExecuteNonQuery();
        }
        dbHelper.CloseConnection();
    }

    public void DeleteRegion(int id)
    {
        string query = "DELETE FROM Region WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }
        dbHelper.CloseConnection();
    }

    // ========== City ==========
    public void InsertCity(City city)
    {
        string query = "INSERT INTO City (City_Name) VALUES (@City_Name) RETURNING ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@City_Name", city.City_Name);
            city.ID = Convert.ToInt32(cmd.ExecuteScalar());
        }
        dbHelper.CloseConnection();
    }

    public List<City> GetAllCities()
    {
        List<City> cities = new List<City>();
        string query = "SELECT * FROM City";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        using (NpgsqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                cities.Add(new City
                {
                    ID = reader.GetInt32(0),
                    City_Name = reader.GetString(1)
                });
            }
        }
        dbHelper.CloseConnection();
        return cities;
    }

    public City GetCityById(int id)
    {
        City city = null;
        string query = "SELECT * FROM City WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@ID", id);
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    city = new City
                    {
                        ID = reader.GetInt32(0),
                        City_Name = reader.GetString(1)
                    };
                }
            }
        }
        dbHelper.CloseConnection();
        return city;
    }

    public void UpdateCity(City city)
    {
        string query = "UPDATE City SET City_Name = @City_Name WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@City_Name", city.City_Name);
            cmd.Parameters.AddWithValue("@ID", city.ID);
            cmd.ExecuteNonQuery();
        }
        dbHelper.CloseConnection();
    }

    public void DeleteCity(int id)
    {
        string query = "DELETE FROM City WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }
        dbHelper.CloseConnection();
    }

    // ========== Street ==========
    public void InsertStreet(Street street)
    {
        string query = "INSERT INTO Street (Street_Name) VALUES (@Street_Name) RETURNING ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@Street_Name", street.Street_Name);
            street.ID = Convert.ToInt32(cmd.ExecuteScalar());
        }
        dbHelper.CloseConnection();
    }

    public List<Street> GetAllStreets()
    {
        List<Street> streets = new List<Street>();
        string query = "SELECT * FROM Street";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        using (NpgsqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                streets.Add(new Street
                {
                    ID = reader.GetInt32(0),
                    Street_Name = reader.GetString(1)
                });
            }
        }
        dbHelper.CloseConnection();
        return streets;
    }

    public Street GetStreetById(int id)
    {
        Street street = null;
        string query = "SELECT * FROM Street WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@ID", id);
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    street = new Street
                    {
                        ID = reader.GetInt32(0),
                        Street_Name = reader.GetString(1)
                    };
                }
            }
        }
        dbHelper.CloseConnection();
        return street;
    }

    public void UpdateStreet(Street street)
    {
        string query = "UPDATE Street SET Street_Name = @Street_Name WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@Street_Name", street.Street_Name);
            cmd.Parameters.AddWithValue("@ID", street.ID);
            cmd.ExecuteNonQuery();
        }
        dbHelper.CloseConnection();
    }

    public void DeleteStreet(int id)
    {
        string query = "DELETE FROM Street WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }
        dbHelper.CloseConnection();
    }

    // ========== House ==========
    public void InsertHouse(House house)
    {
        string query = "INSERT INTO House (House_Number) VALUES (@House_Number) RETURNING ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@House_Number", house.House_Number);
            house.ID = Convert.ToInt32(cmd.ExecuteScalar());
        }
        dbHelper.CloseConnection();
    }

    public List<House> GetAllHouses()
    {
        List<House> houses = new List<House>();
        string query = "SELECT * FROM House";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        using (NpgsqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                houses.Add(new House
                {
                    ID = reader.GetInt32(0),
                    House_Number = reader.GetString(1)
                });
            }
        }
        dbHelper.CloseConnection();
        return houses;
    }

    public House GetHouseById(int id)
    {
        House house = null;
        string query = "SELECT * FROM House WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@ID", id);
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    house = new House
                    {
                        ID = reader.GetInt32(0),
                        House_Number = reader.GetString(1)
                    };
                }
            }
        }
        dbHelper.CloseConnection();
        return house;
    }

    public void UpdateHouse(House house)
    {
        string query = "UPDATE House SET House_Number = @House_Number WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@House_Number", house.House_Number);
            cmd.Parameters.AddWithValue("@ID", house.ID);
            cmd.ExecuteNonQuery();
        }
        dbHelper.CloseConnection();
    }

    public void DeleteHouse(int id)
    {
        string query = "DELETE FROM House WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }
        dbHelper.CloseConnection();
    }

    // ========== Addres ==========
    public void InsertAddres(Addres addres)
    {
        string query = @"INSERT INTO Addres (FK_IDRegion, FK_IDCity, FK_IDStreet, FK_IDHouse, Postal_Code) 
                         VALUES (@FK_IDRegion, @FK_IDCity, @FK_IDStreet, @FK_IDHouse, @Postal_Code) RETURNING ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@FK_IDRegion", addres.FK_IDRegion);
            cmd.Parameters.AddWithValue("@FK_IDCity", addres.FK_IDCity);
            cmd.Parameters.AddWithValue("@FK_IDStreet", addres.FK_IDStreet);
            cmd.Parameters.AddWithValue("@FK_IDHouse", addres.FK_IDHouse);
            cmd.Parameters.AddWithValue("@Postal_Code", addres.Postal_Code);
            addres.ID = Convert.ToInt32(cmd.ExecuteScalar());
        }
        dbHelper.CloseConnection();
    }

    public List<Addres> GetAllAddresses()
    {
        List<Addres> addresses = new List<Addres>();
        string query = "SELECT * FROM Addres";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        using (NpgsqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                addresses.Add(new Addres
                {
                    ID = reader.GetInt32(0),
                    FK_IDRegion = reader.GetInt32(1),
                    FK_IDCity = reader.GetInt32(2),
                    FK_IDStreet = reader.GetInt32(3),
                    FK_IDHouse = reader.GetInt32(4),
                    Postal_Code = reader.GetString(5)
                });
            }
        }
        dbHelper.CloseConnection();
        return addresses;
    }

    public Addres GetAddresById(int id)
    {
        Addres addres = null;
        string query = "SELECT * FROM Addres WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@ID", id);
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    addres = new Addres
                    {
                        ID = reader.GetInt32(0),
                        FK_IDRegion = reader.GetInt32(1),
                        FK_IDCity = reader.GetInt32(2),
                        FK_IDStreet = reader.GetInt32(3),
                        FK_IDHouse = reader.GetInt32(4),
                        Postal_Code = reader.GetString(5)
                    };
                }
            }
        }
        dbHelper.CloseConnection();
        return addres;
    }

    public void UpdateAddres(Addres addres)
    {
        string query = @"UPDATE Addres SET FK_IDRegion = @FK_IDRegion, FK_IDCity = @FK_IDCity, 
                         FK_IDStreet = @FK_IDStreet, FK_IDHouse = @FK_IDHouse, Postal_Code = @Postal_Code 
                         WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@FK_IDRegion", addres.FK_IDRegion);
            cmd.Parameters.AddWithValue("@FK_IDCity", addres.FK_IDCity);
            cmd.Parameters.AddWithValue("@FK_IDStreet", addres.FK_IDStreet);
            cmd.Parameters.AddWithValue("@FK_IDHouse", addres.FK_IDHouse);
            cmd.Parameters.AddWithValue("@Postal_Code", addres.Postal_Code);
            cmd.Parameters.AddWithValue("@ID", addres.ID);
            cmd.ExecuteNonQuery();
        }
        dbHelper.CloseConnection();
    }

    public void DeleteAddres(int id)
    {
        string query = "DELETE FROM Addres WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }
        dbHelper.CloseConnection();
    }

    // ========== Passport ==========
    public void InsertPassport(Passport passport)
    {
        string query = @"INSERT INTO Passport (Series, Number, Issued_By, Issue_Date) 
                         VALUES (@Series, @Number, @Issued_By, @Issue_Date) RETURNING ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@Series", passport.Series);
            cmd.Parameters.AddWithValue("@Number", passport.Number);
            cmd.Parameters.AddWithValue("@Issued_By", passport.Issued_By);
            cmd.Parameters.AddWithValue("@Issue_Date", passport.Issue_Date);
            passport.ID = Convert.ToInt32(cmd.ExecuteScalar());
        }
        dbHelper.CloseConnection();
    }

    public List<Passport> GetAllPassports()
    {
        List<Passport> passports = new List<Passport>();
        string query = "SELECT * FROM Passport";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        using (NpgsqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                passports.Add(new Passport
                {
                    ID = reader.GetInt32(0),
                    Series = reader.GetString(1),
                    Number = reader.GetString(2),
                    Issued_By = reader.GetString(3),
                    Issue_Date = reader.GetDateTime(4)
                });
            }
        }
        dbHelper.CloseConnection();
        return passports;
    }

    public Passport GetPassportById(int id)
    {
        Passport passport = null;
        string query = "SELECT * FROM Passport WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@ID", id);
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    passport = new Passport
                    {
                        ID = reader.GetInt32(0),
                        Series = reader.GetString(1),
                        Number = reader.GetString(2),
                        Issued_By = reader.GetString(3),
                        Issue_Date = reader.GetDateTime(4)
                    };
                }
            }
        }
        dbHelper.CloseConnection();
        return passport;
    }

    public void UpdatePassport(Passport passport)
    {
        string query = @"UPDATE Passport SET Series = @Series, Number = @Number, 
                         Issued_By = @Issued_By, Issue_Date = @Issue_Date WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@Series", passport.Series);
            cmd.Parameters.AddWithValue("@Number", passport.Number);
            cmd.Parameters.AddWithValue("@Issued_By", passport.Issued_By);
            cmd.Parameters.AddWithValue("@Issue_Date", passport.Issue_Date);
            cmd.Parameters.AddWithValue("@ID", passport.ID);
            cmd.ExecuteNonQuery();
        }
        dbHelper.CloseConnection();
    }

    public void DeletePassport(int id)
    {
        string query = "DELETE FROM Passport WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }
        dbHelper.CloseConnection();
    }

    // ========== Cardpatient ==========
    public void InsertCardpatient(Cardpatient cardpatient)
    {
        string query = @"INSERT INTO Cardpatient (FK_IDAdres, FK_IDPassport, Surname, Patronomik, Name, Email, PhoneNumber, Age) 
                         VALUES (@FK_IDAdres, @FK_IDPassport, @Surname, @Patronomik, @Name, @Email, @PhoneNumber, @Age) RETURNING ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@FK_IDAdres", cardpatient.FK_IDAdres);
            cmd.Parameters.AddWithValue("@FK_IDPassport", cardpatient.FK_IDPassport);
            cmd.Parameters.AddWithValue("@Surname", cardpatient.Surname);
            cmd.Parameters.AddWithValue("@Patronomik", cardpatient.Patronomik);
            cmd.Parameters.AddWithValue("@Name", cardpatient.Name);
            cmd.Parameters.AddWithValue("@Email", cardpatient.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", cardpatient.PhoneNumber);
            cmd.Parameters.AddWithValue("@Age", cardpatient.Age);
            cardpatient.ID = Convert.ToInt32(cmd.ExecuteScalar());
        }
        dbHelper.CloseConnection();
    }

    public List<Cardpatient> GetAllCardpatients()
    {
        List<Cardpatient> cardpatients = new List<Cardpatient>();
        string query = "SELECT * FROM Cardpatient";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        using (NpgsqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                cardpatients.Add(new Cardpatient
                {
                    ID = reader.GetInt32(0),
                    FK_IDAdres = reader.GetInt32(1),
                    FK_IDPassport = reader.GetInt32(2),
                    Surname = reader.GetString(3),
                    Patronomik = reader.GetString(4),
                    Name = reader.GetString(5),
                    Email = reader.GetString(6),
                    PhoneNumber = reader.GetString(7),
                    Age = reader.GetInt32(8)
                });
            }
        }
        dbHelper.CloseConnection();
        return cardpatients;
    }

    public Cardpatient GetCardpatientById(int id)
    {
        Cardpatient cardpatient = null;
        string query = "SELECT * FROM Cardpatient WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@ID", id);
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    cardpatient = new Cardpatient
                    {
                        ID = reader.GetInt32(0),
                        FK_IDAdres = reader.GetInt32(1),
                        FK_IDPassport = reader.GetInt32(2),
                        Surname = reader.GetString(3),
                        Patronomik = reader.GetString(4),
                        Name = reader.GetString(5),
                        Email = reader.GetString(6),
                        PhoneNumber = reader.GetString(7),
                        Age = reader.GetInt32(8)
                    };
                }
            }
        }
        dbHelper.CloseConnection();
        return cardpatient;
    }

    public void UpdateCardpatient(Cardpatient cardpatient)
    {
        string query = @"UPDATE Cardpatient SET FK_IDAdres = @FK_IDAdres, FK_IDPassport = @FK_IDPassport, 
                         Surname = @Surname, Patronomik = @Patronomik, Name = @Name, 
                         Email = @Email, PhoneNumber = @PhoneNumber, Age = @Age WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@FK_IDAdres", cardpatient.FK_IDAdres);
            cmd.Parameters.AddWithValue("@FK_IDPassport", cardpatient.FK_IDPassport);
            cmd.Parameters.AddWithValue("@Surname", cardpatient.Surname);
            cmd.Parameters.AddWithValue("@Patronomik", cardpatient.Patronomik);
            cmd.Parameters.AddWithValue("@Name", cardpatient.Name);
            cmd.Parameters.AddWithValue("@Email", cardpatient.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", cardpatient.PhoneNumber);
            cmd.Parameters.AddWithValue("@Age", cardpatient.Age);
            cmd.Parameters.AddWithValue("@ID", cardpatient.ID);
            cmd.ExecuteNonQuery();
        }
        dbHelper.CloseConnection();
    }

    public void DeleteCardpatient(int id)
    {
        string query = "DELETE FROM Cardpatient WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }
        dbHelper.CloseConnection();
    }

    // ========== Registration ==========
    public void InsertRegistration(Registration registration)
    {
        string query = @"INSERT INTO Registration (Name, Email, Password) 
                         VALUES (@Name, @Email, @Password) RETURNING ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@Name", registration.Name);
            cmd.Parameters.AddWithValue("@Email", registration.Email);
            cmd.Parameters.AddWithValue("@Password", registration.Password);
            registration.ID = Convert.ToInt32(cmd.ExecuteScalar());
        }
        dbHelper.CloseConnection();
    }

    public List<Registration> GetAllRegistrations()
    {
        List<Registration> registrations = new List<Registration>();
        string query = "SELECT * FROM Registration";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        using (NpgsqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                registrations.Add(new Registration
                {
                    ID = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Email = reader.GetString(2),
                    Password = reader.GetString(3)
                });
            }
        }
        dbHelper.CloseConnection();
        return registrations;
    }

    public Registration GetRegistrationById(int id)
    {
        Registration registration = null;
        string query = "SELECT * FROM Registration WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@ID", id);
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    registration = new Registration
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Email = reader.GetString(2),
                        Password = reader.GetString(3)
                    };
                }
            }
        }
        dbHelper.CloseConnection();
        return registration;
    }

    public void UpdateRegistration(Registration registration)
    {
        string query = @"UPDATE Registration SET Name = @Name, Email = @Email, Password = @Password WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@Name", registration.Name);
            cmd.Parameters.AddWithValue("@Email", registration.Email);
            cmd.Parameters.AddWithValue("@Password", registration.Password);
            cmd.Parameters.AddWithValue("@ID", registration.ID);
            cmd.ExecuteNonQuery();
        }
        dbHelper.CloseConnection();
    }

    public void DeleteRegistration(int id)
    {
        string query = "DELETE FROM Registration WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }
        dbHelper.CloseConnection();
    }

    // ========== Application ==========
    public void InsertApplication(Application application)
    {
        string query = @"INSERT INTO Application (FK_IDCardpatient, FailCard, Picture, Description, Doctor_Name) 
                         VALUES (@FK_IDCardpatient, @FailCard, @Picture, @Description, @Doctor_Name) RETURNING ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@FK_IDCardpatient", application.FK_IDCardpatient);
            cmd.Parameters.AddWithValue("@FailCard", application.FailCard ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Picture", application.Picture ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Description", application.Description);
            cmd.Parameters.AddWithValue("@Doctor_Name", application.Doctor_Name);
            application.ID = Convert.ToInt32(cmd.ExecuteScalar());
        }
        dbHelper.CloseConnection();
    }

    public List<Application> GetAllApplications()
    {
        List<Application> applications = new List<Application>();
        string query = "SELECT * FROM Application";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        using (NpgsqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                applications.Add(new Application
                {
                    ID = reader.GetInt32(0),
                    FK_IDCardpatient = reader.GetInt32(1),
                    FailCard = reader.IsDBNull(2) ? null : (byte[])reader[2],
                    Picture = reader.IsDBNull(3) ? null : (byte[])reader[3],
                    Description = reader.GetString(4),
                    Doctor_Name = reader.GetString(5)
                });
            }
        }
        dbHelper.CloseConnection();
        return applications;
    }

    public Application GetApplicationById(int id)
    {
        Application application = null;
        string query = "SELECT * FROM Application WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@ID", id);
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    application = new Application
                    {
                        ID = reader.GetInt32(0),
                        FK_IDCardpatient = reader.GetInt32(1),
                        FailCard = reader.IsDBNull(2) ? null : (byte[])reader[2],
                        Picture = reader.IsDBNull(3) ? null : (byte[])reader[3],
                        Description = reader.GetString(4),
                        Doctor_Name = reader.GetString(5)
                    };
                }
            }
        }
        dbHelper.CloseConnection();
        return application;
    }

    public void UpdateApplication(Application application)
    {
        string query = @"UPDATE Application SET FK_IDCardpatient = @FK_IDCardpatient, 
                         FailCard = @FailCard, Picture = @Picture, 
                         Description = @Description, Doctor_Name = @Doctor_Name WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@FK_IDCardpatient", application.FK_IDCardpatient);
            cmd.Parameters.AddWithValue("@FailCard", application.FailCard ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Picture", application.Picture ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Description", application.Description);
            cmd.Parameters.AddWithValue("@Doctor_Name", application.Doctor_Name);
            cmd.Parameters.AddWithValue("@ID", application.ID);
            cmd.ExecuteNonQuery();
        }
        dbHelper.CloseConnection();
    }

    public void DeleteApplication(int id)
    {
        string query = "DELETE FROM Application WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }
        dbHelper.CloseConnection();
    }

    // ========== Accaunt ==========
    public void InsertAccaunt(Accaunt accaunt)
    {
        string query = @"INSERT INTO Accaunt (FK_IDCardpatient, FK_IDRegistration, Photo) 
                         VALUES (@FK_IDCardpatient, @FK_IDRegistration, @Photo) RETURNING ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@FK_IDCardpatient", accaunt.FK_IDCardpatient);
            cmd.Parameters.AddWithValue("@FK_IDRegistration", accaunt.FK_IDRegistration);
            cmd.Parameters.AddWithValue("@Photo", accaunt.Photo ?? (object)DBNull.Value);
            accaunt.ID = Convert.ToInt32(cmd.ExecuteScalar());
        }
        dbHelper.CloseConnection();
    }

    public List<Accaunt> GetAllAccaunts()
    {
        List<Accaunt> accaunts = new List<Accaunt>();
        string query = "SELECT * FROM Accaunt";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        using (NpgsqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                accaunts.Add(new Accaunt
                {
                    ID = reader.GetInt32(0),
                    FK_IDCardpatient = reader.GetInt32(1),
                    FK_IDRegistration = reader.GetInt32(2),
                    Photo = reader.IsDBNull(3) ? null : (byte[])reader[3]
                });
            }
        }
        dbHelper.CloseConnection();
        return accaunts;
    }

    public Accaunt GetAccauntById(int id)
    {
        Accaunt accaunt = null;
        string query = "SELECT * FROM Accaunt WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@ID", id);
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    accaunt = new Accaunt
                    {
                        ID = reader.GetInt32(0),
                        FK_IDCardpatient = reader.GetInt32(1),
                        FK_IDRegistration = reader.GetInt32(2),
                        Photo = reader.IsDBNull(3) ? null : (byte[])reader[3]
                    };
                }
            }
        }
        dbHelper.CloseConnection();
        return accaunt;
    }

    public void UpdateAccaunt(Accaunt accaunt)
    {
        string query = @"UPDATE Accaunt SET FK_IDCardpatient = @FK_IDCardpatient, 
                         FK_IDRegistration = @FK_IDRegistration, Photo = @Photo WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@FK_IDCardpatient", accaunt.FK_IDCardpatient);
            cmd.Parameters.AddWithValue("@FK_IDRegistration", accaunt.FK_IDRegistration);
            cmd.Parameters.AddWithValue("@Photo", accaunt.Photo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ID", accaunt.ID);
            cmd.ExecuteNonQuery();
        }
        dbHelper.CloseConnection();
    }

    public void DeleteAccaunt(int id)
    {
        string query = "DELETE FROM Accaunt WHERE ID = @ID";
        dbHelper.openConnection();
        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbHelper.getConnection()))
        {
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }
        dbHelper.CloseConnection();
    }
}