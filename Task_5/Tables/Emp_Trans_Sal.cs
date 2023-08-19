namespace Task_5.Tables
{
    public class Emp_Trans_Sal
    {
        public int emp_trans_salId { get; set; }
        public int empId { get; set;}

        public DateTime salaryDate { get; set; }
        public Employee employee { get; set; }


    }
}
