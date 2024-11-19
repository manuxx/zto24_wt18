namespace Training.DomainClasses.Criteria
{
    public class Conjuction<TItem> : BinaryCriteria<TItem>
    {
        public Conjuction(Criteria<TItem> leftCriteria, Criteria<TItem> rightCriteria) : base(leftCriteria, rightCriteria)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _leftCriteria.IsSatisfiedBy(item) && _rightCriteria.IsSatisfiedBy(item);
        }
    }

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

    public abstract class BinaryCriteria<TItem> : Criteria<TItem>
    {
        protected Criteria<TItem> _leftCriteria;
        protected Criteria<TItem> _rightCriteria;

        public BinaryCriteria(Criteria<TItem> leftCriteria, Criteria<TItem> rightCriteria)
        {
            _leftCriteria = leftCriteria;
            _rightCriteria = rightCriteria;
        }

        public abstract bool IsSatisfiedBy(TItem item);
    }

    public class Alternative<TItem> : BinaryCriteria<TItem>
    {
        public Alternative(Criteria<TItem> leftCriteria, Criteria<TItem> rightCriteria) : base(leftCriteria,
            rightCriteria)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _leftCriteria.IsSatisfiedBy(item) || _rightCriteria.IsSatisfiedBy(item);
        }
    }
}