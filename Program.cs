using System.Reflection.Metadata;

namespace _321_Contact {
    internal class Program {

        struct Contact {
            public string firstName;
            public string lastName;
            public string address;
            public string city;
            public string state;
            public uint    zipCode;
            public string title;
        }

        static void Main(string[] args) {

            StreamReader infile = new StreamReader("C:\\Users\\regl8\\Downloads\\contacts.dat");
            string[] records;
            string data = "";
            Contact[] members;
            char continueSearch = 'y';
            string userInput = "";
            bool parsingSuccessful = false;

            //LOOP INFILE UNTIL ALL IS COPIED TO DATA
            while (infile.EndOfStream == false) {
                data = infile.ReadLine();

            }

            //CLOSE FILE
            infile.Close();

            //SPLIT INFORMATION IN DATA BY RECORD SEPARATOR, THEN STORE IN RECORDS
            records = data.Split((char)30);

            members = new Contact[records.Length - 1];

            for (int index = 0; index < members.Length; index += 1) {

                //SPLIT INFO OF MEMBERS BY UNIT SEPARATOR
                string[] placement = records[index].Split((char)31);

                //PLACE INFORMATION IN EACH TYPE (FIRST NAME, LAST NAME, ADDRESS, CITY, STATE, ZIP CODE, TITLE)
                members[index].firstName = placement[0];
                members[index].lastName = placement[1];
                members[index].address = placement[2];
                members[index].city = placement[3];
                members[index].state = placement[4];
                members[index].zipCode = uint.Parse(placement[5]);
                members[index].title = placement[6];
            }//END FOR LOOP

            //WHILE LOOP TO KEEP THE SEARCH GOING
            while (continueSearch != 'n') {

                //SET NO MATCH TO TRUE AND CLEAR CONSOLE
                bool noMatch = true;

                //GET USER INPUT FOR NAME SEARCH
                userInput = Input("Search Name: ");

                for (int index = 0; index < members.Length; index += 1) {

                    //IF USER INPUT MATCHES TO FIRST NAME OR LAST NAME
                    if (members[index].firstName.Contains(userInput, StringComparison.OrdinalIgnoreCase) || members[index].lastName.Contains(userInput, StringComparison.OrdinalIgnoreCase)) {

                        //DISPLAY TITLE, NAME, AND ADDRESS.  THEN, SET NO MATCH TO FALSE
                        Console.WriteLine($"\nName     :{members[index].title} {members[index].firstName} {members[index].lastName}");
                        Console.WriteLine($"Address  :{members[index].address}");
                        Console.WriteLine($"          {members[index].city}, {members[index].state}, {members[index].zipCode}");

                        noMatch = false;
                    }//END IF
                }//END FOR

                //IF NO DATA WAS FOUND WITH USER INPUT
                if (noMatch == true) {

                    //PRINT NO DATA FOUND
                    Console.WriteLine("\nNo search results found.");
                }

                //ASK IF USER WOULD LIKE TO SEARCH AGAIN
                do {
                    userInput = Input("\nSearch again? (y/n): ");
                    parsingSuccessful = char.TryParse(userInput, out continueSearch);
                } while (parsingSuccessful == false && continueSearch == 'y' || parsingSuccessful == false && continueSearch == 'n');

                Console.Clear();
            }//END WHILE
        }//end main

        static string Input(string prompt) {
            Console.Write(prompt);
            return Console.ReadLine();
        }//END INPUT
    }//end class
}//namespace