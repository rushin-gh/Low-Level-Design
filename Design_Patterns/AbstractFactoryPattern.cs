using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    public class AbstractFactoryPattern
    {
    }
}

// Family of related products
public interface IButton
{
    void Render();
}

public interface ICheckbox
{
    void Render();
}

public class WinButton : IButton
{
    public void Render()
        => Console.WriteLine("[ Windows Button ]");
}

public class WinCheckbox : ICheckbox
{
    public void Render()
        => Console.WriteLine("[x] Windows Checkbox");
}

public class MacButton : IButton
{
    public void Render()
        => Console.WriteLine("● Mac Button");
}

public class MacCheckbox : ICheckbox
{
    public void Render()
        => Console.WriteLine("☑ Mac Checkbox");
}

public interface IUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

public class WindowsFactory : IUIFactory
{
    public IButton CreateButton() => new WinButton();
    public ICheckbox CreateCheckbox() => new WinCheckbox();
}

public class MacFactory : IUIFactory
{
    public IButton CreateButton() => new MacButton();
    public ICheckbox CreateCheckbox() => new MacCheckbox();
}

/*
    void RenderUI(IUIFactory factory)
    {
        IButton btn = factory.CreateButton();
        ICheckbox chk = factory.CreateCheckbox();
        btn.Render();
        chk.Render();
    }

    // Swap the entire family by changing one line
    RenderUI(new WindowsFactory());
    Console.WriteLine("---");
    RenderUI(new MacFactory());
*/