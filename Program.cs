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


//creo la lista
List<Address> addresses = new List<Address>();

//leggo il file 
//FileStream file = File.Open("./addresses.csv", FileMode.Open);

StreamReader addressFile = File.OpenText("../../../addresses.csv");


//tolgo la prima riga
addressFile.ReadLine();
//Name,Surname,Street,City,Province,ZIP
//while (!File.EndOfStream)
while (!addressFile.EndOfStream)
{
    string line = addressFile.ReadLine();
    string[] rowSplit = line.Split(',');
    string secondSurname = null;
    string province;

    int last = rowSplit.Count() - 1;    
    string[] string2 =  rowSplit[2].Trim().Split(' ');

    // assegno parametri obblig per il costruttore
    string name = rowSplit[0] == "" ? "-" : rowSplit[0];
    string surname = rowSplit[1];

    //creo nuova istanza di address
    Address newAddress = new Address(name , surname);

    //gestione secondo cognome
    if (rowSplit.Count() > 6 && rowSplit[2].Trim().Count() != 2 && string2.Count() == 1)
    {
        secondSurname = rowSplit[2];
    }
    newAddress.SecondSurname = secondSurname != null ? secondSurname : "";


    //gestione altri paramentri
    string street = rowSplit[2] == ""? "-": rowSplit[2];
    string city = rowSplit[3];
    province = rowSplit[last-1].Trim();
    string zip = rowSplit[last].Trim().Count() >5? "invalid": rowSplit[last].Trim();

    newAddress.CompleteData(street, city, province, zip);


    Console.WriteLine(zip);

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




}

