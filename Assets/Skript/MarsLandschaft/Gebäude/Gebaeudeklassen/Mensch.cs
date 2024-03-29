using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mensch 
{
    public int anreisegebuehr = 20;
    public string geburtstag;
    public string name;
    public string aufgabe;
    public int containerNummer;
    public static int menschenZaehler=1;//f�r spezielle Namen
    public static bool ersterMensch = false;

    public int projektForschungsstationsNummer;
    public string projektForschungsMerkmal;
    public int projektForschungsStufe;

    public int feldNummer;
    public int weidenNummer;
    public int stationsNummer;

    public Mensch(string aufg, int nummer)
    {
        aufgabe = aufg;
        geburtstag=randomGeburtstag();
        name = randomName();
        containerNummer = nummer;
        Testing.menschen.Add(this);
        menschenZaehler++;
    }

    private string randomName()
    {
        string vorname = "";
        string nachname = "";
        if (menschenZaehler == 6)
        {
             vorname = "Marcel";
            nachname = "Lehmann";
            geburtstag = "6.6.1966";
        }else if (menschenZaehler == 13)
        {
            vorname = "Maximilian";
            nachname = "Sterz";
            geburtstag = "13.3.1992";
        }else if (menschenZaehler == 9)
        {
            vorname = "Annemarie";
            nachname = "Fromm";
            geburtstag = "22.4.1999";
        }
        else
        {
            string[] vornamen = new string[] { "Marie", "Sophie", "Emilia", "Maria", "Noah", "Emma", "Felix", "Anton", "Charlotte", "Jakob", "Leon", "Mila", "Paul", "Marie", "Mia", "Lina", "Alexander", "Emil", "Ella", "Jonas", "Maximilian", "Theo", "Ben", "Milan", "Anna", "Leonie", "Elias", "Moritz", "Liam", "Maximilian", "Luisa", "Clara", "Hannah", "Jonathan", "Leo", "Lara", "Paula", "Paul", "Lea", "Lena", "Max", "Ida", "Katharina", "Emily", "Lukas", "Elias", "Sophia", "Sophie", "Levi", "Leni", "Lia", "Luca", "Samuel", "Johanna", "Johann", "Johanna", "David", "Oskar", "Tom", "Mira", "Julian", "Sara", "Mats", "Toni", "Mina", "Sofia", "Henry", "Elisabeth", "Finn", "Louis", "Luise", "Elisa", "Marlene", "Henri", "Nora", "Aaron", "Adam", "Jan", "Leonard", "Antonia", "Ava", "Liya", "Emilio", "Tilda", "Carlo", "Jonah", "Linus", "Matteo", "Emil", "Paulina", "Thea", "Luis", "Anton", "Maya", "Nele", "Alexander", "Benjamin", "Niklas", "Tim", "Sophia", "Bruno", "Julius", "Emilia", "Amelie", "Juna", "Lotta", "Gabriel", "Mika", "Milo", "Hanna", "Karl", "Malik", "Anna", "Elisa", "Eva", "Frida", "Louisa", "Mateo", "Vincent", "Jakob", "Michael", "Charlotte", "Frieda", "Klara", "Luna", "Daniel", "Leonardo", "Lian", "Miran", "Gabriel", "Carlotta" };
            var rand = new System.Random();
            vorname = vornamen[rand.Next(0, vornamen.Length - 1)];

            string[] nachnamen = new string[] { "Abbey", "Abram", "Acker", "Adair", "Adam", "Adams", "Adamson", "Addison", "Adkins", "Aiken", "Akerman", "Akers", "Albert", "Albertson", "Albinson", "Alexander", "Alfredson", "Alger", "Alvin", "Anderson", "Andrews", "Ansel", "Appleton", "Archer", "Armistead", "Arnold", "Arrington", "Arthur", "Arthurson", "Ashworth", "Atkins", "Atkinson", "Austin", "Avery", "Babcock", "Bagley", "Bailey", "Baker", "Baldwin", "Bancroft", "Banister", "Banks", "Banner", "Barber", "Barker", "Barlow", "Bass", "Bates", "Baxter", "Beake", "Beasley", "Beck", "Beckett", "Beckham", "Bell", "Bellamy", "Bennett", "Benson", "Bentley", "Benton", "Bernard", "Berry", "Beverley", "Bird", "Black", "Blackburn", "Bond", "Bonham", "Bourke", "Braddock", "Bradford", "Bradley", "Brand", "Brandon", "Breckenridge", "Brewer", "Brewster", "Brigham", "Bristol", "Brook", "Brooke", "Brown", "Bryson", "Buckley", "Bullard", "Bullock", "Burnham", "Burrell", "Burton", "Bush", "Byrd", "Cantrell", "Carl", "Carlisle", "Carlyle", "Carman", "Carpenter", "Carter", "Cartwright", "Carver", "Caulfield", "Causer", "Chadwick", "Chamberlain", "Chance", "Chandler", "Chapman", "Chase", "Cheshire", "Chlarke", "Church", "Clark", "Clarkson", "Clay", "Clayton", "Clemens", "Clifford", "Clifton", "Cline", "Clinton", "Close", "Coburn", "Coke", "Colbert", "Cole", "Coleman", "Colton", "Comstock", "Constable", "Cook", "Cooke", "Cookson", "Cooper", "Corey", "Cornell", "Courtney", "Cox", "Crawford", "Crewe", "Croft", "Cropper", "Cross", "Crouch", "Cummins", "Curtis", "Dalton", "Danell", "Daniel", "Darby", "Darrell", "Darwin", "Daubney", "David", "Davidson", "Davies", "Davis", "Dawson", "Day", "Dean", "Deering", "Delaney", "Denman", "Dennel", "Dennell", "Derby", "Derrick", "Devin", "Devine", "Dickens", "Dickenson", "Dickinson", "Dickman", "Donalds", "Donaldson", "Downer", "Draper", "Dudley", "Duke", "Dunn", "Durand", "Durant", "Dustin", "Dwight", "Dyer", "Dyson", "Eason", "Easton", "Eaton", "Edgar", "Edison", "Edwards", "Edwarson", "Eliot", "Eliott", "Elliott", "Ellis", "Ellison", "Emerson", "Emmett", "Endicott", "Ericson", "Evanson", "Evelyn", "Everett", "Fairbarn", "Fairburn", "Fairchild", "Fay", "Fields", "Fisher", "Fleming", "Fletcher", "Ford", "Forest", "Forester", "Forrest", "Foss", "Foster", "Fox", "Frank", "Franklin", "Freeman", "Frost", "Fry", "Fuller", "Gardener", "Gardner", "Garfield", "Garland", "Garner", "Garnet", "Garrard", "Garrett", "Garry", "Geary", "Gibbs", "Gibson", "Gilbert", "Giles", "Gilliam", "Gladwin", "Glover", "Goddard", "Goode", "Goodwin", "Granger", "Grant", "Gray", "Green", "Greene", "Griffin", "Gully", "Hackett", "Hadaway", "Haden", "Haggard", "Haight", "Hailey", "Haley", "Hall", "Hallman", "Hamilton", "Hamm", "Hancock", "Hanley", "Hanson", "Hardy", "Harford", "Hargrave", "Harlan", "Harley", "Harlow", "Harman", "Harper", "Hart", "Harvey", "Hathaway", "Hawk", "Hawking", "Hawkins", "Hayes", "Haywood", "Heath", "Hedley", "Henderson", "Henry", "Henson", "Herbert", "Herman", "Hewitt", "Hibbert", "Hicks", "Hightower", "Hill", "Hilton", "Hobbes", "Hobbs", "Hobson", "Hodges", "Hodson", "Holmes", "Holt", "Hooker", "Hooper", "Hope", "Hopper", "Horn", "Horne", "Horton", "House", "Howard", "Howe", "Hudson", "Hughes", "Hull", "Hume", "Hunt", "Hunter", "Hurst", "Huxley", "Huxtable", "Ingram", "Irvin", "Irvine", "Irving", "Irwin", "Ivers", "Jack", "Jackson", "Jacobs", "Jacobson", "James", "Jameson", "Jamison", "Janson", "Jardine", "Jarrett", "Jarvis", "Jefferson", "Jeffries", "Jekyll", "Jenkins", "Jepson", "Jerome", "Jinks", "Johns", "Johnson", "Jones", "Jordan", "Judd", "Kay", "Keen", "Kelsey", "Kemp", "Kendall", "Kendrick", "Kerry", "Kersey", "Key", "Kidd", "King", "Kingsley", "Kingston", "Kinsley", "Kipling", "Kirby", "Knight", "Lacy", "Lamar", "Landon", "Lane", "Langley", "Larson", "Lawson", "Leach", "Leavitt", "Lee", "Leigh", "Leon", "Levitt", "Lewin", "Lincoln", "Lindsay", "Linton", "Little", "Loman", "London", "Long", "Lovell", "Lowell", "Lowry", "Lucas", "Lyndon", "Lynn", "Lyon", "Madison", "Mann", "Mark", "Marley", "Marlow", "Marshall", "Martel", "Martin", "Mason", "Massey", "Masters", "Masterson", "Mathers", "Matthews", "May", "Mayes", "Maynard", "Meadows", "Mercer", "Merchant", "Merrill", "Merritt", "Michael", "Michaels", "Michaelson", "Mills", "Mitchell", "Moore", "Morris", "Myers", "Nathanson", "Neville", "Newell", "Newman", "Newport", "Nichols", "Nicholson", "Nielson", "Niles", "Nixon", "Noel", "Norman", "Oakley", "Odell", "Ogden", "Oliver", "Oliverson", "Olson", "Osborne", "Otis", "Overton", "Page", "Parker", "Parsons", "Patrick", "Patton", "Paulson", "Payne", "Pearce", "Pearson", "Penny", "Perkins", "Perry", "Peters", "Peyton", "Philips", "Pickering", "Pierce", "Pierson", "Piper", "Pitts", "Platt", "Poole", "Pope", "Porcher", "Porter", "Potter", "Pound", "Powers", "Prescott", "Pressley", "Preston", "Pryor", "Purcell", "Putnam", "Quigley", "Quincy", "Radcliff", "Raines", "Ramsey", "Randall", "Ray", "Reed", "Reeve", "Rey", "Reynolds", "Rhodes", "Richards", "Rider", "Ridley", "Roach", "Robbins", "Robert", "Roberts", "Robertson", "Rogers", "Rogerson", "Rollins", "Roscoe", "Ross", "Rowe", "Rowland", "Royce", "Roydon", "Rush", "Russell", "Ryder", "Sadler", "Salvage", "Sampson", "Samson", "Samuel", "Sanders", "Sandford", "Sanford", "Sargent", "Savage", "Sawyer", "Scarlett", "Seaver", "Sergeant", "Shelby", "Shine", "Simmons", "Simon", "Simons", "Simonson", "Simpkin", "Simpson", "Sims", "Sinclair", "Skinner", "Slater", "Smalls", "Smedley", "Smith", "Snelling", "Snider", "Sniders", "Snyder", "Spalding", "Sparks", "Spear", "Spears", "Spence", "Spencer", "Spooner", "Spurling", "Stacy", "Stafford", "Stamp", "Stanton", "Statham", "Steed", "Steele", "Stephens", "Stephenson", "Stern", "Stone", "Strange", "Strickland", "Stringer", "Stroud", "Strudwick", "Styles", "Summerfield", "Summers", "Sumner", "Sutton", "Sydney", "Tailor", "Tanner", "Tash", "Tasker", "Tate", "Taylor", "Teel", "Tennyson", "Terrell", "Terry", "Thacker", "Thatcher", "Thomas", "Thompson", "Thorne", "Thorpe", "Timberlake", "Townsend", "Tracy", "Travers", "Travis", "Trent", "Trevis", "Truman", "Tucker", "Tuft", "Turnbull", "Turner", "Tyler", "Tyrell", "Tyson", "Underhill", "Underwood", "Upton", "Vance", "Vernon", "Victor", "Vincent", "Walker", "Wallace", "Walsh", "Walton", "Warner", "Warren", "Warwick", "Washington", "Waters", "Wayne", "Weaver", "Webb", "Webster", "Wells", "Wembley", "West", "Wheeler", "Whitaker", "White", "Whitney", "Whittle", "Wickham", "Wilcox", "Wilkie", "Wilkins", "Willard", "Williams", "Williamson", "Willis", "Wilson", "Winchester", "Winfield", "Winship", "Winslow", "Winston", "Winthrop", "Witherspoon", "Wolf", "Wolfe", "Womack", "Woodcock", "Woodham", "Woodward", "Wortham", "Wray", "Wright", "Wyatt", "Wyndham", "Yates", "York", "Young" };
            nachname = nachnamen[rand.Next(0, nachnamen.Length - 1)];
        }
        if (menschenZaehler == 1)
        {
            Debug.Log(vorname + " " + nachname);
        }
        return vorname +" "+nachname;
    }

    private string randomGeburtstag()
    {        
        var rand = new System.Random();
        string bday = rand.Next(1, 28) + "." + rand.Next(1, 12) +"."+ rand.Next(1970, 2003);
        return bday;
    }
}
