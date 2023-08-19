namespace Task_5.Tables
{
    public class City
    {
        public int cityId { get; set; }
        public string cityName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
