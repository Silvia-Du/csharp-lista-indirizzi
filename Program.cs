// See https://aka.ms/new-console-template for more information
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

//istanziare l'oggetto

//salvare gli indirizzi nella mia lista

//capire eccezioni possibili

//generare eccezioni personalizzate

//gestire eccezioni
public class Address
{

    string Name { get; }   
    string Surname { get; }
    string Street { get; }
    string City { get; }
    string Province { get; }
    int ZIP { get; }

    public Address(string name, string surname, string street, string city, string province, int zip)
    {
        Name = name;
        Surname = surname;
        Street = street;
        City = city;
        Province = province;
        ZIP = zip;
    }


}

