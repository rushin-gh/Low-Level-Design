using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    internal class DecoratorPattern
    {
    }
}

/*
 Intent: Add responsibilities/behaviour to an object dynamically without modifying its class or using inheritance.
*/

public interface IHealthInsurance
{
    public string GetDesc();

    public int GetPrem();
}

public class BasicHealthInsurance : IHealthInsurance
{
    public string GetDesc() => "Basic Health Insurance";

    public int GetPrem() => 1000;
}

public class HealthInsuranceDecorator : IHealthInsurance
{
    public IHealthInsurance _healthInsurance;

    public HealthInsuranceDecorator(IHealthInsurance healthInsurance)
    {
        _healthInsurance = healthInsurance;
    }

    public virtual string GetDesc() => _healthInsurance.GetDesc();
    public virtual int GetPrem() => _healthInsurance.GetPrem();
}


public class AccidentalAddOn : HealthInsuranceDecorator
{
    public AccidentalAddOn(IHealthInsurance health) : base(health) { }

    public override string GetDesc() => _healthInsurance.GetDesc() + " + Accidental Cover";
    public override int GetPrem() => _healthInsurance.GetPrem() + 200;
}

public class CriticalIllness : HealthInsuranceDecorator
{
    public CriticalIllness(IHealthInsurance health) : base(health) { }

    public override string GetDesc() => _healthInsurance.GetDesc() + " + Critical Illness Cover";
    public override int GetPrem() => _healthInsurance.GetPrem() + 50;
}

public class MaternityAddOn : HealthInsuranceDecorator
{
    public MaternityAddOn(IHealthInsurance insurance) : base(insurance) { }

    public override string GetDesc() => _healthInsurance.GetDesc() + " + Maternity Cover";
    public override int GetPrem() => _healthInsurance.GetPrem() + 2500;
}

/*
    USAGE

    private static void Main(string[] args)
    {
        IHealthInsurance policy = new BasicHealthInsurance();
        policy = new AccidentalAddOn(policy);
        policy = new CriticalIllness(policy);

        Console.WriteLine(policy.GetPrem());
    }
 
Without Decorator you'd need a subclass for every combination — 
BasicWithAccidental, BasicWithAccidentalAndMaternity, BasicWithEverything — which explodes quickly.
 
 */