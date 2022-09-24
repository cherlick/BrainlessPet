
namespace BrainlessPet.Actions
{
    public interface IActionListener
    {
        public void ActionRaised();
    }
    public interface IActionListener<T>
    {
        public void ActionRaised(T data);
    }
}

