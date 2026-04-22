// Clients shouldn't be forced to depend on interfaces they don't use
namespace SOLID
{
    namespace InterfaceSegregationPrinciple
    {
        namespace Bad_Example
        {
            // Fat interface — forces all insurance types to implement everything
            public interface IInsuranceService
            {
                void GetDiscountByAge();      // Only Health & Term need this
                void ProcessClaim();          // Only Health & Auto need this
                void GetRoadsideAssistance(); // Only Auto needs this
            }

            public class HealthInsurance : IInsuranceService
            {
                public void GetDiscountByAge() { /* Has implementation */ }
                public void ProcessClaim() { /* Has implementation */ }
                public void GetRoadsideAssistance()
                {
                    throw new NotImplementedException(); // ❌ Forced to implement
                }
            }

            public class TermInsurance : IInsuranceService
            {
                public void GetDiscountByAge() { /* Has implementation */ }
                public void ProcessClaim() { /* Has implementation */ }
                public void GetRoadsideAssistance()
                {
                    throw new NotImplementedException(); // ❌ Forced to implement
                }
            }

            public class AutoInsurance : IInsuranceService
            {
                public void GetDiscountByAge()
                {
                    throw new NotImplementedException(); // ❌ Forced to implement
                }
                public void ProcessClaim() { /* Has implementation */ }
                public void GetRoadsideAssistance() { /* Has implementation */ }
            }
        }

        namespace Good_Example
        {
            // Segregated interfaces — each client takes only what it needs
            public interface IDiscountable
            {
                void GetDiscountByAge();
            }

            public interface IClaimable
            {
                void ProcessClaim();
            }

            public interface IRoadsideAssistable
            {
                void GetRoadsideAssistance();
            }

            public class HealthInsurance : IDiscountable, IClaimable
            {
                public void GetDiscountByAge() { /* Has implementation */ }
                public void ProcessClaim() { /* Has implementation */ }
            }

            public class TermInsurance : IDiscountable
            {
                public void GetDiscountByAge() { /* Has implementation */ }
            }

            public class AutoInsurance : IClaimable, IRoadsideAssistable
            {
                public void ProcessClaim() { /* Has implementation */ }
                public void GetRoadsideAssistance() { /* Has implementation */ }
            }
        }
    }
}