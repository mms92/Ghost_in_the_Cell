using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/



class Entity
{
    internal int possessor = 0;
    internal int cyborgCount = 0;
}

class Order
{

    internal static List<Order> orders = new List<Order>();
    //internal static List<Order> opponentOrders = new List<Order>();
    enum Type
    {
        Wait,
        Move
    }
    internal Type type;

    internal int source;
    internal int destination;
    internal int count;
    internal Order()
    {
        type = Type.Wait;
    }
    internal Order(int source, int destination, int count)
    {
        type = Type.Move;
        this.source = source;
        this.destination = destination;
        this.count = count;
    }
    internal Troop CreateTroop()
    {
        if (type == Type.Wait) return null;
        if (!Factory.factorys[source].isValidLink(destination)) return null;
    }
}


class Factory : Entity
{
    internal static Factory[] factorys;

    internal int production = 0;
    internal int id = 0;

    private List<(int, int)> link = new List<(int, int)>();

    private List<Troop> incoming = new List<Troop>();

    internal Factory(int id)
    {
        this.id = id;
        possessor = 0;
        cyborgCount = 0;
    }
    internal void AddLink(int id, int distance)
    {
        link.Add((id, distance));
    }
    internal bool isValidLink( int destination)
    {
        foreach (var item in link)
        {
            var destination = item.Item1;
        }
    }
    internal Entity simulate(int iteration)
    {
        List<Troop> toArrive;
        Order[] orders = Order.orders.ToArray();
        int allies = cyborgCount;
        int enemies = 0;
        for (int i = 0; i < iteration; i++)
        {
            // unit movement
            foreach (var item in toArrive)
            {
                item.ETA--;
                if (item.ETA == 0)
                {
                    bool isAllie = item.possessor == this.possessor;
                    if (isAllie) allies += item.cyborgCount;
                    else enemies += item.cyborgCount;
                }
            }
            // order execution
            Order order = orders[i];

            // production
            if (possessor != 0)
            {
                allies += production;
            }
            // combat
            int min = Math.min(allies, enemies);
            int newAllies = allies - min;
            int newEnemies = enemies - min;
            if (newAllies == 0 && newEnemies > 0)
            {
                possessor *= -1;
                allies = newEnemies;
            }
        }
    }
    internal void Incoming(Troop troop)
    {
        incoming.Add(troop);
    }
}

class Troop : Entity
{

    internal int start, end, ETA;

    internal Troop()
    {

    }
}


class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        int factoryCount = int.Parse(Console.ReadLine()); // the number of factories
        int linkCount = int.Parse(Console.ReadLine()); // the number of links between factories
        for (int i = 0; i < linkCount; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int factory1 = int.Parse(inputs[0]);
            int factory2 = int.Parse(inputs[1]);
            int distance = int.Parse(inputs[2]);
        }

        // game loop
        while (true)
        {
            int entityCount = int.Parse(Console.ReadLine()); // the number of entities (e.g. factories and troops)
            for (int i = 0; i < entityCount; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int entityId = int.Parse(inputs[0]);
                string entityType = inputs[1];
                int arg1 = int.Parse(inputs[2]);
                int arg2 = int.Parse(inputs[3]);
                int arg3 = int.Parse(inputs[4]);
                int arg4 = int.Parse(inputs[5]);
                int arg5 = int.Parse(inputs[6]);
            }

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");


            // Any valid action, such as "WAIT" or "MOVE source destination cyborgs"
            Console.WriteLine("WAIT");
        }
    }
}