namespace PartyReservationFilterModule
{
    using System;
    using System.Linq;

    public class PartyReservationFilterModule
    {
        public static void Main()
        {
            Person[] names = SplitString(Console.ReadLine(), ' ').Select(n => new Person(n)).ToArray();

            string inputLine = Console.ReadLine();
            while (inputLine != "Print")
            {
                string[] commandInfo = SplitString(inputLine, ';');

                string filterAction = commandInfo[0];
                string personNameInfo = commandInfo[1];
                string toMatch = string.Empty;

                Filter filter = filterAction == "Add filter" ? Filter.AddFilter : Filter.RemoveFilter;
                Func<string, string, bool> funcToUse = default(Func<string, string, bool>);

                if (personNameInfo == "Starts with")
                {
                    toMatch = commandInfo[2];

                    funcToUse = Functions.StartsWith;
                }
                else if (personNameInfo == "Ends with")
                {
                    toMatch = commandInfo[2];

                    funcToUse = Functions.EndsWith;
                }
                else if (personNameInfo == "Length")
                {
                    toMatch = new string(' ', int.Parse(commandInfo[2]));

                    funcToUse = Functions.HasLenght;
                }
                else if (personNameInfo == "Contains")
                {
                    toMatch = commandInfo[2];

                    funcToUse = Functions.Contains;
                }

                Functions.ManipulateFilters(names, toMatch, funcToUse, filter);

                inputLine = Console.ReadLine();
            }

            string result = Functions.GetNonFilteredGuests(names, p => p.HasFilter);
            Console.WriteLine(result);
        }

        public static string[] SplitString(string toSplit, char toSplitBy)
        {
            return toSplit.Split(new[] { toSplitBy }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
