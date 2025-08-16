using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.ATM
{
    public enum TRANSACTION_TYPE
    {
        WITHDRAW_CASH,
        CHECK_BALANCE,
        IDLE
    }
    public enum CASH_TYPE
    {
        CASH_500 = 500,
        CASH_100 = 100,
        CASH_200 = 200,
        CASH_50 = 50,
        CASH_20 = 20,
        CASH_10 = 10
    }
    public class Account
    {
        private string accountNumber;
        private double balance;

        public bool hasSufficientCash(double amout)
        {
            return this.balance >= amout;
        }

        public void withdrawCash(double amount)
        {
            this.balance -= amount;
        }

        public double checkBalance()
        {
            return this.balance;
        }

        public string getAcccountNumber()
        {
            return this.accountNumber;
        }
    }
    public class Card
    {
        private string cardNumber;
        private int pin;
        private Account acc;
        public Card(string cardNumber, int pin, Account acc)
        {
            this.cardNumber = cardNumber;
            this.pin = pin;
            this.acc = acc;
        }
        public bool validatePin(int pin)
        {
            return this.pin == pin;
        }

        public string getAcccountNumber()
        {
            return acc.getAcccountNumber();
        }
    }
    public class ATMMachineInventory
    {
        private Dictionary<CASH_TYPE, int> inv = new Dictionary<CASH_TYPE, int>();
        public void initilizeATM()
        {
            inv.Add(CASH_TYPE.CASH_500, 10);
            inv.Add(CASH_TYPE.CASH_200, 10);
            inv.Add(CASH_TYPE.CASH_100, 10);
            inv.Add(CASH_TYPE.CASH_50, 10);
            inv.Add(CASH_TYPE.CASH_20, 10);
            inv.Add(CASH_TYPE.CASH_10, 10);
        }

        public bool hasSufficientCash(double amount)
        {
            int totalCash = 0;
            foreach (KeyValuePair<CASH_TYPE, int> item in inv)
            {
                totalCash += (int)item.Key * item.Value;
            }
            return totalCash >= amount;
        }

        public void addCash(CASH_TYPE type, int numberOfNotes)
        {
            inv[type] += numberOfNotes;
        }

        public Dictionary<CASH_TYPE, int> withdrawCash(double amount)
        {
            if (!hasSufficientCash(amount))
            {
                return null;
            }
            Dictionary<CASH_TYPE, int> moneyToReturn = new Dictionary<CASH_TYPE, int>();
            foreach (KeyValuePair<CASH_TYPE, int> item in inv)
            {
                // withdraw logic comes here
            }
            return moneyToReturn;
        }

    }
    public class ATMMachine
    {
        private IState currentState;
        private Card currentCard;
        private Account currentAccount;
        private ATMMachineInventory atmInventory;
        private Dictionary<string, Account> accounts; // Simplified account storage
        private Factory stateFactory;
        private TRANSACTION_TYPE selectedOperation;

        // Constructor
        public ATMMachine()
        {
            this.currentState = Factory.getState(STATE_TYPE.IDLE_STATE);
            this.atmInventory = new ATMMachineInventory();
            this.accounts = new Dictionary<string, Account>();
            Console.WriteLine("ATM initialized in: " + currentState.getStateName());
        }

        // Method to advance to the next state
        public void advanceState()
        {
            IState nextState = this.currentState.getNextState();
            currentState = nextState;
            Console.WriteLine("Current state: " + currentState.getStateName());
        }

        // Card insertion operation
        public void insertCard(Card card)
        {
            if (this.currentState is IdleState)
            {
                Console.WriteLine("Card inserted");
                this.currentCard = card;
                advanceState();
            }
            else
                Console.WriteLine(
                    "Cannot insert card in " + currentState.getStateName());
        }

        // PIN authentication operation
        public void enterPin(int pin)
        {
            if (currentState is HasCard)
            {
                if (currentCard.validatePin(pin))
                {
                    Console.WriteLine("PIN authenticated successfully");
                    currentAccount = accounts[currentCard.getAcccountNumber()];
                    advanceState();
                }
                else
                {
                    Console.WriteLine("Invalid PIN. Please try again");
                    // Could implement PIN retry logic here
                }
            }
            else
            {
                Console.WriteLine("Cannot enter PIN in " + currentState.getStateName());
            }
        }

        // Select operation (withdrawal, balance check, etc.)
        public void selectOperation(TRANSACTION_TYPE transactionType)
        {
            if (currentState is SelectTransaction)
            {
                Console.WriteLine("Selected operation: " + transactionType);
                this.selectedOperation = transactionType;
                advanceState();
            }
            else
            {
                Console.WriteLine(
                    "Cannot select operation in " + currentState.getStateName());
            }
        }

        // Perform the selected transaction
        public void performTransaction(double amount)
        {
            if (currentState is ProcessTransaction)
            {
                try
                {
                    if (selectedOperation == TRANSACTION_TYPE.WITHDRAW_CASH)
                    {
                        performWithdrawal(amount);
                    }
                    else if (selectedOperation == TRANSACTION_TYPE.CHECK_BALANCE)
                    {
                        checkBalance();
                    }
                    // Ask if user wants another transaction
                    advanceState();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Transaction failed:");
                    // Go back to select operation state
                    currentState = Factory.getState(STATE_TYPE.SELECT_TRANSACTION);
                }
            }
            else
            {
                Console.WriteLine(
                    "Cannot perform transaction in " + currentState.getStateName());
            }
        }

        // Return card to user
        public void returnCard()
        {
            if (currentState is HasCard
        || currentState is SelectTransaction
        || currentState is ProcessTransaction)
            {
                Console.WriteLine("Card returned to customer");
                resetATM();
            }
            else
            {
                Console.WriteLine("No card to return in " + currentState.getStateName());
            }
        }

        // Cancel current transaction
        public void cancelTransaction()
        {
            if (currentState is ProcessTransaction
        || currentState is ProcessTransaction)
            {
                Console.WriteLine("Transaction cancelled");
                returnCard();
            }
            else
            {
                Console.WriteLine(
                    "No transaction to cancel in " + currentState.getStateName());
            }
        }

        // Helper method to perform withdrawal
        private void performWithdrawal(double amount)
        {
            // Check if user has sufficient balance
            if (!currentAccount.hasSufficientCash(amount))
            {
                throw new Exception("Insufficient funds in account");
            }
            // Check if ATM has sufficient cash
            if (!atmInventory.hasSufficientCash((int)amount))
            {
                throw new Exception("Insufficient cash in ATM");
            }
            Dictionary<CASH_TYPE, int> dispensedCash = atmInventory.withdrawCash((int)amount);
            if (dispensedCash == null)
            {
                // Rollback the account withdrawal
                throw new Exception("Unable to dispense exact amount");
            }
            Console.WriteLine("Transaction successful. Please collect your cash:");
            foreach (KeyValuePair<CASH_TYPE, int> entry in dispensedCash)
            {
                Console.WriteLine(entry.Value + " x $" + (int)entry.Key);
            }

        }

        // Helper method to check balance
        private void checkBalance()
        {
            Console.WriteLine(
                "Your current balance is: $" + currentAccount.checkBalance());
        }

        // Reset ATM state
        private void resetATM()
        {
            this.currentCard = null;
            this.currentAccount = null;
            this.selectedOperation = TRANSACTION_TYPE.IDLE;
            this.currentState = Factory.getState(STATE_TYPE.IDLE_STATE);
        }

        // Getters and setters
        public IState getCurrentState()
        {
            return currentState;
        }

        public void setCurrentState(IState state)
        {
            this.currentState = state;
        }

        public Card getCurrentCard()
        {
            return currentCard;
        }

        public Account getCurrentAccount()
        {
            return currentAccount;
        }

        public ATMMachineInventory getATMInventory()
        {
            return atmInventory;
        }

        public TRANSACTION_TYPE getSelectedOperation()
        {
            return selectedOperation;
        }

        // Add an account to the ATM (for demo purposes)
        public void addAccount(Account account)
        {
            accounts.Add(account.getAcccountNumber(), account);
        }

        // Get account by number
        public Account getAccount(String accountNumber)
        {
            return accounts[accountNumber];
        }

    }
}

// map -> Dictionary
// set -> hashSet(no order maintain),sortedSet
// pair -> KeyValuePair<T,T>
// vector -> there are many like List
