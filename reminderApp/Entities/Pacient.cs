using System;

namespace reminderApp.Entities
    {
    public class Pacient
        {
        #region Properties

        public int PacientId
            {
            get;
            set;
            }
        public static string Name
            {
            get;
            set;
            }
        public string Surname
            {
            get;
            set;
            }
        public string SecondName
            {
            get;
            set;
            }
        public string Address
            {
            get;
            set;
            }
        public int Age
            {
            get;
            set;
            }
        public DateTime DateOfBirth
            {
            get;
            set;
            }

        #endregion

        #region Constructor

        public Pacient(int pacientId, string name, string surname, string secondName, string address, int age, DateTime dateOfBirth)
            {
            PacientId = pacientId;
            Name = name;
            Surname = surname;
            SecondName = secondName;
            Address = address;
            Age = age;
            DateOfBirth = dateOfBirth;
            }
        #endregion
        }
    }