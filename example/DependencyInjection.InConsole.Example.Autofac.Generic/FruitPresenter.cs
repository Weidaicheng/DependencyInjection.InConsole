namespace DependencyInjection.InConsole.Example.Autofac.Generic
{
    public class FruitPresenter
    {
        private readonly IFruitDisplay _fruitDisplay;

        public FruitPresenter(IFruitDisplay fruitDisplay)
        {
            _fruitDisplay = fruitDisplay;
        }

        public void Present()
        {
            _fruitDisplay.Display();
        }
    }
}