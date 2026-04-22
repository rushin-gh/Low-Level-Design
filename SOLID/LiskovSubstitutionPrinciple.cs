// Subtypes must be replaceable for their base types without breaking behavior.
namespace SOLID
{
    namespace LiskovSubstitutionPrinciple
    {
        namespace Bad_Example
        {
            public class DiscountService
            {
                public virtual void GetDiscountByAge()
                {

                }
            }

            public class HealthInsurance : DiscountService
            {
                public override void GetDiscountByAge()
                {
                    // Has some implementation
                }
            }

            public class TermInsurance : DiscountService
            {
                public override void GetDiscountByAge()
                {
                    // Has some implementation
                }
            }

            public class AutoInsurance : DiscountService
            {
                public override void GetDiscountByAge()
                {
                    throw new NotImplementedException();
                }
            }
        }

        namespace Good_Example
        {
            public interface IDiscount
            {
                void GetDiscountByAge();
            }


            public class DiscountService
            {

            }

            public class HealthInsurance : DiscountService, IDiscount
            {
                public void GetDiscountByAge()
                {
                    // Has some implementation
                }
            }

            public class TermInsurance : DiscountService, IDiscount
            {
                public void GetDiscountByAge()
                {
                    // Has some implementation
                }
            }

            public class AutoInsurance : DiscountService
            {
                
            }
        }
    }
}
