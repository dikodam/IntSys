namespace ConsoleApp2
{
    class Student
    {
        protected int EineMatrikelnummer;

        public int Matrikelnummer
        {
            get => EineMatrikelnummer;
            set
            {
                if (value.ToString().Length != 6)
                {
                    StudentEvent?.Invoke();
                }
                else
                {
                    EineMatrikelnummer = value;
                }
            }
        }

        public event StudentDel StudentEvent;
    }
}
