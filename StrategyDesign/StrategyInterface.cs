namespace OOPS_Practise.StrategyDesign
{
    public interface StrategyInterface
    {
        public void sortArray();

    }

    public class BubbleSort : StrategyInterface
    {
        public void sortArray()
        {
            Console.WriteLine("bubble sort is selected");
        }
        
    }
    public class SelectionSort : StrategyInterface
    {
        public void sortArray()
        {
            Console.WriteLine("selection sort is selected");
        }
        
    }
}