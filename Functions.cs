namespace PartyReservationFilterModule
{
    using System;
    using System.Text;
    public static class Functions
    {
        public static readonly Func<Person[], Func<Person, bool>, string> GetNonFilteredGuests = (names, func) =>
                               {
                                   StringBuilder result = new StringBuilder();
                                   foreach (Person person in names)
                                   {
                                       if (func(person))
                                       {
                                           continue;
                                       }

                                       result.Append(person.Name);
                                       result.Append(" ");
                                   }

                                   return result.ToString();
                               };

        public static readonly Action<Person[], string, Func<string, string, bool>, Filter> ManipulateFilters = (names, toMatch, func, filter) =>
                               {
                                   for (int currElement = 0; currElement < names.Length; currElement++)
                                   {
                                       Person currPerson = names[currElement];

                                       if (func(currPerson.Name, toMatch))
                                       {
                                           currPerson.SetFilter(filter);
                                       }
                                   }
                               };

        public static readonly Func<string, string, bool> StartsWith = (f, s)
                                                => f.Substring(0, s.Length) == s;

        public static readonly Func<string, string, bool> EndsWith = (f, s)
                                                => f.Substring(f.Length - s.Length, s.Length) == s;

        public static readonly Func<string, string, bool> HasLenght = (f, s)
                                                => f.Length == s.Length;

        public static readonly Func<string, string, bool> Contains = (f, s)
                                                => f.Contains(s);
    }
}
