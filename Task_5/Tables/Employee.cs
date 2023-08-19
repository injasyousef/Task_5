namespace Task_5.Tables
{
    public class Employee
    {
        public int empId { get; set; }
        public string empName { get; set; }
        public int age { get; set; }
        public double salary { get; set; }
        public int cityId { get; set; }
        public City city { get; set; }
        public ICollection<Emp_Trans_Sal> Transactions { get; set; }
    }
}
