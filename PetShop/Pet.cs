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
            return new BornAfterCriteria(year);
        }
<<<<<<< HEAD
    }

    internal class SpeciesCriteria : Criteria<Pet>
    {
        private Species _species;

        public SpeciesCriteria(Species species)
        {
            this._species = species;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return item.species == this._species;
        }
    }

    internal class BornAfterCriteria : Criteria<Pet>
    {
        private int yearOfBirth;

        public BornAfterCriteria(int yearOfBirth)
        {
            this.yearOfBirth = yearOfBirth;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return item.yearOfBirth > this.yearOfBirth;
        }
    }

    internal class SexCriteria : Criteria<Pet>
    {
        private Sex _sex;

        public SexCriteria(Sex sex)
        {
            this._sex = sex;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return item.sex == this._sex;
=======

        public class BornAfterCriteria : Criteria<Pet>
        {
            private readonly int _year;

            public BornAfterCriteria(int year)
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

            public SexCriteria(Sex sex)
            {
                _sex = sex;
            }

            public bool IsSatisfiedBy(Pet pet)
            {
                return pet.sex == _sex;
            }
        }

        public class SpeciesCriteria : Criteria<Pet>
        {
            private readonly Species _species;

            public SpeciesCriteria(Species species)
            {
                _species = species;
            }

            public bool IsSatisfiedBy(Pet pet)
            {
                return pet.species == _species;
            }
>>>>>>> cd4d1528bb450a4809c159824fb3696595cf4e15
        }
    }

}