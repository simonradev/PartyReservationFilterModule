namespace PartyReservationFilterModule
{
    public class Person
    {
        private string name;
        private bool hasFilter;

        public Person(string name)
        {
            this.name = name;
            this.hasFilter = false;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public bool HasFilter
        {
            get { return this.hasFilter; }
        }

        public void SetFilter(Filter filter)
        {
            if (filter == Filter.AddFilter)
            {
                this.hasFilter = true;
            }
            else if (filter == Filter.RemoveFilter)
            {
                this.hasFilter = false;
            }
        }
    }
}
