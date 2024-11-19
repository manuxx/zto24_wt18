using System;

namespace Training.DomainClasses
{
    public class Pet : IEquatable<Pet>
    {
        public bool Equals(Pet other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return name == other.name;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Pet)obj);
        }

        public override int GetHashCode()
        {
            return (name != null ? name.GetHashCode() : 0);
        }

        public static bool operator ==(Pet left, Pet right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Pet left, Pet right)
        {
            return !Equals(left, right);
        }

        public Sex sex;
        public string name { get; set; }
        public int yearOfBirth { get; set; }
        public float price { get; set; }
        public Species species { get; set; }

        public static Criteria<Pet> IsASpeciesOf(Species species)
        {
            return new SpeciesCriteria(species);
        }

        public static Criteria<Pet> IsFemale()
        {
            return new SexCriteria(Sex.Female);
        }

        public static Criteria<Pet> IsBornAfter(int year)
        {
            return new BirthAfterCriteria(year);
        }
    }

    public class BirthAfterCriteria : Criteria<Pet>
    {

        private readonly int _year;

        public BirthAfterCriteria(int year)
        {
            _year = year;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.yearOfBirth > _year;
        }
    }

    public class SexCriteria : Criteria<Pet>
    {

        private readonly Sex _sex;
        public SexCriteria(Sex female)
        {
            _sex = female;
        }
        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.sex == _sex;
        }
    }

    public class SpeciesCriteria : Criteria<Pet>
    {
        private Species _species;

        public SpeciesCriteria(Species species)
        {
            _species = species;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.species == _species;
        }
    }
}