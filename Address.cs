// See https://aka.ms/new-console-template for more information
//generare eccezioni personalizzate

//gestire eccezioni
public class Address
{

    string Name { get; }   
    string Surname { get; }
    public string SecondSurname { get; set; }
    string Street { get; set; }
    string City { get; set;  }
    string Province { get; set; }
    string ZIP { get; set; }

    public Address(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }

    public void CompleteData(string street, string city,string province, string zip)
    {
        try
        {
            Street = street;
            City = city;
            Province = province;
            ZIP = zip;
        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static void AddressPrinter(Address address)
    {
        Console.WriteLine("---------");
        Console.Write($"Nome: {address.Name}, Cognome: {address.Surname}; \n");
        if(address.SecondSurname != "")
        {
            Console.Write($"secondo cognome: {address.SecondSurname};");
        }
        Console.WriteLine($"via: {address.Street}; città:{address.City}\nProvincia: {address.Province}, {address.ZIP}");
        Console.WriteLine("---------");

    }




}

