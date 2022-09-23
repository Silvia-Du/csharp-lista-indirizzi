// See https://aka.ms/new-console-template for more information
using System.IO;
using System.Xml.Linq;

Console.WriteLine("Hello, World!");
/*
     In questo esercizio dovrete leggere un file CSV, che cambia poco da quanto 
     appena visto nel live-coding in classe, e salvare tutti gli indirizzi contenuti 
     al sul interno all’interno di una lista di oggetti istanziati a partire dalla classe Indirizzo.
     Attenzione: gli ultimi 3 indirizzi presentano dei possibili “casi particolari” che possono accadere 
     a questo genere di file: vi chiedo di pensarci e di gestire come meglio crediate queste casistiche.
 * */




StreamReader addressFile = File.OpenText("../../../addresses.csv");
//tolgo la prima riga
addressFile.ReadLine();

//creo la lista
List<Address> addressesCollection = new List<Address>();

while (!addressFile.EndOfStream)
{
    string line = addressFile.ReadLine();
    string[] rowSplit = line.Split(',');
    string secondSurname = null;
    

    int last = rowSplit.Count() - 1;    
    string[] string2 =  rowSplit[2].Trim().Split(' ');

    // assegno parametri obblig per il costruttore
    string name = rowSplit[0] == "" ? "Nome non indicato" : rowSplit[0];
    string surname =rowSplit.Count() > 5? rowSplit[1] : "cognome non indicato";

    //creo nuova istanza di address
    Address newAddress = new Address(name , surname);

    //gestione altri paramentri
    string street = rowSplit.Count() > 4 && rowSplit[2] != "" ? rowSplit[2] : "non indicata";
    string city = rowSplit[last-2];
    string province = rowSplit[last - 1].Trim();
    string zip = rowSplit[last].Trim().Count() > 5 ? "invalid zip" : rowSplit[last].Trim();

    //gestione secondo cognome
    if (rowSplit.Count() > 6 && rowSplit[2].Trim().Count() != 2 && string2.Count() == 1)
    {
        secondSurname = rowSplit[2];
        street = rowSplit[3];

    }
    newAddress.SecondSurname = secondSurname != null ? secondSurname : "";
    //assegno gli altri parametri di Address
    newAddress.CompleteData(street, city, province, zip);

    //stampo gli indirizzi
    addressesCollection.Add(newAddress);

}

foreach (Address address in addressesCollection)
{
    Address.AddressPrinter(address);

}

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

