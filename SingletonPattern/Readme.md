For use cases where we need only one instance of class use Singleton Pattern
Lock is used to ensure in multi threading environment all thread access single instace of class
Two if instance is null conditions is used because we need to ensure performance and security

1. Performance :- If instance is already created why thread need to wait(lock), So in this case thread directly use the instance(This is done using first condition)
2. Security :- If 2 threads parallely check the first instance null condition then they both find null and go inside the if block, then using lock one of them executed and second wait for it, once second enters the in critical section it get's latest value from memory and instance is not null but if we don't make use of second condition then it again create one instance.
