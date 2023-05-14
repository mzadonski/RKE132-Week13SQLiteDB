using System.Data.SQLite;

ReadDate(CreatConnection());
//InsertCustomer(CreatConnection());
//RemoveCustomer(CreatConnection());
FindCustomer();

static SQLiteConnection CreatConnection() 
{

    SQLiteConnection connection = new SQLiteConnection("Data Source=mydb.db; Version = 3; New = True; Compress = True;");

    try
    {
        connection.Open();
        Console.WriteLine("DB found.");
    }
    catch
    {
        Console.WriteLine("DB not found");
    }

    return connection;
}

static void ReadDate(SQLiteConnection myConnection)
{
    Console.Clear();
    SQLiteDataReader reader;
    SQLiteCommand command;

    command = myConnection.CreateCommand();
    command.CommandText = "SELECT rowid, * FROM customer";

    reader = command.ExecuteReader();

    while (reader.Read())
    {
        string readerRowId = reader.GetString(0);
        string readerStringFirstName = reader.GetString(1);
        string readerStringLastName = reader.GetString(2);
        string readerStringDoB = reader.GetString(3);

        Console.WriteLine($"{readerRowId} {readerStringFirstName} {readerStringLastName} DoB {readerStringDoB}");
    }
    myConnection.Close();
}

static void InsertCustomer(SQLiteConnection myConnection)
{
    SQLiteCommand command;
    string FName, LName, dob;
    Console.WriteLine("enter");
    FName = Console.ReadLine();
    LName = Console.ReadLine();
    dob = Console.ReadLine();

    command = myConnection.CreateCommand();
    command.CommandText = $"INSERT INTO customer(firstName, lastName, dateOfBirth) VALUES ('{FName}', '{LName}', '{dob}')";
    int rowInserted = command.ExecuteNonQuery();
    Console.WriteLine($"Row inserted {rowInserted}");

    ReadDate(myConnection);
}
static void RemoveCustomer(SQLiteConnection myConnection)
{
    SQLiteCommand command;

    string idToDelete;
    Console.WriteLine("Id");
    idToDelete = Console.ReadLine();

    command = myConnection.CreateCommand();
    command.CommandText = $"DELETE FROM customer WHERE rowid = {idToDelete}";
    int rowRemovedd = command.ExecuteNonQuery();

    ReadDate(myConnection);
}
 static void FindCustomer()
{

}