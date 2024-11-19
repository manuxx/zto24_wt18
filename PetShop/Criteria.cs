using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.DomainClasses;

namespace PetShop
{
    public class Negation<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _criteria;

        public Negation(Criteria<TItem> criteria)
        {
            _criteria = criteria;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return !_criteria.IsSatisfiedBy(item);
        }
    }

    public class AgeCriteria : Criteria<Pet>
    {
        private readonly int _year;
        private readonly Order _order;

        public enum Order
        {
            Older,
            Younger
        }

        public AgeCriteria(int year, Order order = Order.Older)
        {
            _year = year;
            _order = order;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            if (_order == Order.Older)
            {
                return pet.yearOfBirth > _year;
            }
            else
            {
                return pet.yearOfBirth < _year;
            }
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
    }

    public abstract class BinaryCriteria<T> : Criteria<T>
    {
        protected Criteria<T> _criterium1;
        protected Criteria<T> _criterium2;

        public BinaryCriteria(Criteria<T> criterium1, Criteria<T> criterium2)
        {
            _criterium1 = criterium1;
            _criterium2 = criterium2;
        }

        public abstract bool IsSatisfiedBy(T pet);
    }

    public class OrCriteria<T> : BinaryCriteria<T>
    {
        public OrCriteria(Criteria<T> criterium1, Criteria<T> criterium2) : base(criterium1, criterium2)
        {
        }

        public override bool IsSatisfiedBy(T pet)
        {
            return _criterium1.IsSatisfiedBy(pet) || _criterium2.IsSatisfiedBy(pet);
        }
    }

    public class AndCriteria<T> : BinaryCriteria<T>
    {
        public AndCriteria(Criteria<T> criterium1, Criteria<T> criterium2) : base(criterium1, criterium2)
        {
        }

        public override bool IsSatisfiedBy(T pet)
        {
            return _criterium1.IsSatisfiedBy(pet) && _criterium2.IsSatisfiedBy(pet);
        }
    }


    public static class CriteriaExtension
    {
        public static Criteria<T> And<T>(this Criteria<T> first, Criteria<T> second)
        {
            return new AndCriteria<T>(first, second);
        }

        public static Criteria<T> Or<T>(this Criteria<T> first, Criteria<T> second)
        {
            return new OrCriteria<T>(first, second);
        }
    }
}
