using Microsoft.VisualBasic;
using OOPS_Practise.AbstractDesign;
using OOPS_Practise.AdapterDesign;
using OOPS_Practise.BuilderPattern;
using OOPS_Practise.ChainOfResponsibilty.LoggingSystem;
using OOPS_Practise.commandPattern;
using OOPS_Practise.CompositeDesign;
using OOPS_Practise.DecoratorDesign;
using OOPS_Practise.FacadeDesign;
using OOPS_Practise.FactoryDesign;
using OOPS_Practise.ObserverPattern;
using OOPS_Practise.ProxyDesign;
using OOPS_Practise.SingletonPattern;
using OOPS_Practise.TicTacToeGame;
using OOPS_Practise.VendingMachine;
using Directory = OOPS_Practise.CompositeDesign.Directory;
using File = OOPS_Practise.CompositeDesign.File;
// using OOPS_Practise.StrategyDesign;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Strategy pattern
            // Parent p = new Parent(new BubbleSort());
            // p.sortArray();

            // p.setSortingMethod(new SelectionSort());
            // p.sortArray();

            // Factory pattern
            // INotification ip = NotificationFactory.getObjectBasedOnType("SMS");
            // ip.notifyUser();

            // SingletonPattern
            // Singleton st1 = Singleton.getInstance();
            // Singleton st2 = Singleton.getInstance();

            // Console.WriteLine(st1 == st2);

            // ObserverPattern
            // ISubject sub1 = new Subject();
            // ISubject sub2 = new Subject();
            // IObserver ob = new Observer();
            // Console.WriteLine(sub1);
            // ob.add(sub1);
            // ob.add(sub2);
            // ob.setData(10);

            // TicTacToe Game
            // Game g = new Game();
            // g.initilizeBoard(3);
            // Player p1 = new Player();
            // p1.setPlayerData("A", "1", OOPS_Practise.TicTacToeGame.Type.cross);
            // Player p2 = new Player();
            // p2.setPlayerData("B", "2", OOPS_Practise.TicTacToeGame.Type.round);
            // g.addPlayer(p1);
            // g.addPlayer(p2);

            // Console.WriteLine(g.startGame());

            // Builder pattern
            // StudentDirector st = new StudentDirector(new StudentBuilder());
            // Student n = st.buildStudent();
            // Console.WriteLine(n.rollNumber);

            // ChainOfResponsibilty pattern/Logging system design Interview
            // ILogger Logger = new InfoLogger(new DebugLogger(new ErrorLogger(new WarningLogger())));
            // Logger.log(LogType.INFO, "Hey info");
            // Logger.log(LogType.DEBUG, "Hey info");
            // Logger.log(LogType.ERROR, "Hey info");
            // Logger.log(LogType.WARNING, "Hey info");

            // Adapter Pattern
            // PaymentAdapter p = new PaymentAdapter(new Existing());
            // p.processPayment();

            // Facade Pattern
            // OrderFacade o = new OrderFacade();
            // o.makeOrder();// Without this we have to initialize and use all dependancy in client
            //               // which makes it lack of abstraction and maintainable

            // Proxy Pattern
            // ProxyPayement p = new ProxyPayement();
            // p.makePayement();

            // Composite Pattern
            // ICommonInterface file1 = new File("Resume.docx");
            // file1.display();
            // ICommonInterface file2 = new File("Photo.png");
            // ICommonInterface file3 = new File("Notes.txt");

            // // Create sub-directory
            // Directory subDir = new Directory("Images");
            // subDir.add(file2);

            // // Create root directory
            // Directory root = new Directory("MyDocuments");
            // root.add(file1);
            // root.add(file3);
            // root.add(subDir);

            // root.display();

            // Decorator Pattern
            // ICoffee coffee = new FlatWhite();
            // ICoffee milkyCoffe = new MilkDecorator(coffee);
            // ICoffee sugarCoffe = new MilkDecorator(milkyCoffe);
            // Console.WriteLine(sugarCoffe.cost());

            //Abstract pattern
            // IFactory f = new Suzuki();
            // Bike b = f.createBike();
            // b.driveBike();

            // Vending machine
            // Container c1 = new Container(new Item("coke", "10 ml", 4, 26), 123456);
            // Container c2 = new Container(new Item("Pepsi", "10 ml", 4, 26), 234561);
            // VendingMachine v = new VendingMachine();
            // v.addContainer(c1);
            // v.addContainer(c2);
            // v.pressICButton();

            // Command design pattern
            AC ac = new AC();
            ICommand turnOn = new ACOnCommand(ac);
            RemoteControl r = new RemoteControl();
            r.setCommand(turnOn);
            r.turnOn();
        }
    }

}