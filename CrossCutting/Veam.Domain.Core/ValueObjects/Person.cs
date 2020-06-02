using System;
using Veam.Domain.Core.ValueObjects;

namespace Veam.Domain.Core.ValueObjects
{
    /// <summary>
    /// person Value Object
    /// </summary>
    public class Person : ValueObject<Person>
    {
        public Person(string firstName, string lastName, string middleName, string nickName, string gender, string salutation)
        {
            this.firstName = firstName   /*?? throw new ArgumentNullException(nameof(firstName)) */;
            this.lastName = lastName     /*?? throw new ArgumentNullException(nameof(lastName))  */;
            this.middleName = middleName /*?? throw new ArgumentNullException(nameof(middleName))*/;
            this.nickName = nickName     /*?? throw new ArgumentNullException(nameof(nickName))  */;
            this.gender = gender         /*?? throw new ArgumentNullException(nameof(gender))    */;
            this.salutation = salutation /*?? throw new ArgumentNullException(nameof(salutation))*/;
        }

        public string firstName { get; protected set; }
        public string lastName { get; protected set; }
        public string middleName { get; protected set; }
        public string nickName { get; protected set; }
        public string gender { get; protected set; }
        public string salutation { get; protected set; }

        public override string ToString() => $"{salutation}. {firstName} {lastName} ";
       
    }

    //public enum Salutation
    //{
    //    Mr,
    //    Mrs,
    //}

    //public enum Gender
    //{
    //    Male,
    //    Female
    //}
   
   
}
