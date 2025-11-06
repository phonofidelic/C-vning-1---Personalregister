namespace EmployeeRegistry
{
    public class AutoIncrement
    {
        private int Id;
        public AutoIncrement()
        {
            Id = 1;
        }
        public AutoIncrement(int initialValue)
        {
            Id = initialValue;
        }
        public int GenerateId()
        {
            return Id++;
        }
    }
}